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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            captureToolStripMenuItem = new ToolStripMenuItem();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusSerial = new ToolStripStatusLabel();
            toolStripStatusError = new ToolStripStatusLabel();
            toolStripStatusSerialData = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            panel2 = new Panel();
            lbName = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            cbSerial = new CheckBox();
            btnConnect = new Button();
            cbCOM = new ComboBox();
            cbBaud = new ComboBox();
            cbDrive = new ComboBox();
            label2 = new Label();
            contextMenuStripDeleteModule = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            uploadModuleToolStripMenuItem = new ToolStripMenuItem();
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
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            contextMenuStripDeleteModule.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, imageToolStripMenuItem, cameraToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uploadModuleToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
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
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(180, 22);
            settingToolStripMenuItem.Text = "Controls";
            settingToolStripMenuItem.Click += settingToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripStatusSerial, toolStripStatusError, toolStripStatusSerialData });
            statusStrip1.Location = new Point(0, 426);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 24);
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
            splitContainer1.Size = new Size(800, 402);
            splitContainer1.SplitterDistance = 370;
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
            splitContainer2.Panel2.Controls.Add(richTextBox1);
            splitContainer2.Size = new Size(360, 350);
            splitContainer2.SplitterDistance = 237;
            splitContainer2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Location = new Point(6, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(349, 229);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(3, 8);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(352, 96);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 192, 128);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(5, 5);
            label1.Name = "label1";
            label1.Size = new Size(360, 42);
            label1.TabIndex = 0;
            label1.Text = "CAMERA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(lbName);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(5, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(241, 348);
            panel2.TabIndex = 3;
            // 
            // lbName
            // 
            lbName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbName.BackColor = Color.Yellow;
            lbName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbName.Location = new Point(3, 3);
            lbName.Name = "lbName";
            lbName.Size = new Size(232, 43);
            lbName.TabIndex = 5;
            lbName.Text = "---";
            lbName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Location = new Point(3, 52);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(232, 293);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.Resize += flowLayoutPanel1_Resize;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(cbSerial);
            panel1.Controls.Add(btnConnect);
            panel1.Controls.Add(cbCOM);
            panel1.Controls.Add(cbBaud);
            panel1.Controls.Add(cbDrive);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(246, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 348);
            panel1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.camera_logo;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(51, 3);
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
            cbSerial.Location = new Point(67, 141);
            cbSerial.Name = "cbSerial";
            cbSerial.Size = new Size(100, 19);
            cbSerial.TabIndex = 4;
            cbSerial.Text = "Use serial port";
            cbSerial.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConnect.Location = new Point(11, 166);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(156, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cbCOM
            // 
            cbCOM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCOM.FormattingEnabled = true;
            cbCOM.Location = new Point(11, 112);
            cbCOM.Name = "cbCOM";
            cbCOM.Size = new Size(156, 23);
            cbCOM.TabIndex = 2;
            // 
            // cbBaud
            // 
            cbBaud.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbBaud.FormattingEnabled = true;
            cbBaud.Location = new Point(11, 83);
            cbBaud.Name = "cbBaud";
            cbBaud.Size = new Size(156, 23);
            cbBaud.TabIndex = 2;
            // 
            // cbDrive
            // 
            cbDrive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbDrive.FormattingEnabled = true;
            cbDrive.Location = new Point(11, 52);
            cbDrive.Name = "cbDrive";
            cbDrive.Size = new Size(156, 23);
            cbDrive.TabIndex = 2;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(255, 192, 128);
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(5, 5);
            label2.Name = "label2";
            label2.Size = new Size(414, 42);
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
            // uploadModuleToolStripMenuItem
            // 
            uploadModuleToolStripMenuItem.Name = "uploadModuleToolStripMenuItem";
            uploadModuleToolStripMenuItem.Size = new Size(180, 22);
            uploadModuleToolStripMenuItem.Text = "Upload module";
            uploadModuleToolStripMenuItem.Click += uploadModuleToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
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
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private RichTextBox richTextBox1;
        private PictureBox pictureBox2;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private ContextMenuStrip contextMenuStripDeleteModule;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Label lbName;
        private ToolStripStatusLabel toolStripStatusSerial;
        private ToolStripStatusLabel toolStripStatusError;
        private ToolStripStatusLabel toolStripStatusSerialData;
        private ToolStripMenuItem uploadModuleToolStripMenuItem;
    }
}