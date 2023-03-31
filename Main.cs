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

namespace Object_Detection
{
    public partial class Main : Form
    {
        private readonly BackgroundWorker backgroundObjDetection;
        public readonly TControl cameraControl;
        public readonly TCapture.Capture myCapture;
        public readonly SQliteDataAccess.Module module;
        private readonly SerialPort serialPort;
        public Main()
        {
            InitializeComponent();
            myCapture = new TCapture.Capture();
            myCapture.OnFrameHeader += MyCapture_OnFrameHeader;
            myCapture.OnVideoStarted += MyCapture_OnVideoStarted;
            myCapture.OnError += MyCapture_OnError;
            cameraControl = new TControl();
            module = new SQliteDataAccess.Module();

            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.ErrorReceived += SerialPort_ErrorReceived;
        }

      

        private void Main_Load(object sender, EventArgs e)
        {
            var drive = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

            cbDrive.Items.Clear();
            foreach (DsDevice device in drive)
            {
                cbDrive.Items.Add(device.Name);
            }
            drive.Clear();
            // Select Drive 
            if (cbDrive.Items.Count > 0)
                cbDrive.SelectedIndex = 0;

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
                cameraControl.set(camIndex);
                await openTask;
                btnConnect.Text = "Disconnect";
            }
            else
            {
                myCapture.Stop();
                btnConnect.Text = "Connect";
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = null;
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

                if (!Directory.Exists(Properties.Resources.path_image))
                    Directory.CreateDirectory(Properties.Resources.path_image);

                toolStripStatusLabel.Text = filename;
                filename = Path.Combine(Properties.Resources.path_image, filename);
                pictureBox1.Image?.Save(filename, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }


        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {

        }
    }
}