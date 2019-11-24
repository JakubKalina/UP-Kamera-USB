namespace KameraUsb
{
    partial class UsbCam
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchForCamerasButton = new System.Windows.Forms.Button();
            this.cameraPictureBox = new System.Windows.Forms.PictureBox();
            this.camerasListComboBox = new System.Windows.Forms.ComboBox();
            this.startRecordingButton = new System.Windows.Forms.Button();
            this.stopRecordingButton = new System.Windows.Forms.Button();
            this.startDisplayingButton = new System.Windows.Forms.Button();
            this.stopDisplayingButton = new System.Windows.Forms.Button();
            this.brightnessBar = new System.Windows.Forms.TrackBar();
            this.brightnessBarLabel = new System.Windows.Forms.Label();
            this.saturationBar = new System.Windows.Forms.TrackBar();
            this.saturationBarLabel = new System.Windows.Forms.Label();
            this.contrastBar = new System.Windows.Forms.TrackBar();
            this.contrastBarLabel = new System.Windows.Forms.Label();
            this.hueBarLabel = new System.Windows.Forms.Label();
            this.hueBar = new System.Windows.Forms.TrackBar();
            this.saveVideoFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.takePicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBar)).BeginInit();
            this.SuspendLayout();
            // 
            // searchForCamerasButton
            // 
            this.searchForCamerasButton.Location = new System.Drawing.Point(820, 12);
            this.searchForCamerasButton.Name = "searchForCamerasButton";
            this.searchForCamerasButton.Size = new System.Drawing.Size(260, 39);
            this.searchForCamerasButton.TabIndex = 0;
            this.searchForCamerasButton.Text = "Wyszukaj podłączone kamery";
            this.searchForCamerasButton.UseVisualStyleBackColor = true;
            this.searchForCamerasButton.Click += new System.EventHandler(this.searchForCamerasButton_Click);
            // 
            // cameraPictureBox
            // 
            this.cameraPictureBox.Location = new System.Drawing.Point(50, 29);
            this.cameraPictureBox.Name = "cameraPictureBox";
            this.cameraPictureBox.Size = new System.Drawing.Size(640, 480);
            this.cameraPictureBox.TabIndex = 1;
            this.cameraPictureBox.TabStop = false;
            // 
            // camerasListComboBox
            // 
            this.camerasListComboBox.FormattingEnabled = true;
            this.camerasListComboBox.Location = new System.Drawing.Point(820, 57);
            this.camerasListComboBox.Name = "camerasListComboBox";
            this.camerasListComboBox.Size = new System.Drawing.Size(260, 24);
            this.camerasListComboBox.TabIndex = 2;
            // 
            // startRecordingButton
            // 
            this.startRecordingButton.Location = new System.Drawing.Point(746, 439);
            this.startRecordingButton.Name = "startRecordingButton";
            this.startRecordingButton.Size = new System.Drawing.Size(176, 32);
            this.startRecordingButton.TabIndex = 3;
            this.startRecordingButton.Text = "Rozpocznij nagrywanie";
            this.startRecordingButton.UseVisualStyleBackColor = true;
            this.startRecordingButton.Click += new System.EventHandler(this.startRecordingButton_Click);
            // 
            // stopRecordingButton
            // 
            this.stopRecordingButton.Location = new System.Drawing.Point(746, 477);
            this.stopRecordingButton.Name = "stopRecordingButton";
            this.stopRecordingButton.Size = new System.Drawing.Size(176, 32);
            this.stopRecordingButton.TabIndex = 4;
            this.stopRecordingButton.Text = "Zakończ nagrywanie";
            this.stopRecordingButton.UseVisualStyleBackColor = true;
            this.stopRecordingButton.Click += new System.EventHandler(this.stopRecordingButton_Click);
            // 
            // startDisplayingButton
            // 
            this.startDisplayingButton.Location = new System.Drawing.Point(942, 439);
            this.startDisplayingButton.Name = "startDisplayingButton";
            this.startDisplayingButton.Size = new System.Drawing.Size(176, 32);
            this.startDisplayingButton.TabIndex = 5;
            this.startDisplayingButton.Text = "Uruchom kamerę";
            this.startDisplayingButton.UseVisualStyleBackColor = true;
            this.startDisplayingButton.Click += new System.EventHandler(this.startDisplayingButton_Click);
            // 
            // stopDisplayingButton
            // 
            this.stopDisplayingButton.Location = new System.Drawing.Point(942, 477);
            this.stopDisplayingButton.Name = "stopDisplayingButton";
            this.stopDisplayingButton.Size = new System.Drawing.Size(176, 32);
            this.stopDisplayingButton.TabIndex = 6;
            this.stopDisplayingButton.Text = "Zatrzymaj kamerę";
            this.stopDisplayingButton.UseVisualStyleBackColor = true;
            this.stopDisplayingButton.Click += new System.EventHandler(this.stopDisplayingButton_Click);
            // 
            // brightnessBar
            // 
            this.brightnessBar.Location = new System.Drawing.Point(920, 123);
            this.brightnessBar.Maximum = 100;
            this.brightnessBar.Name = "brightnessBar";
            this.brightnessBar.Size = new System.Drawing.Size(176, 56);
            this.brightnessBar.TabIndex = 7;
            this.brightnessBar.Scroll += new System.EventHandler(this.brightnessBar_Scroll);
            // 
            // brightnessBarLabel
            // 
            this.brightnessBarLabel.AutoSize = true;
            this.brightnessBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.brightnessBarLabel.Location = new System.Drawing.Point(780, 123);
            this.brightnessBarLabel.Name = "brightnessBarLabel";
            this.brightnessBarLabel.Size = new System.Drawing.Size(115, 31);
            this.brightnessBarLabel.TabIndex = 8;
            this.brightnessBarLabel.Text = "Jasność";
            // 
            // saturationBar
            // 
            this.saturationBar.Location = new System.Drawing.Point(920, 206);
            this.saturationBar.Name = "saturationBar";
            this.saturationBar.Size = new System.Drawing.Size(176, 56);
            this.saturationBar.TabIndex = 9;
            this.saturationBar.Scroll += new System.EventHandler(this.saturationBar_Scroll);
            // 
            // saturationBarLabel
            // 
            this.saturationBarLabel.AutoSize = true;
            this.saturationBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saturationBarLabel.Location = new System.Drawing.Point(780, 206);
            this.saturationBarLabel.Name = "saturationBarLabel";
            this.saturationBarLabel.Size = new System.Drawing.Size(142, 31);
            this.saturationBarLabel.TabIndex = 10;
            this.saturationBarLabel.Text = "Nasycenie";
            // 
            // contrastBar
            // 
            this.contrastBar.Location = new System.Drawing.Point(920, 299);
            this.contrastBar.Maximum = 100;
            this.contrastBar.Name = "contrastBar";
            this.contrastBar.Size = new System.Drawing.Size(176, 56);
            this.contrastBar.TabIndex = 11;
            this.contrastBar.Scroll += new System.EventHandler(this.contrastBar_Scroll);
            // 
            // contrastBarLabel
            // 
            this.contrastBarLabel.AutoSize = true;
            this.contrastBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.contrastBarLabel.Location = new System.Drawing.Point(780, 299);
            this.contrastBarLabel.Name = "contrastBarLabel";
            this.contrastBarLabel.Size = new System.Drawing.Size(116, 31);
            this.contrastBarLabel.TabIndex = 12;
            this.contrastBarLabel.Text = "Kontrast";
            // 
            // hueBarLabel
            // 
            this.hueBarLabel.AutoSize = true;
            this.hueBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hueBarLabel.Location = new System.Drawing.Point(780, 377);
            this.hueBarLabel.Name = "hueBarLabel";
            this.hueBarLabel.Size = new System.Drawing.Size(100, 31);
            this.hueBarLabel.TabIndex = 13;
            this.hueBarLabel.Text = "Odcień";
            // 
            // hueBar
            // 
            this.hueBar.Location = new System.Drawing.Point(920, 377);
            this.hueBar.Maximum = 100;
            this.hueBar.Name = "hueBar";
            this.hueBar.Size = new System.Drawing.Size(176, 56);
            this.hueBar.TabIndex = 14;
            this.hueBar.Scroll += new System.EventHandler(this.hueBar_Scroll);
            // 
            // takePicture
            // 
            this.takePicture.Location = new System.Drawing.Point(746, 515);
            this.takePicture.Name = "takePicture";
            this.takePicture.Size = new System.Drawing.Size(176, 32);
            this.takePicture.TabIndex = 15;
            this.takePicture.Text = "Zrób zdjęcie";
            this.takePicture.UseVisualStyleBackColor = true;
            this.takePicture.Click += new System.EventHandler(this.takePicture_Click);
            // 
            // UsbCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 564);
            this.Controls.Add(this.takePicture);
            this.Controls.Add(this.hueBar);
            this.Controls.Add(this.hueBarLabel);
            this.Controls.Add(this.contrastBarLabel);
            this.Controls.Add(this.contrastBar);
            this.Controls.Add(this.saturationBarLabel);
            this.Controls.Add(this.saturationBar);
            this.Controls.Add(this.brightnessBarLabel);
            this.Controls.Add(this.brightnessBar);
            this.Controls.Add(this.stopDisplayingButton);
            this.Controls.Add(this.startDisplayingButton);
            this.Controls.Add(this.stopRecordingButton);
            this.Controls.Add(this.startRecordingButton);
            this.Controls.Add(this.camerasListComboBox);
            this.Controls.Add(this.cameraPictureBox);
            this.Controls.Add(this.searchForCamerasButton);
            this.Name = "UsbCam";
            this.Text = "UsbCam";
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchForCamerasButton;
        private System.Windows.Forms.PictureBox cameraPictureBox;
        private System.Windows.Forms.ComboBox camerasListComboBox;
        private System.Windows.Forms.Button startRecordingButton;
        private System.Windows.Forms.Button stopRecordingButton;
        private System.Windows.Forms.Button startDisplayingButton;
        private System.Windows.Forms.Button stopDisplayingButton;
        private System.Windows.Forms.TrackBar brightnessBar;
        private System.Windows.Forms.Label brightnessBarLabel;
        private System.Windows.Forms.TrackBar saturationBar;
        private System.Windows.Forms.Label saturationBarLabel;
        private System.Windows.Forms.TrackBar contrastBar;
        private System.Windows.Forms.Label contrastBarLabel;
        private System.Windows.Forms.Label hueBarLabel;
        private System.Windows.Forms.TrackBar hueBar;
        private System.Windows.Forms.SaveFileDialog saveVideoFileDialog;
        private System.Windows.Forms.Button takePicture;
    }
}

