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
            panel1 = new Panel();
            comboBoxTimeUnit = new ComboBox();
            label1 = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVideo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadVedio
            // 
            btnLoadVedio.Location = new Point(22, 12);
            btnLoadVedio.Name = "btnLoadVedio";
            btnLoadVedio.Size = new Size(75, 23);
            btnLoadVedio.TabIndex = 0;
            btnLoadVedio.Text = "Load";
            btnLoadVedio.UseVisualStyleBackColor = true;
            btnLoadVedio.Click += btnLoad_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(103, 12);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 1;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // pictureBoxVideo
            // 
            pictureBoxVideo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxVideo.BackColor = SystemColors.ButtonShadow;
            pictureBoxVideo.Location = new Point(0, 0);
            pictureBoxVideo.Name = "pictureBoxVideo";
            pictureBoxVideo.Size = new Size(1045, 501);
            pictureBoxVideo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxVideo.TabIndex = 2;
            pictureBoxVideo.TabStop = false;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(184, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(265, 12);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(75, 23);
            btnCapture.TabIndex = 4;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Visible = false;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnCapture2
            // 
            btnCapture2.Location = new Point(346, 12);
            btnCapture2.Name = "btnCapture2";
            btnCapture2.Size = new Size(131, 23);
            btnCapture2.TabIndex = 5;
            btnCapture2.Text = "Auto Capture";
            btnCapture2.UseVisualStyleBackColor = true;
            btnCapture2.Click += btnCapture2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(599, 12);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // trackBarVideo
            // 
            trackBarVideo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            trackBarVideo.Location = new Point(12, 8);
            trackBarVideo.Name = "trackBarVideo";
            trackBarVideo.Size = new Size(1021, 45);
            trackBarVideo.TabIndex = 7;
            // 
            // btnCaptureCurrentFrame
            // 
            btnCaptureCurrentFrame.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCaptureCurrentFrame.Location = new Point(889, 12);
            btnCaptureCurrentFrame.Name = "btnCaptureCurrentFrame";
            btnCaptureCurrentFrame.Size = new Size(144, 23);
            btnCaptureCurrentFrame.TabIndex = 8;
            btnCaptureCurrentFrame.Text = "Capture Current Frame";
            btnCaptureCurrentFrame.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxTimeUnit);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLoadVedio);
            panel1.Controls.Add(btnCaptureCurrentFrame);
            panel1.Controls.Add(btnPlay);
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(numericUpDown1);
            panel1.Controls.Add(btnCapture);
            panel1.Controls.Add(btnCapture2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 572);
            panel1.Name = "panel1";
            panel1.Size = new Size(1045, 51);
            panel1.TabIndex = 9;
            // 
            // comboBoxTimeUnit
            // 
            comboBoxTimeUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimeUnit.Items.AddRange(new object[] { "دقیقه", "ثانیه" });
            comboBoxTimeUnit.Location = new Point(725, 12);
            comboBoxTimeUnit.Name = "comboBoxTimeUnit";
            comboBoxTimeUnit.Size = new Size(121, 23);
            comboBoxTimeUnit.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(494, 16);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 9;
            label1.Text = "Frame to Capture";
            // 
            // panel2
            // 
            panel2.Controls.Add(trackBarVideo);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 513);
            panel2.Name = "panel2";
            panel2.Size = new Size(1045, 59);
            panel2.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 623);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBoxVideo);
            Name = "Form1";
            Text = "Vedio Capture";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxVideo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVideo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
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
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private ComboBox comboBoxTimeUnit;
    }
}
