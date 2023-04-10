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

using System.Data;
using Object_Detection.SQliteDataAccess;
using System.Runtime.Intrinsics.X86;
using OpenCvSharp.Aruco;
using System.Drawing;
using Yolonet;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

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
        private Image imgDetection;

        private readonly string[] baudList = { "9600", "19200", "38400", "57600", "115200" };

        private bool isObjDetect = false;
        private bool isObjDetectReset = false;
        private Stopwatch stopwatch;

        private string labelOBJ = string.Empty;
        private List<SQliteDataAccess.Module> modules;

        private History history;

        private int oldDriveIndex = -1;
        private int oldBaudIndex = -1;
        private int oldCOMIndex = -1;

        private DsDevice[] videoInputDevices;
        private IGraphBuilder _graphBuilder;
        private ICaptureGraphBuilder2 _captureGraphBuilder;
        private IBaseFilter _captureFilter;

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
            bgObjDetection.ProgressChanged += BgObjDetection_ProgressChanged;
            bgObjDetection.WorkerSupportsCancellation = true;
            bgObjDetection.WorkerReportsProgress = true;

            stopwatch = new Stopwatch();

            history = new History();

        }


        private void Main_Load(object sender, EventArgs e)
        {
            btnLoading.PerformClick();
            DeleteOldFile();
            renderTable = Task.Run(() =>
            {
                RenderTable();
            });
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


        private void BgObjDetection_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            toolStripStatusTime.Text = "Time " + stopwatch.ElapsedMilliseconds + "ms";
        }

        private void BgObjDetection_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void BgObjDetection_DoWork(object? sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                stopwatch.Restart();
                if (imgDetection != null)
                {
                    imgPrediction?.Dispose();
                    imgPrediction = (Image)imgDetection.Clone();
                }
                predictions = yolo.Predict(imgPrediction);
                Thread.Sleep(300);
                stopwatch.Stop();
                Debug.WriteLine("Time {0}ms", stopwatch.ElapsedMilliseconds);

                worker.ReportProgress(0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("E01 " + ex.Message);
                toolStripStatusError.Text = "E01 " + ex.Message;
                toolStripStatusError.ForeColor = Color.Red;
            }
        }

        private string readDataSerial = string.Empty;
        private string dataSerialReceived = string.Empty;

        private Task renderTable;



        public void loading(object? sender, EventArgs? e)
        {
            var drive = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

            videoInputDevices = GetVideoInputDevices();

            cbDrive.Items.Clear();
            foreach (DsDevice device in drive)
            {
                cbDrive.Items.Add(device.Name);
            }
            drive.Clear();
            if (oldDriveIndex != -1 && cbDrive.Items.Count > oldDriveIndex)
            {
                cbDrive.SelectedIndex = oldDriveIndex;
            }
            else if (cbDrive.Items.Count > 0)
            {
                cbDrive.SelectedIndex = 0;
            }

            cbBaud.Items.Clear();
            cbBaud.Items.AddRange(baudList);

            if (oldBaudIndex != -1 && cbBaud.Items.Count > oldBaudIndex)
            {
                cbBaud.SelectedIndex = oldBaudIndex;
            }
            else if (cbBaud.Items.Count > 0)
            {
                cbBaud.SelectedIndex = baudList.Length - 1;
            }

            cbCOM.Items.Clear();
            cbCOM.Items.AddRange(SerialPort.GetPortNames());

            if (oldCOMIndex != -1 && cbCOM.Items.Count > oldCOMIndex)
            {
                cbCOM.SelectedIndex = oldCOMIndex;
            }
            else if (cbCOM.Items.Count > 0)
            {
                cbCOM.SelectedIndex = 0;
            }
        }

        private static DsDevice[] GetVideoInputDevices()
        {
            return DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
        }

        private void MyCapture_OnError(string messages)
        {

            Debug.WriteLine(messages);
        }

        private void MyCapture_OnVideoStarted()
        {
            Debug.WriteLine("Video Started");
            if (InvokeRequired)
            {
                Invoke(new Action(() => MyCapture_OnVideoStarted()));
                return;
            }

            cameraControl.setFocus(Properties.Settings.Default.dFocus);
            cameraControl.setZoom(Properties.Settings.Default.dZoom);
            cameraControl.setPan(Properties.Settings.Default.dPan);
            cameraControl.setTilt(Properties.Settings.Default.dTilt);
            cameraControl.setExposure(Properties.Settings.Default.dExposure);
        }

        private void MyCapture_OnFrameHeader(Bitmap bitmap)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MyCapture_OnFrameHeader(bitmap)));
                return;
            }

            imgDetection?.Dispose();
            imgDetection = (Image)bitmap.Clone();

            Image oldImage = pictureBox1.Image;
            pictureBox1.Image = (Image)bitmap.Clone();
            oldImage?.Dispose();

            UpdateFrameRate();

            UpdateFrameRate();

            DrawBoxes(pictureBox1.Image, predictions);
            if (!bgObjDetection.IsBusy && bitmap != null && yolo != null)
            {
                bgObjDetection.RunWorkerAsync();
            }

            if (isObjDetect)
            {
                string filename = SaveImagePredic(imgDetection, predictions);
                string filename_master = Guid.NewGuid().ToString() + ".jpg";
                filename_master.Replace("-", "_");
                filename_master = "M_" + filename_master;

                if (filename == string.Empty)
                    return;
                using (Image bmp = Image.FromFile(Path.Combine(Properties.Resources.path_images, modules[0].image)))
                {
                    bmp.Save(Path.Combine(Properties.Resources.path_history, filename_master), ImageFormat.Jpeg);
                }
                pictureBoxDetect.Image?.Dispose();
                pictureBoxDetect.Image = Image.FromFile(Path.Combine(Properties.Resources.path_history, filename));

                history.image_path_master = filename_master;
                history.image_path_result = filename;
                history.result = labelOBJ;

                history.name = txtName.Text;
                history.model = txtModel.Text;
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

                if (renderTable.Status != TaskStatus.Running)
                {
                    renderTable = Task.Run(() =>
                    {
                        RenderTable();
                    });
                }
                isObjDetect = false;
            }
        }

        private void RenderTable()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => RenderTable()));
                return;
            }
            var histories = History.Get();
            if (histories.Count > 0)
            {
                DataTable dt = CreateDataTable();
                PopulateDataTable(dt);
                SetupDataGridView(dt);
                LoadImagesToDataGridView();
            }
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Model", typeof(string));
            dt.Columns.Add("ImagePathMaster", typeof(string));
            dt.Columns.Add("ImagePathResult", typeof(string));
            dt.Columns.Add("Result", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            return dt;
        }

        private void PopulateDataTable(DataTable dt)
        {
            var modules = History.Get();
            int rowNumber = 0;
            foreach (var item in modules)
            {
                dt.Rows.Add(++rowNumber, item.id, item.name, item.model, item.image_path_master, item.image_path_result, item.result, item.updated_at);
            }
        }

        private void SetupDataGridView(DataTable dt)
        {
            // Clear the dataGridView1 before updating
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = dt;

            DataGridViewImageColumn imageColumnMaster = new DataGridViewImageColumn();
            imageColumnMaster.Name = "ImageMaster";
            imageColumnMaster.HeaderText = "ImageMaster";
            imageColumnMaster.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumnMaster.Width = 100;
            dataGridView1.Columns.Insert(5, imageColumnMaster);
            dataGridView1.RowTemplate.Height = 100;
            // Hide the id column and the image path master column
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["ImagePathMaster"].Visible = false;

            // Set the column width of the image path result column
            DataGridViewImageColumn imageColumnResult = new DataGridViewImageColumn();
            imageColumnResult.Name = "ImageResult";
            imageColumnResult.HeaderText = "ImageResult";
            imageColumnResult.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumnResult.Width = 100;
            dataGridView1.Columns.Insert(6, imageColumnResult);
            dataGridView1.RowTemplate.Height = 100;
            // Hide the id column and the image path master column
            dataGridView1.Columns["ImagePathResult"].Visible = false;
            dataGridView1.ClearSelection();

            // Set the column No 10%
            dataGridView1.Columns["No"].Width = (int)(dataGridView1.Width * 0.1);
            dataGridView1.Columns["Date"].Width = (int)(dataGridView1.Width * 0.15);

        }

        private void LoadImagesToDataGridView()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ImagePathMaster"].Value != null)
                    {
                        string imagePath = row.Cells["ImagePathMaster"].Value.ToString();
                        if (File.Exists(Path.Combine(Properties.Resources.path_history, imagePath)))
                        {
                            row.Cells["ImageMaster"].Value = Image.FromFile(Path.Combine(Properties.Resources.path_history, imagePath));
                        }
                    }
                    if (row.Cells["ImagePathResult"].Value != null)
                    {
                        string imagePath = row.Cells["ImagePathResult"].Value.ToString();
                        if (File.Exists(Path.Combine(Properties.Resources.path_history, imagePath)))
                        {
                            row.Cells["ImageResult"].Value = Image.FromFile(Path.Combine(Properties.Resources.path_history, imagePath));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                toolStripStatusError.Text = ex.Message;
                toolStripStatusError.BackColor = Color.Red;
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

                    if (txtModel.Text == string.Empty)
                    {
                        this.ActiveControl = txtModel;
                        txtModel.Focus();

                        throw new Exception("Invalid model");
                    }

                    if (txtName.Text == string.Empty)
                    {
                        this.ActiveControl = txtName;
                        txtName.Focus();

                        throw new Exception("Invalid name!");
                    }

                    btnConnect.Text = "Connecting";
                    pictureBox1.Image?.Dispose();
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

                    if (File.Exists(Path.Combine(Properties.Resources.path_weight, modules[0].path)) && File.Exists(Path.Combine(Properties.Resources.path_images, modules[0].path_label)))
                    {
                        // Read txt file label
                        string[] lines = File.ReadAllLines(Path.Combine(Properties.Resources.path_images, modules[0].path_label));
                        string[] labels = new string[lines.Length];
                        for (int i = 0; i < lines.Length; i++)
                        {
                            labels[i] = lines[i];
                        }
                        // Create YoloV5Predictor                                                
                        yolo = YoloV5Predictor.Create(Path.Combine(Properties.Resources.path_weight, modules[0].path),labels);
                    }
                    else
                    {
                        Debug.WriteLine("File not found");
                        MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                toolStripStatusError.Text = string.Empty;
            }
            catch (Exception ex)
            {
                if (isConnect)
                {
                    myCapture.Stop();
                    btnConnect.Text = "Connect";
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = null;
                    if (this.serialPort != null && this.serialPort.IsOpen)
                    {
                        this.serialPort.Close();
                    }
                }
                isConnect = !isConnect;
                toolStripStatusError.Text = ex.Message;
                toolStripStatusError.ForeColor = Color.Red;
                MessageBox.Show("E02 " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        [DllImport("ole32.dll")]
        private static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);

        private VideoInfoHeader GetHighestResolutionFormat(IBaseFilter captureFilter)
        {
            IAMStreamConfig streamConfig = null;
            VideoInfoHeader maxResolutionFormat = null;
            IPin pin = DsFindPin.ByCategory(captureFilter, PinCategory.Capture, 0);

            if (pin != null)
            {
                streamConfig = pin as IAMStreamConfig;

                if (streamConfig != null)
                {
                    int formatCount;
                    int formatSize;
                    streamConfig.GetNumberOfCapabilities(out formatCount, out formatSize);

                    int maxWidth = 0;
                    int maxHeight = 0;

                    for (int i = 0; i < formatCount; i++)
                    {
                        AMMediaType mediaType = null;
                        VideoStreamConfigCaps caps = new VideoStreamConfigCaps();
                        IntPtr ptrCaps = Marshal.AllocHGlobal(Marshal.SizeOf(caps));
                        Marshal.StructureToPtr(caps, ptrCaps, false);

                        streamConfig.GetStreamCaps(i, out mediaType, ptrCaps);

                        caps = (VideoStreamConfigCaps)Marshal.PtrToStructure(ptrCaps, typeof(VideoStreamConfigCaps));
                        Marshal.FreeHGlobal(ptrCaps);

                        if (mediaType != null && mediaType.formatType == DirectShowLib.FormatType.VideoInfo && mediaType.formatPtr != IntPtr.Zero)
                        {
                            VideoInfoHeader format = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.formatPtr, typeof(VideoInfoHeader));

                            if (format.BmiHeader.Width * format.BmiHeader.Height > maxWidth * maxHeight)
                            {
                                maxWidth = format.BmiHeader.Width;
                                maxHeight = format.BmiHeader.Height;
                                maxResolutionFormat = format;
                            }
                        }

                        DsUtils.FreeAMMediaType(mediaType);
                    }
                }

                Marshal.ReleaseComObject(pin);
            }

            return maxResolutionFormat;
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

                if (!Directory.Exists(Properties.Resources.path_capture))
                    Directory.CreateDirectory(Properties.Resources.path_capture);

                toolStripStatusLabel.Text = filename;
                filename = Path.Combine(Properties.Resources.path_capture, filename);
                imgDetection?.Save(filename, ImageFormat.Jpeg);
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
            #pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            _ = this.Invoke(new EventHandler(dataReceived));
            #pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
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

        private void cbDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            oldDriveIndex = (int)cbDrive.SelectedIndex;
        }

        private void cbBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            oldBaudIndex = (int)cbBaud.SelectedIndex;
        }

        private void cbCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            oldCOMIndex = (int)cbCOM.SelectedIndex;
        }
        private void txtModel_KeyDown(object sender, KeyEventArgs e)
        {
            // If key enter is txtName focus
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = txtName;
                txtName.Focus();
            }
        }
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            // If key enter is txtName focus
            if (e.KeyCode == Keys.Enter)
            {
                btnConnect.PerformClick();
            }
        }
    }
}