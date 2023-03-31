namespace Object_Detection.Forms
{
    partial class UploadModule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtPath = new TextBox();
            btnPath = new Button();
            btnUpload = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            bgWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(58, 86);
            txtName.Name = "txtName";
            txtName.Size = new Size(206, 23);
            txtName.TabIndex = 0;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(58, 115);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(171, 23);
            txtPath.TabIndex = 0;
            // 
            // btnPath
            // 
            btnPath.Location = new Point(235, 115);
            btnPath.Name = "btnPath";
            btnPath.Size = new Size(29, 23);
            btnPath.TabIndex = 1;
            btnPath.Text = "...";
            btnPath.UseVisualStyleBackColor = true;
            btnPath.Click += btnPath_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(187, 164);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(79, 23);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 89);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 118);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 3;
            label3.Text = "Path";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(162, 141);
            label4.Name = "label4";
            label4.Size = new Size(99, 13);
            label4.TabIndex = 3;
            label4.Text = "Use only onnx file";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ONNX_logo_main;
            pictureBox1.Location = new Point(58, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(11, 167);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(170, 20);
            progressBar1.TabIndex = 5;
            progressBar1.Visible = false;
            // 
            // bgWorker
            // 
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            // 
            // UploadModule
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 197);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(btnUpload);
            Controls.Add(btnPath);
            Controls.Add(txtPath);
            Controls.Add(txtName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(293, 236);
            MinimumSize = new Size(293, 236);
            Name = "UploadModule";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UploadModule";
            Load += UploadModule_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtPath;
        private Button btnPath;
        private Button btnUpload;
        private Label label1;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}