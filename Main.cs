using DirectShowLib;
using Object_Detection.Forms;
using Object_Detection;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TClass;
using System.IO.Ports;
using System.Drawing.Drawing2D;
using Yolo.Net;
using System.Data;
using Object_Detection.SQliteDataAccess;
using System.Runtime.Intrinsics.X86;
using OpenCvSharp.Aruco;

namespace Object_Detection
{
    public partial class Main : Form
    {
        private readonly BackgroundWorker bgObjDetection;
        public readonly TControl cameraControl;
        public readonly TCapture.Capture myCapture;
        private SerialPort serialPort;
        private IPredictor yolo;
        private Prediction[]? predictions;
        private Image imgPrediction;

        private readonly string[] baudList = { "9600", "19200", "38400", "57600", "115200" };

        private bool isObjDetect = false;
        private Stopwatch stopwatch;

        private string labelOBJ = string.Empty;
        private List<SQliteDataAccess.Module> modules;

        private History history;
        public Main()
        {
            InitializeComponent();
            myCapture = new TCapture.Capture();
            myCapture.OnFrameHeader += MyCapture_OnFrameHeader;
            myCapture.OnVideoStarted += MyCapture_OnVideoStarted;
            myCapture.OnError += MyCapture_OnError;
            cameraControl = new TControl();

            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.ErrorReceived += SerialPort_ErrorReceived;

            bgObjDetection = new BackgroundWorker();
            bgObjDetection.DoWork += BgObjDetection_DoWork;
            bgObjDetection.RunWorkerCompleted += BgObjDetection_RunWorkerCompleted;
            bgObjDetection.WorkerSupportsCancellation = true;
            bgObjDetection.WorkerReportsProgress = true;

            stopwatch = new Stopwatch();

            history = new History();

        }
        private Task taskDeleteOldFile;

        private void DeleteOldFile()
        {
            taskDeleteOldFile = Task.Run(() =>
            {
                // Get files
                var files = Directory.GetFiles(Properties.Resources.path_history, "*.jpg", SearchOption.AllDirectories);
                // Delete files old 30 days
                foreach (var file in files)
                {
                    if (File.GetCreationTime(file) < DateTime.Now.AddDays(-30))
                    {
                        File.Delete(file);
                    }
                }
                // Get modules
                var modules = SQliteDataAccess.Module.Get();
                // Get files
                var files2 = Directory.GetFiles(Properties.Resources.path_images, "*.jpg", SearchOption.AllDirectories);
                // Delete files if not exist in modules
                foreach (var file in files2)
                {
                    if (!modules.Any(x => x.image == Path.GetFileName(file)))
                    {
                        File.Delete(file);
                    }
                }

                // Get files onnx
                var files3 = Directory.GetFiles(Properties.Resources.path_weight, "*.onnx", SearchOption.AllDirectories);
                // Delete files if not exist in modules
                foreach (var file in files3)
                {
                    if (!modules.Any(x => x.path == Path.GetFileName(file)))
                    {
                        File.Delete(file);
                    }
                }
            });
        }


        private void BgObjDetection_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void BgObjDetection_DoWork(object? sender, DoWorkEventArgs e)
        {
            stopwatch.Restart();
            predictions = yolo.Predict(imgPrediction);
            stopwatch.Stop();
            Debug.WriteLine("Time {0}ms", stopwatch.ElapsedMilliseconds);
        }

        private string readDataSerial = string.Empty;
        private string dataSerialReceived = string.Empty;

        private void Main_Load(object sender, EventArgs e)
        {
            loading();
            DeleteOldFile();
        }

