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
        int[] brightness = { 0, 0 };

        /// <summary>
        /// Tablica przechowująca wartości kontrastu
        /// </summary>
        int[] contrast = { 0, 0 };

        /// <summary>
        /// Tablica przechowująca wartości nasycenia
        /// </summary>
        int[] saturation = { 0, 0 };

        /// <summary>
        /// Tablica przechowująca wartości odcienia
        /// </summary>
        int[] hue = { 0, 0 };

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
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BrightnessCorrection brightnessCorrection = new BrightnessCorrection(brightness[0]);
            ContrastCorrection contrastCorrection = new ContrastCorrection(contrast[0]);
            SaturationCorrection saturationCorrection = new SaturationCorrection(saturation[0]);
            HueModifier hueModifier = new HueModifier(hue[0]);

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
            if(connectedCamera.IsRunning)
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
                catch(Exception) { }
            }
        }

        private void startDisplayingButton_Click(object sender, EventArgs e)
        {
            connectedCamera = new VideoCaptureDevice(connectedDevices[camerasListComboBox.SelectedIndex].MonikerString);
            connectedCamera.NewFrame += new NewFrameEventHandler(DisplayCapturedPicture);
            connectedCamera.Stop();
            connectedCamera.Start();
        }

        private void stopRecordingButton_Click(object sender, EventArgs e)
        {
            if(connectedCameraIsRecording && connectedCamera.IsRunning)
            {
                connectedCameraIsRecording = false;
                videoWriter.Close();
            }
        }

        private void stopDisplayingButton_Click(object sender, EventArgs e)
        {
            connectedCamera.Stop();
        }
    }
}
