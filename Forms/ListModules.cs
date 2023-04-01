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
using System.Windows.Forms.VisualStyles;
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
            if (id == -1)
            {
                var module = new Module()
                {
                    name = txtName.Text,
                    path = newModuleName,
                    image = newImageName,
                };
                module.status = cbActive.Checked ? 1 : 0;
                module.Save();
            }
            else
            {
                var module = Module.Get(id).FirstOrDefault();
                module.name = txtName.Text;
                if (!string.IsNullOrEmpty(newModuleName))
                    module.path = newModuleName;
                if (!string.IsNullOrEmpty(newImageName))
                    module.image = newImageName;

                module.status = cbActive.Checked ? 1 : 0;

                module.Update();
            }
            // Visible progress bar
            toolStripProgressBarUpload1.Visible = false;
            toolStripProgressBarUpload2.Visible = false;

            RenderData();

            btnClear.PerformClick();

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
        }

        private void BgWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            if (id == -1)
            {
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
            else
            {
                newModuleName = string.Empty;
                newImageName = string.Empty;
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

            // Check bgWorker is running or not
            if (bgWorker.IsBusy)
            {
                MessageBox.Show("Please wait for the current process to complete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Save new module
            bgWorker.RunWorkerAsync();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            id = -1;
            btnSave.Text = "Save";
            txtImage.Text = string.Empty;
            txtModule.Text = string.Empty;
            txtName.Text = string.Empty;
            pictureBoxTemp.Image?.Dispose();
            pictureBoxTemp.Image = null;

            toolStripStatusLabelId.Text = "ID :" + id;

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

        private void RenderData()
        {
            DataTable dt = CreateDataTable();

            PopulateDataTable(dt);

            SetupDataGridView(dt);

            LoadImagesToDataGridView();
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("ONNX", typeof(string));
            dt.Columns.Add("ImagePath", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            return dt;
        }

        private void PopulateDataTable(DataTable dt)
        {
            var modules = Module.Get();
            int rowNumber = 0;
            foreach (var item in modules)
            {
                dt.Rows.Add(++rowNumber, item.id, item.name, item.path, item.image, item.updated_at);
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

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Image";
            imageColumn.HeaderText = "Image";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumn.Width = 100;
            dataGridView1.Columns.Insert(4, imageColumn);
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.Columns["ImagePath"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
            
            dataGridView1.Columns["No"].Width = (int)(dataGridView1.Width * 0.1);
            dataGridView1.Columns["Date"].Width = (int)(dataGridView1.Width * 0.15);
            dataGridView1.ClearSelection();
        }

        private void LoadImagesToDataGridView()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Image"].Value = Image.FromFile(Path.Combine(Properties.Resources.path_images, dataGridView1.Rows[i].Cells["ImagePath"].Value.ToString()));
                dataGridView1.Rows[i].Height = 100;
            }
        }
        private bool loaded = false;
        private void ListModules_Load(object sender, EventArgs e)
        {
            RenderData();
            loaded = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!loaded)
            {
                return;
            }
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Get the index of the selected row
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Get the DataGridViewRow object at the specified index
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                // Get the values from the selected row
                id = (int)selectedRow.Cells["id"].Value;

                string imagePath = Convert.ToString(selectedRow.Cells["ImagePath"].Value);
                string fullPathToImage = Path.Combine(Properties.Resources.path_images, imagePath);
                pictureBoxTemp.Image?.Dispose();
                pictureBoxTemp.Image = Image.FromFile(fullPathToImage);
                txtImage.Text = fullPathToImage;
                pathImage = fullPathToImage;

                string onnxPath = Convert.ToString(selectedRow.Cells["ONNX"].Value);
                string fullPathToModule = Path.Combine(Properties.Resources.path_weight, onnxPath);
                txtModule.Text = fullPathToModule;
                pathModule = fullPathToModule;

                txtName.Text = Convert.ToString(selectedRow.Cells["Name"].Value);
                btnSave.Text = "Update";

                toolStripStatusLabelId.Text = "ID :" + id;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var module = Module.Get(id).FirstOrDefault();
            module.Delete();
            RenderData();
        }
    }
}