        public void loading()
        {
            var drive = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

            cbDrive.Items.Clear();
            foreach (DsDevice device in drive)
            {
                cbDrive.Items.Add(device.Name);
            }
            drive.Clear();

            if (cbDrive.Items.Count > 0)
                cbDrive.SelectedIndex = 0;

            cbBaud.Items.Clear();
            cbBaud.Items.AddRange(baudList);

            if (cbBaud.Items.Count > 0)
                cbBaud.SelectedIndex = baudList.Length - 1;

            cbCOM.Items.Clear();
            cbCOM.Items.AddRange(SerialPort.GetPortNames());

            if (cbCOM.Items.Count > 0)
                cbCOM.SelectedIndex = 0;
        }

        private void MyCapture_OnError(string messages)
        {

            Debug.WriteLine(messages);
        }

        private void MyCapture_OnVideoStarted()
        {
            Debug.WriteLine("Video Started");
        }

        private void MyCapture_OnFrameHeader(Bitmap bitmap)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MyCapture_OnFrameHeader(bitmap)));
                return;
            }
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = (Image)bitmap.Clone();
            UpdateFrameRate();

            DrawBoxes(pictureBox1.Image, predictions);
            if (!bgObjDetection.IsBusy && bitmap != null && yolo != null)
            {
                imgPrediction?.Dispose();
                imgPrediction = (Image)bitmap.Clone();
                bgObjDetection.RunWorkerAsync();
            }

            if (isObjDetect)
            {
                string filename = SaveImagePredic(imgPrediction, predictions);
                string filename_master = Guid.NewGuid().ToString() + ".jpg";
                filename_master.Replace("-", "_");
                filename_master = "M_" + filename_master;
                using (Image bmp = Image.FromFile(Path.Combine(Properties.Resources.path_images, modules[0].image)))
                {
                    bmp.Save(Path.Combine(Properties.Resources.path_history, filename_master), ImageFormat.Jpeg);
                }

                pictureBoxDetect.Image?.Dispose();

                pictureBoxDetect.Image = Image.FromFile(Path.Combine(Properties.Resources.path_history, filename));

                history.image_path_master = filename_master;
                history.image_path_result = filename;
                history.result = labelOBJ;
                if (labelOBJ == "NG")
                {
                    serialCommand("ng");
                    lbName.Text = "NG";
                    lbName.BackColor = Color.Red;
                }
                else if (labelOBJ == "OK")
                {
                    serialCommand("ok");
                    lbName.Text = "OK";
                    lbName.BackColor = Color.Green;
                }

                if (history.image_path_result != string.Empty)
                {
                    history.Save();
                }

                isObjDetect = false;
            }
        }

        private Stopwatch stopwatchFrame = new Stopwatch();
        private long frameCount = 0;
        private double frameRate = 0;

        private void UpdateFrameRate()
        {
            frameCount++;

            if (!stopwatchFrame.IsRunning)
            {
                stopwatchFrame.Start();
            }
            else
            {
                double elapsedSeconds = stopwatchFrame.Elapsed.TotalSeconds;
                if (elapsedSeconds >= 1)
                {
                    frameRate = frameCount / elapsedSeconds;
                    frameCount = 0;
                    stopwatchFrame.Restart();

                    // Display frame rate in a label or another UI element
                    toolStripStatusLabel.Text = $"Frame Rate: {frameRate:0.0} fps";
                }
            }
        }

        private bool isConnect = false;
        private Task openTask;
        private int camIndex;

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (openTask != null && openTask.Status == TaskStatus.Running)
                {
                    Debug.WriteLine("Task is running");
                    return;
                }
                isConnect = !isConnect;
                if (isConnect)
                {
                    if (cbDrive.SelectedIndex == -1)
                    {
                        throw new Exception("Invalid drive camera");
                    }
                    btnConnect.Text = "Connecting";
                    pictureBox1.Image = null;
                    pictureBox1.Image = Properties.Resources.Spinner_0_4s_800px;
                    camIndex = cbDrive.SelectedIndex;
                    openTask = Task.Run(() =>
                    {
                        myCapture.Start(camIndex);
                    });
                    await openTask;
                    cameraControl.set(camIndex);

                    if (cbSerial.Checked)
                    {
                        // Connect to serial port
                        if (this.serialPort != null && this.serialPort.IsOpen)
                        {
                            this.serialPort.Close();
                        }

                        serialPort.BaudRate = int.Parse(cbBaud.Text);
                        serialPort.PortName = cbCOM.Text;
                        serialPort.Open();
                    }
                    modules = SQliteDataAccess.Module.Get();

                    if (File.Exists(Path.Combine(Properties.Resources.path_weight, modules[0].path)))
                    {
                        yolo = YoloV5Predictor.Create(Path.Combine(Properties.Resources.path_weight, modules[0].path), new string[] { "OK", "NG" });
                        Debug.WriteLine("OK");
                    }
                    else
                    {
                        Debug.WriteLine("OK");
                    }
                    btnConnect.Text = "Disconnect";
                    lbName.Text = "Processing..";
                    lbName.BackColor = Color.Yellow;

                    pictureBoxDetect.Image?.Dispose();
                    pictureBoxDetect.Image = Properties.Resources.Spinner_0_4s_800px;
                }
                else
                {
                    myCapture.Stop();
                    btnConnect.Text = "Connect";
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = null;
                    if (this.serialPort != null && this.serialPort.IsOpen)
                    {
                        this.serialPort.Close();
                    }

                    lbName.Text = "---------------";
                    lbName.BackColor = Color.Yellow;
                    pictureBoxDetect.Image?.Dispose();
                    pictureBoxDetect.Image = null;
                }

                if (serialPort.IsOpen)
                {
                    toolStripStatusSerial.Text = $"Serial: {serialPort.PortName} - {serialPort.BaudRate}";
                    toolStripStatusSerial.ForeColor = Color.Green;
                }
                else
                {
                    toolStripStatusSerial.Text = $"Serial: {serialPort.PortName} - {serialPort.BaudRate}";
                    toolStripStatusSerial.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusError.Text = ex.Message;
                toolStripStatusError.ForeColor = Color.Red;
            }
        }

        private CameraControls camControls;
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (camControls != null)
            {
                camControls.Close();
                camControls.Dispose();
            }
            camControls = new CameraControls(this);
            camControls.Show();
        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Guid.NewGuid().ToString() + ".jpg";

                if (!Directory.Exists(Properties.Resources.path_images))
                    Directory.CreateDirectory(Properties.Resources.path_images);

                toolStripStatusLabel.Text = filename;
                filename = Path.Combine(Properties.Resources.path_images, filename);
                pictureBox1.Image?.Save(filename, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            readDataSerial = serialPort.ReadLine();
            _ = this.Invoke(new EventHandler(dataReceived));
        }

        private void dataReceived(object sender, EventArgs e)
        {
            this.dataSerialReceived += readDataSerial;
            if (dataSerialReceived.Contains(">") && dataSerialReceived.Contains("<"))
            {
                string data = this.dataSerialReceived.Replace("\r", string.Empty).Replace("\n", string.Empty);
                data = data.Substring(data.IndexOf(">") + 1, data.IndexOf("<") - data.IndexOf(">") - 1);
                this.dataSerialReceived = string.Empty;
                data = data.Replace(">", "").Replace("<", "");
                toolStripStatusSerialData.Text = "DATA :" + data;
                if (data == "st")
                {
                    isObjDetect = true;
                    lbName.Text = "Processing..";
                    lbName.BackColor = Color.Yellow;
                }
                else if (data == "rs")
                {
                    predictions = null;
                    lbName.Text = "Processing..";
                    lbName.BackColor = Color.Yellow;
                    pictureBoxDetect.Image?.Dispose();
                    pictureBoxDetect.Image = Properties.Resources.Spinner_0_4s_800px;
                }

            }
            else if (!dataSerialReceived.Contains(">"))
            {
                this.dataSerialReceived = string.Empty;
            }
        }

        public void serialCommand(string command)
        {
            if (this.serialPort.IsOpen)
            {
                this.serialPort.Write(">" + command + "<#");
                toolStripStatusSerialData.Text = "DATA :" + command;
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {

        }

        private string SaveImagePredic(Image image, Prediction[] predictions)
        {
            string filename = Guid.NewGuid().ToString() + ".jpg";

            if (image == null || predictions == null || predictions.Length != 1) return string.Empty;

            var originalImageHeight = image.Height;
            var originalImageWidth = image.Width;
            foreach (var pred in predictions)
            {
                var x = Math.Max(pred.Rectangle.X, 0);
                var y = Math.Max(pred.Rectangle.Y, 0);
                var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
                var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

                string text = $"{pred.Label.Name} [{pred.Score}]";
                using (Bitmap img = new Bitmap((int)width, (int)height))
                {
                    Rectangle rect = new Rectangle((int)x, (int)y, (int)width, (int)height);
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        g.DrawImage(image, 0, 0, rect, GraphicsUnit.Pixel);
                    }
                    if (!Directory.Exists(Properties.Resources.path_history))
                    {
                        Directory.CreateDirectory(Properties.Resources.path_history);
                    }
                    filename.Replace("-", "_");
                    filename = text + "_" + filename;
                    string path = Path.Combine(Properties.Resources.path_history, filename);
                    img.Save(path, ImageFormat.Jpeg);

                    string filename2 = text + "_2_" + filename;
                    path = Path.Combine(Properties.Resources.path_history, filename2);
                    image.Save(path, ImageFormat.Jpeg);
                    filename2.Replace("_2_", "");
                };
            }
            return filename;
        }

        private void DrawBoxes(Image image, Prediction[] predictions)
        {

            if (image == null || predictions == null) return;

            foreach (var pred in predictions)
            {
                var originalImageHeight = image.Height;
                var originalImageWidth = image.Width;

                var x = Math.Max(pred.Rectangle.X, 0);
                var y = Math.Max(pred.Rectangle.Y, 0);
                var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
                var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

                //Note that the output is already scaled to the original image height and width.

                // Bounding Box Text
                string text = $"{pred.Label.Name} [{pred.Score}]";

                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Define Text Options
                    Font drawFont = new Font("consolas", 11, FontStyle.Regular);
                    SizeF size = graphics.MeasureString(text, drawFont);
                    SolidBrush fontBrush = new SolidBrush(Color.Black);
                    System.Drawing.Point atPoint = new System.Drawing.Point((int)x, (int)y - (int)size.Height - 1);

                    // Define BoundingBox options
                    Pen pen = new Pen(Color.Green, 2.0f);
                    SolidBrush colorBrush = new SolidBrush(Color.Green);
                    // if found NG
                    if (pred.Label.Name == "NG")
                    {
                        pen = new Pen(Color.Red, 2.0f);
                        colorBrush = new SolidBrush(Color.Red);
                    }
                    labelOBJ = pred.Label.Name;
                    // Draw text on image 
                    graphics.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
                    graphics.DrawString(text, drawFont, fontBrush, atPoint);

                    // Draw bounding box on image
                    graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
        }
        private Forms.UploadModule uploadModule;
        private void uploadModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (isConnect)
            {
                MessageBox.Show("Please disconnect serial port before open upload module");
                return;
            }

            if (uploadModule != null)
            {
                uploadModule.Close();
                uploadModule.Dispose();
            }

            uploadModule = new UploadModule();
            uploadModule.Show();
        }

        private Forms.ListModules listModules;
        private void listModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isConnect)
            {
                MessageBox.Show("Please disconnect serial port before open upload module");
                return;
            }

            if (listModules != null)
            {
                listModules.Close();
                listModules.Dispose();
            }

            listModules = new Forms.ListModules();
            listModules.Show();
        }

    }
}