using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace VedioCapture
{
    public partial class Form1 : Form
    {
        private VideoCapture capture;
        private CancellationTokenSource cts;
        private string videoPath;
        private string captureFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Captures");
        private bool isPlaying = false;

        private Mat currentFrame = null;
        private readonly object frameLock = new object();
        private CancellationTokenSource captureCts;
        private string outputFolder;
        private bool isDragging = false;
        private readonly object captureLock = new object();
        bool wasPlayingBeforeDrag = false;
        private volatile bool captureIsDisposed = false;

        public Form1()
        {
            InitializeComponent();
            trackBarVideo.Scroll += trackBarVideo_Scroll;
            trackBarVideo.MouseDown += (s, e) => isDragging = true;
            trackBarVideo.MouseUp += (s, e) => { isDragging = false; UpdateFrameFromTrackBar(); };
            btnCaptureCurrentFrame.Click += btnCaptureFrame_Click;

            trackBarVideo.MouseDown += (s, e) =>
            {
                isDragging = true;
                // اگر پخش می‌شد، موقتاً نگه دار
                if (isPlaying)
                {
                    wasPlayingBeforeDrag = true;
                    cts?.Cancel();
                    isPlaying = false;
                }
            };

            trackBarVideo.MouseUp += (s, e) =>
            {
                isDragging = false;
                UpdateFrameFromTrackBar();

                // از همان فریم ادامه بده اگر قبلاً پخش می‌شد
                if (wasPlayingBeforeDrag)
                {
                    wasPlayingBeforeDrag = false;
                    btnPlay_Click(this, EventArgs.Empty); // یا جدا کردن منطق پخش به متد قابل فراخوانی مجدد
                }
            };
        }

        private void btnCaptureFrame_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBoxVideo.Image == null)
                {
                    MessageBox.Show("هیچ فریمی برای ذخیره وجود ندارد.");
                    return;
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string filename = Path.Combine(outputFolder, $"frame_{timestamp}.jpg");
                pictureBoxVideo.Image.Save(filename);
                MessageBox.Show($"📸 فریم فعلی ذخیره شد:\n{filename}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ذخیره فریم: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    videoPath = ofd.FileName;
                    outputFolder = Path.Combine(Path.GetDirectoryName(videoPath), "CapturedFrames");
                    Directory.CreateDirectory(outputFolder);

                    capture = new VideoCapture(videoPath);
                    InitializeTrackBar();
                    ShowFrameAt(0); // نمایش فریم ابتدایی
                }
            }
        }

        private void InitializeTrackBar()
        {
            if (capture == null) return;

            double totalFrames;
            lock (captureLock)
            {
                if (captureIsDisposed || capture == null) return;
                try
                {
                    totalFrames = capture.Get(Emgu.CV.CvEnum.CapProp.FrameCount);
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
            }

            int max = (int)Math.Max(1, totalFrames - 1);
            trackBarVideo.Minimum = 0;
            trackBarVideo.Maximum = max;
            trackBarVideo.Value = 0;
        }


        private void trackBarVideo_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }
        private void trackBarVideo_Scroll(object sender, EventArgs e)
        {
            if (isDragging)
            {
                // نمایش فریم حین کشیدن برای پیش‌نمایش سریع
                ShowFrameAt(trackBarVideo.Value);
            }
        }

        private void UpdateFrameFromTrackBar()
        {
            ShowFrameAt(trackBarVideo.Value);
        }

        private void ShowFrameAt(double frameNumber)
        {
            if (capture == null) return;

            using (var frame = new Mat())
            {
                lock (captureLock)
                {
                    if (captureIsDisposed || capture == null) return;
                    try
                    {
                        capture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, frameNumber);
                        capture.Read(frame);
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                }

                if (!frame.IsEmpty)
                {
                    if (!this.IsDisposed && pictureBoxVideo.IsHandleCreated && !pictureBoxVideo.IsDisposed)
                    {
                        try
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (!this.IsDisposed && !pictureBoxVideo.IsDisposed)
                                {
                                    pictureBoxVideo.Image?.Dispose();
                                    pictureBoxVideo.Image = frame.ToBitmap();
                                }
                            }));
                        }
                        catch (ObjectDisposedException)
                        {
                            // کنترل یا فرم در حال بسته شدن است — نادیده بگیر
                        }
                    }
                }
            }
        }


        private async void btnPlay_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                MessageBox.Show("ابتدا ویدیو را انتخاب کنید!");
                return;
            }

            if (isPlaying) return;
            isPlaying = true;
            cts = new CancellationTokenSource();

            double fps;
            lock (captureLock)
            {
                if (captureIsDisposed || capture == null)
                {
                    isPlaying = false;
                    return;
                }
                fps = capture.Get(Emgu.CV.CvEnum.CapProp.Fps);
            }

            int delay = fps > 1 ? (int)(1000.0 / fps) : 33;

            await Task.Run(() =>
            {
                var mat = new Mat();
                try
                {
                    while (isPlaying && !cts.IsCancellationRequested)
                    {
                        bool readOk = false;
                        lock (captureLock)
                        {
                            if (captureIsDisposed || capture == null) break;
                            try
                            {
                                readOk = capture.Read(mat);
                            }
                            catch (ObjectDisposedException)
                            {
                                break;
                            }
                        }

                        if (!readOk || mat.IsEmpty) break;

                        lock (frameLock)
                        {
                            currentFrame?.Dispose();
                            currentFrame = mat.Clone();
                        }

                        using (var img = currentFrame.ToImage<Bgr, byte>())
                        {
                            var bmp = img.ToBitmap();
                            if (!this.IsDisposed && pictureBoxVideo.IsHandleCreated && !pictureBoxVideo.IsDisposed)
                            {
                                try
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        if (!this.IsDisposed && !pictureBoxVideo.IsDisposed)
                                        {
                                            pictureBoxVideo.Image?.Dispose();
                                            pictureBoxVideo.Image = (Bitmap)bmp.Clone();
                                        }
                                    }));
                                }
                                catch (ObjectDisposedException)
                                {
                                    break;
                                }
                            }
                            bmp.Dispose();
                        }

                        Thread.Sleep(delay);
                    }
                }
                finally
                {
                    mat.Dispose();
                    isPlaying = false;
                }
            }, cts.Token);
        }



        private void btnStop_Click(object sender, EventArgs e)
        {
            isPlaying = false;
            cts?.Cancel();
            capture?.Set(Emgu.CV.CvEnum.CapProp.PosFrames, 0); // بازگشت به اول ویدیو
            lock (frameLock)
            {
                currentFrame?.Dispose();
                currentFrame = null;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                MessageBox.Show("ابتدا ویدیو را انتخاب کنید!");
                return;
            }

            if (!Directory.Exists(captureFolder))
                Directory.CreateDirectory(captureFolder);

            if (captureCts != null) // اگر قبلا فعال بود، لغو کن
                captureCts.Cancel();

            captureCts = new CancellationTokenSource();
            var token = captureCts.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    Mat frameToSave = null;
                    lock (frameLock)
                    {
                        if (currentFrame != null)
                            frameToSave = currentFrame.Clone();
                    }

                    if (frameToSave != null)
                    {
                        try
                        {
                            string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
                            string path = Path.Combine(captureFolder, fileName);

                            using (var img = frameToSave.ToImage<Bgr, byte>())
                            {
                                img.Save(path);
                            }
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() =>
                                MessageBox.Show("خطا در ذخیره فریم: " + ex.Message)));
                        }
                        finally
                        {
                            frameToSave.Dispose();
                        }
                    }

                    await Task.Delay(60_000, token); // ۱ دقیقه
                }
            }, token);

            MessageBox.Show("ذخیره خودکار فریم‌ها فعال شد ✅");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // قطع کردن پخش و تسلیم درخواست لغو
                isPlaying = false;
                cts?.Cancel();
                captureCts?.Cancel();

                // علامت‌گذاری که capture قرار است Dispose شود
                lock (captureLock)
                {
                    captureIsDisposed = true;
                    if (capture != null)
                    {
                        try
                        {
                            capture.Dispose();
                        }
                        catch { /* ignore */ }
                        capture = null;
                    }
                }

                // آزادسازی فریم جاری
                lock (frameLock)
                {
                    currentFrame?.Dispose();
                    currentFrame = null;
                }

                // کمی زمان برای اطمینان از خاتمه threadها (اختیاری، کوتاه)
                Thread.Sleep(50);
            }
            catch { /* جلوگیری از خطا در زمان بستن فرم */ }
            finally
            {
                base.OnFormClosing(e);
            }
        }


        private async void btnCapture2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(videoPath))
            {
                MessageBox.Show("لطفا ابتدا ویدیو را انتخاب کنید.");
                return;
            }

            double minutes = (double)numericUpDown1.Value;
            if (minutes <= 0)
            {
                MessageBox.Show("زمان فاصله باید بیشتر از صفر باشد.");
                return;
            }

            btnCapture2.Enabled = false;

            await Task.Run(() =>
            {
                double intervalMs = minutes * 60 * 1000;
                using (var capture = new VideoCapture(videoPath))
                {
                    double totalFrames = capture.Get(CapProp.FrameCount);
                    double fps = capture.Get(CapProp.Fps);
                    double durationMs = (totalFrames / fps) * 1000;

                    int index = 0;

                    for (double t = 0; t < durationMs; t += intervalMs)
                    {
                        capture.Set(CapProp.PosMsec, t);
                        using (Mat frame = new Mat())
                        {
                            capture.Read(frame);
                            if (!frame.IsEmpty)
                            {
                                string filename = Path.Combine(outputFolder, $"frame_{index:D4}.jpg");
                                frame.Save(filename);

                                // نمایش در PictureBox روی UI Thread
                                this.Invoke(new Action(() =>
                                {
                                    pictureBoxVideo.Image?.Dispose();
                                    pictureBoxVideo.Image = frame.ToBitmap();
                                }));

                                index++;
                            }
                            else break;
                        }

                        System.Threading.Thread.Sleep(500);
                    }

                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"✅ عملیات تمام شد!\n{index} فریم ذخیره شد در:\n{outputFolder}");
                        btnCapture2.Enabled = true;
                    }));
                }
            });
        }
    }
}
