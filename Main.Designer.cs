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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            cameraToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            btnConnect = new Button();
            cbDrive = new ComboBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            captureToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            settingToolStripMenuItem.Size = new Size(119, 22);
            settingToolStripMenuItem.Text = "Controls";
            settingToolStripMenuItem.Click += settingToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(12, 17);
            toolStripStatusLabel.Text = "-";
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
            splitContainer1.Panel1.Controls.Add(btnConnect);
            splitContainer1.Panel1.Controls.Add(cbDrive);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Size = new Size(800, 404);
            splitContainer1.SplitterDistance = 370;
            splitContainer1.TabIndex = 2;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConnect.Location = new Point(277, 371);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(88, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cbDrive
            // 
            cbDrive.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbDrive.FormattingEnabled = true;
            cbDrive.Location = new Point(115, 372);
            cbDrive.Name = "cbDrive";
            cbDrive.Size = new Size(156, 23);
            cbDrive.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Location = new Point(12, 58);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(353, 302);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.FromArgb(255, 192, 128);
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(353, 42);
            label1.TabIndex = 0;
            label1.Text = "CAMERA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // captureToolStripMenuItem
            // 
            captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            captureToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Z;
            captureToolStripMenuItem.Size = new Size(180, 22);
            captureToolStripMenuItem.Text = "Capture";
            captureToolStripMenuItem.Click += captureToolStripMenuItem_Click;
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
            Text = "Form1";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
    }
}