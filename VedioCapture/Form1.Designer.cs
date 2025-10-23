namespace VedioCapture
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnLoadVedio = new Button();
            btnPlay = new Button();
            pictureBoxVideo = new PictureBox();
            btnStop = new Button();
            btnCapture = new Button();
            timerCapture = new System.Windows.Forms.Timer(components);
            btnCapture2 = new Button();
            numericUpDown1 = new NumericUpDown();
            trackBarVideo = new TrackBar();
            btnCaptureCurrentFrame = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVideo).BeginInit();
            SuspendLayout();
            // 
            // btnLoadVedio
            // 
            btnLoadVedio.Location = new Point(9, 415);
            btnLoadVedio.Name = "btnLoadVedio";
            btnLoadVedio.Size = new Size(75, 23);
            btnLoadVedio.TabIndex = 0;
            btnLoadVedio.Text = "Load";
            btnLoadVedio.UseVisualStyleBackColor = true;
            btnLoadVedio.Click += btnLoad_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(90, 415);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // pictureBoxVideo
            // 
            pictureBoxVideo.Dock = DockStyle.Top;
            pictureBoxVideo.Location = new Point(0, 0);
            pictureBoxVideo.Name = "pictureBoxVideo";
            pictureBoxVideo.Size = new Size(800, 358);
            pictureBoxVideo.TabIndex = 2;
            pictureBoxVideo.TabStop = false;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(171, 415);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(252, 415);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(75, 23);
            btnCapture.TabIndex = 4;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnCapture2
            // 
            btnCapture2.Location = new Point(333, 415);
            btnCapture2.Name = "btnCapture2";
            btnCapture2.Size = new Size(75, 23);
            btnCapture2.TabIndex = 5;
            btnCapture2.Text = "Capture2";
            btnCapture2.UseVisualStyleBackColor = true;
            btnCapture2.Click += btnCapture2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(616, 415);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // trackBarVideo
            // 
            trackBarVideo.Location = new Point(9, 364);
            trackBarVideo.Name = "trackBarVideo";
            trackBarVideo.Size = new Size(779, 45);
            trackBarVideo.TabIndex = 7;
            // 
            // btnCaptureCurrentFrame
            // 
            btnCaptureCurrentFrame.Location = new Point(414, 415);
            btnCaptureCurrentFrame.Name = "btnCaptureCurrentFrame";
            btnCaptureCurrentFrame.Size = new Size(144, 23);
            btnCaptureCurrentFrame.TabIndex = 8;
            btnCaptureCurrentFrame.Text = "Capture Current Frame";
            btnCaptureCurrentFrame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCaptureCurrentFrame);
            Controls.Add(trackBarVideo);
            Controls.Add(numericUpDown1);
            Controls.Add(btnCapture2);
            Controls.Add(btnCapture);
            Controls.Add(btnStop);
            Controls.Add(pictureBoxVideo);
            Controls.Add(btnPlay);
            Controls.Add(btnLoadVedio);
            Name = "Form1";
            Text = "Vedio Capture";
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVideo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadVedio;
        private Button btnPlay;
        private PictureBox pictureBoxVideo;
        private Button btnStop;
        private Button btnCapture;
        private System.Windows.Forms.Timer timerCapture;
        private Button btnCapture2;
        private NumericUpDown numericUpDown1;
        private TrackBar trackBarVideo;
        private Button btnCaptureCurrentFrame;
    }
}
