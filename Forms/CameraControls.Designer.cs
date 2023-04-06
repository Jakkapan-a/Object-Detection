namespace Object_Detection.Forms
{
    partial class CameraControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraControls));
            label1 = new Label();
            btSave = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            nExposure = new NumericUpDown();
            nTilt = new NumericUpDown();
            nPan = new NumericUpDown();
            nZoom = new NumericUpDown();
            tExposure = new TrackBar();
            tTilt = new TrackBar();
            tPan = new TrackBar();
            tZoom = new TrackBar();
            tFocus = new TrackBar();
            nFocus = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nExposure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nTilt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nPan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nZoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tExposure).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tTilt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tPan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tZoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tFocus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nFocus).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.FromArgb(255, 192, 128);
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 18);
            label1.Name = "label1";
            label1.Size = new Size(370, 50);
            label1.TabIndex = 1;
            label1.Text = "CAMERA CONTROLS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btSave
            // 
            btSave.Location = new Point(293, 349);
            btSave.Name = "btSave";
            btSave.Size = new Size(75, 23);
            btSave.TabIndex = 18;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 309);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 13;
            label5.Text = "Exposure";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 258);
            label4.Name = "label4";
            label4.Size = new Size(23, 15);
            label4.TabIndex = 14;
            label4.Text = "Tilt";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 207);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 15;
            label3.Text = "Pan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 154);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 16;
            label2.Text = "Zoom";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 106);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 17;
            label6.Text = "Focus";
            // 
            // nExposure
            // 
            nExposure.Location = new Point(304, 305);
            nExposure.Name = "nExposure";
            nExposure.Size = new Size(64, 23);
            nExposure.TabIndex = 9;
            nExposure.ValueChanged += Controls_ValueChange;
            // 
            // nTilt
            // 
            nTilt.Location = new Point(304, 254);
            nTilt.Name = "nTilt";
            nTilt.Size = new Size(64, 23);
            nTilt.TabIndex = 10;
            nTilt.ValueChanged += Controls_ValueChange;
            // 
            // nPan
            // 
            nPan.Location = new Point(304, 203);
            nPan.Name = "nPan";
            nPan.Size = new Size(64, 23);
            nPan.TabIndex = 11;
            nPan.ValueChanged += Controls_ValueChange;
            // 
            // nZoom
            // 
            nZoom.Location = new Point(304, 152);
            nZoom.Name = "nZoom";
            nZoom.Size = new Size(64, 23);
            nZoom.TabIndex = 20;
            nZoom.ValueChanged += Controls_ValueChange;
            // 
            // tExposure
            // 
            tExposure.Location = new Point(97, 307);
            tExposure.Name = "tExposure";
            tExposure.Size = new Size(201, 45);
            tExposure.TabIndex = 4;
            tExposure.ValueChanged += Controls_ValueChange;
            // 
            // tTilt
            // 
            tTilt.Location = new Point(97, 256);
            tTilt.Name = "tTilt";
            tTilt.Size = new Size(201, 45);
            tTilt.TabIndex = 5;
            tTilt.ValueChanged += Controls_ValueChange;
            // 
            // tPan
            // 
            tPan.Location = new Point(97, 205);
            tPan.Name = "tPan";
            tPan.Size = new Size(201, 45);
            tPan.TabIndex = 6;
            tPan.ValueChanged += Controls_ValueChange;
            // 
            // tZoom
            // 
            tZoom.Location = new Point(97, 154);
            tZoom.Name = "tZoom";
            tZoom.Size = new Size(201, 45);
            tZoom.TabIndex = 7;
            tZoom.ValueChanged += Controls_ValueChange;
            // 
            // tFocus
            // 
            tFocus.Location = new Point(97, 103);
            tFocus.Name = "tFocus";
            tFocus.Size = new Size(201, 45);
            tFocus.TabIndex = 8;
            tFocus.ValueChanged += Controls_ValueChange;
            // 
            // nFocus
            // 
            nFocus.Location = new Point(304, 103);
            nFocus.Name = "nFocus";
            nFocus.Size = new Size(64, 23);
            nFocus.TabIndex = 19;
            nFocus.ValueChanged += Controls_ValueChange;
            // 
            // CameraControls
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 388);
            Controls.Add(nFocus);
            Controls.Add(btSave);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(nExposure);
            Controls.Add(nTilt);
            Controls.Add(nPan);
            Controls.Add(nZoom);
            Controls.Add(tExposure);
            Controls.Add(tTilt);
            Controls.Add(tPan);
            Controls.Add(tZoom);
            Controls.Add(tFocus);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CameraControls";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CameraControls";
            Load += CameraControls_Load;
            ((System.ComponentModel.ISupportInitialize)nExposure).EndInit();
            ((System.ComponentModel.ISupportInitialize)nTilt).EndInit();
            ((System.ComponentModel.ISupportInitialize)nPan).EndInit();
            ((System.ComponentModel.ISupportInitialize)nZoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)tExposure).EndInit();
            ((System.ComponentModel.ISupportInitialize)tTilt).EndInit();
            ((System.ComponentModel.ISupportInitialize)tPan).EndInit();
            ((System.ComponentModel.ISupportInitialize)tZoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)tFocus).EndInit();
            ((System.ComponentModel.ISupportInitialize)nFocus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btSave;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label6;
        private NumericUpDown nExposure;
        private NumericUpDown nTilt;
        private NumericUpDown nPan;
        private NumericUpDown nZoom;
        private TrackBar tExposure;
        private TrackBar tTilt;
        private TrackBar tPan;
        private TrackBar tZoom;
        private TrackBar tFocus;
        private NumericUpDown nFocus;
    }
}