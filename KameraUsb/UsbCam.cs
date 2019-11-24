using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video.DirectShow;
using AForge.Video;
using Accord.Video.VFW;
using Accord.Video.FFMPEG;
using AForge.Imaging.Filters;
namespace KameraUsb
{
    public partial class UsbCam : Form
    {
        /// <summary>
        /// Dostępne podłączone kamery
        /// </summary>
        FilterInfoCollection connectedDevices;

        /// <summary>
        /// Wybrana kamera
        /// </summary>
        VideoCaptureDevice connectedCamera;

        /// <summary>
        /// Czy aktualnie podłączona kamera nagrywa
        /// </summary>
        bool connectedCameraIsRecording;

        /// <summary>
        /// Tablica przechowująca wartości jasności
        /// </summary>
        public int Brightness { get; set; }

        /// <summary>
        /// Tablica przechowująca wartości kontrastu
        /// </summary>
        public int Contrast { get; set; }

        /// <summary>
        /// Tablica przechowująca wartości nasycenia
        /// </summary>
        public int Saturation { get; set; }

        /// <summary>
        /// Tablica przechowująca wartości odcienia
        /// </summary>
        public int Hue { get; set; }

        /// <summary>
        /// Obiekt umożliwiający odczyt obrazu
        /// </summary>
        VideoFileWriter videoWriter;

        /// <summary>
        /// Stara bitmapa obrazu
        /// </summary>
        private Bitmap oldBitmap;

        public UsbCam()
        {
            InitializeComponent();
            connectedCameraIsRecording = false;
            Brightness = 0;
            Saturation = 0;
            Contrast = 0;
            Hue = 0;
        }

        /// <summary>
        /// Wyszukanie dostępnych urządzeń
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchForCamerasButton_Click(object sender, EventArgs e)
        {
            // Dostępne urządzenia
            connectedDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Wyczyszczenie listy
            camerasListComboBox.Items.Clear();

            foreach(FilterInfo device in connectedDevices)
            {
                camerasListComboBox.Items.Add(device.Name);
            }
        }

        private void DisplayCapturedPicture(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = new Bitmap(eventArgs.Frame, new Size(cameraPictureBox.Width, cameraPictureBox.Height));

            BrightnessCorrection brightnessCorrection = new BrightnessCorrection(Brightness);
            ContrastCorrection contrastCorrection = new ContrastCorrection(Contrast);
            SaturationCorrection saturationCorrection = new SaturationCorrection(Saturation * 0.1f);
            HueModifier hueModifier = new HueModifier(Hue);

            bitmap = brightnessCorrection.Apply((Bitmap)bitmap.Clone());
            bitmap = contrastCorrection.Apply((Bitmap)bitmap.Clone());
            bitmap = saturationCorrection.Apply((Bitmap)bitmap.Clone());
            bitmap = hueModifier.Apply((Bitmap)bitmap.Clone());

            if(connectedCameraIsRecording)
            {
                videoWriter.WriteVideoFrame(bitmap);
            }

                cameraPictureBox.Image = bitmap;
            

        }

        /// <summary>
        /// Komparator bitmap
        /// </summary>
        /// <param name="bmp1"></param>
        /// <param name="bmp2"></param>
        /// <returns></returns>
        public static bool CompareBitmapsFast(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }

        /// <summary>
        /// Rozpoczecie wyświetlania obrazu z kamery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startRecordingButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (connectedCamera.IsRunning)
                {
                    try
                    {
                        saveVideoFileDialog = new SaveFileDialog();
                        saveVideoFileDialog.Filter = "Avi Files (*.avi)|*.avi";
                        saveVideoFileDialog.Title = "Wskaż miejsce do zapisu";
                        saveVideoFileDialog.ShowDialog();
                        videoWriter = new VideoFileWriter();
                        videoWriter.Open(saveVideoFileDialog.FileName, cameraPictureBox.Image.Width, cameraPictureBox.Image.Height, 30, VideoCodec.MPEG4);
                        connectedCameraIsRecording = true;
                    }
                    catch (Exception) { }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Należy najpierw uruchomić wybraną kamerę");
            }


        }

        private void startDisplayingButton_Click(object sender, EventArgs e)
        {
            try
            {
                connectedCamera = new VideoCaptureDevice(connectedDevices[camerasListComboBox.SelectedIndex].MonikerString);
                connectedCamera.NewFrame += new NewFrameEventHandler(DisplayCapturedPicture);
                connectedCamera.Stop();
                connectedCamera.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Należy najpierw wybrać kamerę");
            }
        }

        private void stopRecordingButton_Click(object sender, EventArgs e)
        {
            if(connectedCameraIsRecording && connectedCamera.IsRunning)
            {
                connectedCameraIsRecording = false;
                videoWriter.Close();
            }
            else
            {
                MessageBox.Show("Nie można zatrzymać nagrywania, ponieważ nic nie jest obecnie nagrywane");
            }
        }

        private void stopDisplayingButton_Click(object sender, EventArgs e)
        {
            try
            {
                connectedCamera.Stop();

            }
            catch(Exception)
            {
                MessageBox.Show("Nie można zatrzymać kamery, ponieważ żadna nie została wybrana");
            }
        }

        /// <summary>
        /// Funkcja wywoływana przy zmianie jasności
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            Brightness = brightnessBar.Value;
        }

        /// <summary>
        /// Funkcja wywoływana przy zmianie nasycenia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saturationBar_Scroll(object sender, EventArgs e)
        {
            Saturation = saturationBar.Value;
        }

        /// <summary>
        /// Funkcja wywoływana przy zmianie kontrastu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contrastBar_Scroll(object sender, EventArgs e)
        {
            Contrast = contrastBar.Value;
        }

        /// <summary>
        /// Funkcja wywoływania przy zmianie koloru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hueBar_Scroll(object sender, EventArgs e)
        {
            Hue = hueBar.Value;
        }

        private void takePicture_Click(object sender, EventArgs e)
        {
            Bitmap picture = new Bitmap(cameraPictureBox.Image);
            picture.Save("screen.bmp");
            picture.Dispose();
            picture = null;
        }
    }
}
