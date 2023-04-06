namespace Object_Detection.Forms
{
    partial class ListModules
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListModules));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelId = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripProgressBarUpload1 = new ToolStripProgressBar();
            toolStripProgressBarUpload2 = new ToolStripProgressBar();
            btnSave = new Button();
            txtModule = new TextBox();
            btnModule = new Button();
            btnImage = new Button();
            txtImage = new TextBox();
            txtName = new TextBox();
            panel1 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            cbActive = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBoxTemp = new PictureBox();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            btnClear = new Button();
            dataGridView1 = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            label6 = new Label();
            txtLabel = new TextBox();
            btnLabel = new Button();
            label7 = new Label();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTemp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelId, toolStripStatusLabel2, toolStripProgressBarUpload1, toolStripProgressBarUpload2 });
            statusStrip1.Location = new Point(0, 489);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(841, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelId
            // 
            toolStripStatusLabelId.Name = "toolStripStatusLabelId";
            toolStripStatusLabelId.Size = new Size(118, 17);
            toolStripStatusLabelId.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripProgressBarUpload1
            // 
            toolStripProgressBarUpload1.Name = "toolStripProgressBarUpload1";
            toolStripProgressBarUpload1.Size = new Size(100, 16);
            toolStripProgressBarUpload1.Visible = false;
            // 
            // toolStripProgressBarUpload2
            // 
            toolStripProgressBarUpload2.Name = "toolStripProgressBarUpload2";
            toolStripProgressBarUpload2.Size = new Size(100, 16);
            toolStripProgressBarUpload2.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(204, 380);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtModule
            // 
            txtModule.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtModule.Location = new Point(75, 156);
            txtModule.Name = "txtModule";
            txtModule.Size = new Size(169, 23);
            txtModule.TabIndex = 0;
            // 
            // btnModule
            // 
            btnModule.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnModule.Location = new Point(252, 155);
            btnModule.Name = "btnModule";
            btnModule.Size = new Size(27, 23);
            btnModule.TabIndex = 1;
            btnModule.Text = "...";
            btnModule.UseVisualStyleBackColor = true;
            btnModule.Click += btnModule_Click;
            // 
            // btnImage
            // 
            btnImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnImage.Location = new Point(252, 231);
            btnImage.Name = "btnImage";
            btnImage.Size = new Size(27, 23);
            btnImage.TabIndex = 1;
            btnImage.Text = "...";
            btnImage.UseVisualStyleBackColor = true;
            btnImage.Click += btnImage_Click;
            // 
            // txtImage
            // 
            txtImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtImage.Location = new Point(75, 231);
            txtImage.Name = "txtImage";
            txtImage.Size = new Size(169, 23);
            txtImage.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(75, 126);
            txtName.Name = "txtName";
            txtName.Size = new Size(204, 23);
            txtName.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(841, 80);
            panel1.TabIndex = 3;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(12, 18);
            label5.Name = "label5";
            label5.Size = new Size(817, 44);
            label5.TabIndex = 0;
            label5.Text = "List Modules";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cbActive);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBoxTemp);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtName);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnModule);
            panel2.Controls.Add(txtModule);
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnLabel);
            panel2.Controls.Add(btnImage);
            panel2.Controls.Add(txtLabel);
            panel2.Controls.Add(txtImage);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(548, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(293, 409);
            panel2.TabIndex = 4;
            // 
            // cbActive
            // 
            cbActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbActive.AutoSize = true;
            cbActive.Checked = true;
            cbActive.CheckState = CheckState.Checked;
            cbActive.Location = new Point(185, 355);
            cbActive.Name = "cbActive";
            cbActive.Size = new Size(59, 19);
            cbActive.TabIndex = 5;
            cbActive.Text = "Active";
            cbActive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 235);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 4;
            label3.Text = "Image";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 160);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 4;
            label2.Text = "Module";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 131);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 4;
            label1.Text = "Name";
            // 
            // pictureBoxTemp
            // 
            pictureBoxTemp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxTemp.BackColor = SystemColors.Control;
            pictureBoxTemp.Location = new Point(75, 258);
            pictureBoxTemp.Name = "pictureBoxTemp";
            pictureBoxTemp.Size = new Size(169, 91);
            pictureBoxTemp.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxTemp.TabIndex = 3;
            pictureBoxTemp.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.ONNX_logo_main;
            pictureBox1.Location = new Point(75, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(169, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(182, 183);
            label4.Name = "label4";
            label4.Size = new Size(99, 13);
            label4.TabIndex = 3;
            label4.Text = "Use only onnx file";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.Location = new Point(3, 383);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.Location = new Point(9, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(533, 377);
            dataGridView1.TabIndex = 5;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.Trash_32;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            label6.Location = new Point(9, 83);
            label6.Name = "label6";
            label6.Size = new Size(301, 21);
            label6.TabIndex = 0;
            label6.Text = "Table";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLabel
            // 
            txtLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLabel.Location = new Point(75, 202);
            txtLabel.Name = "txtLabel";
            txtLabel.Size = new Size(169, 23);
            txtLabel.TabIndex = 0;
            // 
            // btnLabel
            // 
            btnLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLabel.Location = new Point(252, 202);
            btnLabel.Name = "btnLabel";
            btnLabel.Size = new Size(27, 23);
            btnLabel.TabIndex = 1;
            btnLabel.Text = "...";
            btnLabel.UseVisualStyleBackColor = true;
            btnLabel.Click += btnImage_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 206);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 4;
            label7.Text = "Label";
            // 
            // ListModules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 511);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListModules";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListModules";
            Load += ListModules_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTemp).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelId;
        private Button btnSave;
        private TextBox txtModule;
        private Button btnModule;
        private Button btnImage;
        private TextBox txtImage;
        private TextBox txtName;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBoxTemp;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label6;
        private Button btnClear;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar toolStripProgressBarUpload1;
        private CheckBox cbActive;
        private ToolStripProgressBar toolStripProgressBarUpload2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Label label7;
        private Button btnLabel;
        private TextBox txtLabel;
    }
}