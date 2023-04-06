namespace Object_Detection
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            uploadModuleToolStripMenuItem = new ToolStripMenuItem();
            listModuleToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            captureToolStripMenuItem = new ToolStripMenuItem();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusSerial = new ToolStripStatusLabel();
            toolStripStatusError = new ToolStripStatusLabel();
            toolStripStatusSerialData = new ToolStripStatusLabel();
            toolStripStatusTime = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            panel2 = new Panel();
            pictureBoxDetect = new PictureBox();
            richTextBox2 = new RichTextBox();
            lbName = new Label();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtModel = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            cbSerial = new CheckBox();
            btnLoading = new Button();
            btnConnect = new Button();
            cbCOM = new ComboBox();
            cbBaud = new ComboBox();
            cbDrive = new ComboBox();
            label2 = new Label();
            contextMenuStripDeleteModule = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDetect).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            contextMenuStripDeleteModule.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, imageToolStripMenuItem, cameraToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1154, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uploadModuleToolStripMenuItem, listModuleToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // uploadModuleToolStripMenuItem
            // 
            uploadModuleToolStripMenuItem.Name = "uploadModuleToolStripMenuItem";
            uploadModuleToolStripMenuItem.Size = new Size(180, 22);
            uploadModuleToolStripMenuItem.Text = "Upload module";
            uploadModuleToolStripMenuItem.Visible = false;
            uploadModuleToolStripMenuItem.Click += uploadModuleToolStripMenuItem_Click;
            // 
            // listModuleToolStripMenuItem
            // 
            listModuleToolStripMenuItem.Image = Properties.Resources.upload;
            listModuleToolStripMenuItem.Name = "listModuleToolStripMenuItem";
            listModuleToolStripMenuItem.Size = new Size(180, 22);
            listModuleToolStripMenuItem.Text = "List module";
            listModuleToolStripMenuItem.Click += listModuleToolStripMenuItem_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { captureToolStripMenuItem });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(52, 20);
            imageToolStripMenuItem.Text = "Image";
            // 
            // captureToolStripMenuItem
            // 
            captureToolStripMenuItem.Image = Properties.Resources.screenshot_32;
            captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            captureToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Z;
            captureToolStripMenuItem.Size = new Size(180, 22);
            captureToolStripMenuItem.Text = "Capture";
            captureToolStripMenuItem.Click += captureToolStripMenuItem_Click;
            // 
            // cameraToolStripMenuItem
            // 
            cameraToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingToolStripMenuItem });
            cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            cameraToolStripMenuItem.Size = new Size(60, 20);
            cameraToolStripMenuItem.Text = "Camera";
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.Image = Properties.Resources.edit_production_order_32;
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(180, 22);
            settingToolStripMenuItem.Text = "Controls";
            settingToolStripMenuItem.Click += settingToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripStatusSerial, toolStripStatusError, toolStripStatusSerialData, toolStripStatusTime });
            statusStrip1.Location = new Point(0, 578);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1154, 24);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(12, 19);
            toolStripStatusLabel.Text = "-";
            // 
            // toolStripStatusSerial
            // 
            toolStripStatusSerial.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusSerial.Name = "toolStripStatusSerial";
            toolStripStatusSerial.Size = new Size(16, 19);
            toolStripStatusSerial.Text = "-";
            // 
            // toolStripStatusError
            // 
            toolStripStatusError.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusError.Name = "toolStripStatusError";
            toolStripStatusError.Size = new Size(16, 19);
            toolStripStatusError.Text = "-";
            // 
            // toolStripStatusSerialData
            // 
            toolStripStatusSerialData.BorderSides = ToolStripStatusLabelBorderSides.Left;
            toolStripStatusSerialData.Name = "toolStripStatusSerialData";
            toolStripStatusSerialData.Size = new Size(16, 19);
            toolStripStatusSerialData.Text = "-";
            // 
            // toolStripStatusTime
            // 
            toolStripStatusTime.Name = "toolStripStatusTime";
            toolStripStatusTime.Size = new Size(12, 19);
            toolStripStatusTime.Text = "-";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Padding = new Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Padding = new Padding(5);
            splitContainer1.Size = new Size(1154, 554);
            splitContainer1.SplitterDistance = 672;
            splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.FixedSingle;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(5, 47);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridView1);
            splitContainer2.Size = new Size(662, 502);
            splitContainer2.SplitterDistance = 365;
            splitContainer2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Location = new Point(6, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(651, 357);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(651, 125);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 192, 128);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(5, 5);
            label1.Name = "label1";
            label1.Size = new Size(662, 42);
            label1.TabIndex = 0;
            label1.Text = "CAMERA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBoxDetect);
            panel2.Controls.Add(richTextBox2);
            panel2.Controls.Add(lbName);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(278, 500);
            panel2.TabIndex = 3;
            // 
            // pictureBoxDetect
            // 
            pictureBoxDetect.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxDetect.Location = new Point(3, 52);
            pictureBoxDetect.Name = "pictureBoxDetect";
            pictureBoxDetect.Size = new Size(266, 282);
            pictureBoxDetect.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxDetect.TabIndex = 6;
            pictureBoxDetect.TabStop = false;
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox2.Location = new Point(3, 351);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(266, 146);
            richTextBox2.TabIndex = 0;
            richTextBox2.Text = "";
            // 
            // lbName
            // 
            lbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbName.BackColor = Color.Yellow;
            lbName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbName.Location = new Point(3, 3);
            lbName.Name = "lbName";
            lbName.Size = new Size(269, 43);
            lbName.TabIndex = 5;
            lbName.Text = "---";
            lbName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtModel);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(cbSerial);
            panel1.Controls.Add(btnLoading);
            panel1.Controls.Add(btnConnect);
            panel1.Controls.Add(cbCOM);
            panel1.Controls.Add(cbBaud);
            panel1.Controls.Add(cbDrive);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(283, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(188, 500);
            panel1.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 276);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 8;
            label7.Text = "COM";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 247);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 8;
            label6.Text = "Baud";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 216);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 8;
            label5.Text = "Drive :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 106);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 8;
            label4.Text = "Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 77);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 8;
            label3.Text = "Model :";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(51, 103);
            txtName.Name = "txtName";
            txtName.Size = new Size(131, 23);
            txtName.TabIndex = 1;
            txtName.KeyDown += txtName_KeyDown;
            // 
            // txtModel
            // 
            txtModel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtModel.Location = new Point(51, 74);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(131, 23);
            txtModel.TabIndex = 0;
            txtModel.KeyDown += txtModel_KeyDown;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.customer;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(51, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 43);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.camera_logo;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(51, 164);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(90, 43);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // cbSerial
            // 
            cbSerial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbSerial.AutoSize = true;
            cbSerial.Checked = true;
            cbSerial.CheckState = CheckState.Checked;
            cbSerial.Location = new Point(67, 302);
            cbSerial.Name = "cbSerial";
            cbSerial.Size = new Size(100, 19);
            cbSerial.TabIndex = 5;
            cbSerial.Text = "Use serial port";
            cbSerial.UseVisualStyleBackColor = true;
            // 
            // btnLoading
            // 
            btnLoading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLoading.BackgroundImage = Properties.Resources._refresh_32;
            btnLoading.BackgroundImageLayout = ImageLayout.Zoom;
            btnLoading.Location = new Point(6, 327);
            btnLoading.Name = "btnLoading";
            btnLoading.Size = new Size(26, 23);
            btnLoading.TabIndex = 3;
            btnLoading.UseVisualStyleBackColor = true;
            btnLoading.Click += loading;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConnect.Location = new Point(51, 327);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(131, 23);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cbCOM
            // 
            cbCOM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCOM.FormattingEnabled = true;
            cbCOM.Location = new Point(51, 273);
            cbCOM.Name = "cbCOM";
            cbCOM.Size = new Size(131, 23);
            cbCOM.TabIndex = 4;
            cbCOM.SelectedIndexChanged += cbCOM_SelectedIndexChanged;
            // 
            // cbBaud
            // 
            cbBaud.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbBaud.FormattingEnabled = true;
            cbBaud.Location = new Point(51, 244);
            cbBaud.Name = "cbBaud";
            cbBaud.Size = new Size(131, 23);
            cbBaud.TabIndex = 3;
            cbBaud.SelectedIndexChanged += cbBaud_SelectedIndexChanged;
            // 
            // cbDrive
            // 
            cbDrive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbDrive.FormattingEnabled = true;
            cbDrive.Location = new Point(51, 213);
            cbDrive.Name = "cbDrive";
            cbDrive.Size = new Size(131, 23);
            cbDrive.TabIndex = 2;
            cbDrive.SelectedIndexChanged += cbDrive_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(255, 192, 128);
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(5, 5);
            label2.Name = "label2";
            label2.Size = new Size(466, 42);
            label2.TabIndex = 1;
            label2.Text = "RESULT";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStripDeleteModule
            // 
            contextMenuStripDeleteModule.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            contextMenuStripDeleteModule.Name = "contextMenuStripDeleteModule";
            contextMenuStripDeleteModule.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.Trash_32;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1154, 602);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Object Detection";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxDetect).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            contextMenuStripDeleteModule.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private SplitContainer splitContainer1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnConnect;
        private ComboBox cbDrive;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem cameraToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem captureToolStripMenuItem;
        private Label label2;
        private Panel panel1;
        private ComboBox cbCOM;
        private ComboBox cbBaud;
        private CheckBox cbSerial;
        private SplitContainer splitContainer2;
        private PictureBox pictureBox2;
        private Panel panel2;
        private ContextMenuStrip contextMenuStripDeleteModule;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Label lbName;
        private ToolStripStatusLabel toolStripStatusSerial;
        private ToolStripStatusLabel toolStripStatusError;
        private ToolStripStatusLabel toolStripStatusSerialData;
        private ToolStripMenuItem uploadModuleToolStripMenuItem;
        private ToolStripMenuItem listModuleToolStripMenuItem;
        private RichTextBox richTextBox2;
        private PictureBox pictureBoxDetect;
        private DataGridView dataGridView1;
        private TextBox txtModel;
        private TextBox txtName;
        private PictureBox pictureBox3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnLoading;
        private ToolStripStatusLabel toolStripStatusTime;
    }
}