using Object_Detection.Extentions;
using Object_Detection.SQliteDataAccess;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Object_Detection.Forms
{
    public partial class ListModules : Form
    {

        private int id = -1;
        private string pathImage = string.Empty;
        private string newImageName = string.Empty;
        private string pathModule = string.Empty;
        private string newModuleName = string.Empty;

        private readonly BackgroundWorker bgWorker;
        public ListModules()
        {
            InitializeComponent();
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.WorkerReportsProgress = true;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;

        }

        private void BgWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBarUpload1.Value = e.ProgressPercentage;
        }

        private void BgWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                // Handle the error that occurred during background operation
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Handle the case when operation was cancelled
                MessageBox.Show("Operation cancelled by the user.");
            }
            else
            {
                // Handle the case when operation completed successfully
                MessageBox.Show("Operation completed successfully.");
            }

            if (id == -1)
            {
                var module = new Module()
                {
                    name = txtName.Text,
                    filename = newModuleName,
                    image = newImageName,

                };
                module.status = cbActive.Checked ? 1 : 0;
                module.Save();
            }
            else
            {

            }
            // Visible progress bar
            toolStripProgressBarUpload1.Visible = false;
            toolStripProgressBarUpload2.Visible = false;
        }

        private void BgWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            newModuleName = Guid.NewGuid().ToString() + txtName.Text + ".onnx";
            newImageName = Guid.NewGuid().ToString() + txtName.Text + ".jpg";

            // Use the correct paths for the source files
            string sourceModulePath = pathModule;
            string sourceImagePath = pathImage;

            string destinationModulePath = Path.Combine(Properties.Resources.path_weight, newModuleName);
            string destinationImagePath = Path.Combine(Properties.Resources.path_images, newImageName);

            var argsModule = new CopyFileArguments { SourcePath = sourceModulePath, DestinationPath = destinationModulePath };
            var argsImage = new CopyFileArguments { SourcePath = sourceImagePath, DestinationPath = destinationImagePath };

            // Create two instances of BackgroundWorker
            var worker1 = new BackgroundWorker { WorkerReportsProgress = true };
            var worker2 = new BackgroundWorker { WorkerReportsProgress = true };

            // Update progress bars separately
            worker1.ProgressChanged += (s, e) => Invoke(new Action(() => toolStripProgressBarUpload1.Value = e.ProgressPercentage));
            worker2.ProgressChanged += (s, e) => Invoke(new Action(() => toolStripProgressBarUpload2.Value = e.ProgressPercentage));


            // Assign event handlers
            worker1.DoWork += (s, e) => CopyFile.CopyFileWithProgress(argsModule.SourcePath, argsModule.DestinationPath, worker1);
            worker2.DoWork += (s, e) => CopyFile.CopyFileWithProgress(argsImage.SourcePath, argsImage.DestinationPath, worker2);

            // Run the workers
            worker1.RunWorkerAsync();
            worker2.RunWorkerAsync();

            // Wait for both workers to complete
            while (worker1.IsBusy || worker2.IsBusy)
            {
                Thread.Sleep(100); // Sleep for a short period to prevent blocking the UI
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            toolStripProgressBarUpload1.Visible = true;
            toolStripProgressBarUpload1.Value = 0;

            toolStripProgressBarUpload2.Visible = true;
            toolStripProgressBarUpload2.Value = 0;

            if (!Directory.Exists(Properties.Resources.path_weight))
            {
                Directory.CreateDirectory(Properties.Resources.path_weight);
            }
            if (!Directory.Exists(Properties.Resources.path_images))
            {
                Directory.CreateDirectory(Properties.Resources.path_images);
            }

            // Validate txtName, txtModule, txtImage
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter name of module", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtModule.Text))
            {
                MessageBox.Show("Please enter path of module", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtImage.Text))
            {
                MessageBox.Show("Please enter path of image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check file exists or not
            if (!File.Exists(pathModule))
            {
                MessageBox.Show("Module file not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(pathImage))
            {
                MessageBox.Show("Image file not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check file is valid or not
            if (!pathModule.EndsWith(".onnx"))
            {
                MessageBox.Show("Module file is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!pathImage.EndsWith(".jpg") && !pathImage.EndsWith(".jpeg") && !pathImage.EndsWith(".png"))
            {
                MessageBox.Show("Image file is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (id == -1)
            {
                // Check bgWorker is running or not
                if (bgWorker.IsBusy)
                {
                    MessageBox.Show("Please wait for the current process to complete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Save new module
                bgWorker.RunWorkerAsync();
            }
            else
            {
                // Update module
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            id = -1;
            btnSave.Text = "Save";
            txtImage.Text = string.Empty;
            txtModule.Text = string.Empty;
            txtName.Text = string.Empty;
            pictureBoxTemp.Image?.Dispose();

        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "onnx files (*.onnx)|*.onnx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathModule = openFileDialog.FileName;
                txtModule.Text = pathModule;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathImage = openFileDialog.FileName;
                txtImage.Text = pathImage;
                pictureBoxTemp.Image = Image.FromFile(pathImage);
            }
        }
    }
}
