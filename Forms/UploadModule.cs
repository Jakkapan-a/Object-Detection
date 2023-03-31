using Object_Detection.SQliteDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Object_Detection.Forms
{
    public partial class UploadModule : Form
    {
        public UploadModule()
        {
            InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
        }
        private string filename = string.Empty;
        private string path = string.Empty;
        private void UploadModule_Load(object sender, EventArgs e)
        {
  

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            // Open File Dialog onnx file only
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "onnx files (*.onnx)|*.onnx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                txtPath.Text = filename;
            }
        }
        private string newFilename = string.Empty;
        private string newPath = string.Empty;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Upload file to database
            if (txtPath.Text != string.Empty)
            {
                // Copy file to path
                newFilename = Guid.NewGuid().ToString() + txtName.Text + ".onnx";

                if(!Directory.Exists(Properties.Resources.path_weight))
                {
                    Directory.CreateDirectory(Properties.Resources.path_weight);
                }
                newPath = System.IO.Path.Combine(Properties.Resources.path_weight, newFilename);
                // Show progress bar
                progressBar1.Value = 0;
                progressBar1.Visible = true;

                var args = new CopyFileArguments { SourcePath = filename, DestinationPath = newPath };
                bgWorker.RunWorkerAsync(args);
            }
            else
            {
                MessageBox.Show("Please select file to upload");
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var args = e.Argument as CopyFileArguments;
            CopyFileWithProgress(args.SourcePath, args.DestinationPath, worker);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;

            var modules = Module.Get();

            // Delete old file
            foreach (var item in modules)
            {
                // check if file exist
                if (File.Exists(item.path))
                {
                    File.Delete(item.path);
                }
                item.Delete();
            }

            var module = new Module();
            module.name = txtName.Text;
            module.path = newPath;
            module.filename = newFilename;
            module.Save();

        }
        private void CopyFileWithProgress(string sourcePath, string destinationPath, BackgroundWorker worker)
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
            int bytesRead;
            long totalBytesRead = 0;

            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                long fileSize = sourceStream.Length;

                using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        // Use Buffer.BlockCopy to ensure all bytes are copied
                        byte[] tempBuffer = new byte[bytesRead];
                        Buffer.BlockCopy(buffer, 0, tempBuffer, 0, bytesRead);
                        destinationStream.Write(tempBuffer, 0, bytesRead);

                        totalBytesRead += bytesRead;

                        int progressPercentage = (int)(((double)totalBytesRead / fileSize) * 100);
                        worker.ReportProgress(progressPercentage);
                    }
                }
            }
        }
    }
    public class CopyFileArguments
    {
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
    }
}
