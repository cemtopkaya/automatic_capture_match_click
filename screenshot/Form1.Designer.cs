namespace screenshot
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.cbPatternPosition = new System.Windows.Forms.CheckBox();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.pbMaster = new System.Windows.Forms.PictureBox();
            this.pbLastCaptured = new System.Windows.Forms.PictureBox();
            this.btnCaptureMasterPattern = new System.Windows.Forms.Button();
            this.btnCaptureInstantPattern = new System.Windows.Forms.Button();
            this.btnHash = new System.Windows.Forms.Button();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.cbOtomatik = new System.Windows.Forms.CheckBox();
            this.timerAuto = new System.Windows.Forms.Timer(this.components);
            this.txtClickY = new System.Windows.Forms.TextBox();
            this.txtClickX = new System.Windows.Forms.TextBox();
            this.cbClickPosition = new System.Windows.Forms.CheckBox();
            this.lblWindow = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.cbProcs = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastCaptured)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPatternPosition
            // 
            this.cbPatternPosition.AutoSize = true;
            this.cbPatternPosition.Location = new System.Drawing.Point(12, 51);
            this.cbPatternPosition.Name = "cbPatternPosition";
            this.cbPatternPosition.Size = new System.Drawing.Size(120, 17);
            this.cbPatternPosition.TabIndex = 0;
            this.cbPatternPosition.Text = "İzlenecek Alanı Seç";
            this.cbPatternPosition.UseVisualStyleBackColor = true;
            this.cbPatternPosition.CheckedChanged += new System.EventHandler(this.cbPatternPosition_CheckedChanged);
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(138, 49);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(39, 20);
            this.txtX1.TabIndex = 1;
            this.txtX1.Text = "-1899";
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(182, 49);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(36, 20);
            this.txtY1.TabIndex = 2;
            this.txtY1.Text = "953";
            // 
            // pbMaster
            // 
            this.pbMaster.Location = new System.Drawing.Point(12, 129);
            this.pbMaster.Name = "pbMaster";
            this.pbMaster.Size = new System.Drawing.Size(445, 50);
            this.pbMaster.TabIndex = 3;
            this.pbMaster.TabStop = false;
            // 
            // pbLastCaptured
            // 
            this.pbLastCaptured.Location = new System.Drawing.Point(12, 185);
            this.pbLastCaptured.Name = "pbLastCaptured";
            this.pbLastCaptured.Size = new System.Drawing.Size(445, 50);
            this.pbLastCaptured.TabIndex = 4;
            this.pbLastCaptured.TabStop = false;
            // 
            // btnCaptureMasterPattern
            // 
            this.btnCaptureMasterPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaptureMasterPattern.Location = new System.Drawing.Point(309, 48);
            this.btnCaptureMasterPattern.Name = "btnCaptureMasterPattern";
            this.btnCaptureMasterPattern.Size = new System.Drawing.Size(148, 23);
            this.btnCaptureMasterPattern.TabIndex = 5;
            this.btnCaptureMasterPattern.Text = "Deseni Yakala";
            this.btnCaptureMasterPattern.UseVisualStyleBackColor = true;
            this.btnCaptureMasterPattern.Click += new System.EventHandler(this.btnYakala_Click);
            // 
            // btnCaptureInstantPattern
            // 
            this.btnCaptureInstantPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaptureInstantPattern.Location = new System.Drawing.Point(309, 74);
            this.btnCaptureInstantPattern.Name = "btnCaptureInstantPattern";
            this.btnCaptureInstantPattern.Size = new System.Drawing.Size(148, 23);
            this.btnCaptureInstantPattern.TabIndex = 6;
            this.btnCaptureInstantPattern.Text = "Anlık Yakala";
            this.btnCaptureInstantPattern.UseVisualStyleBackColor = true;
            this.btnCaptureInstantPattern.Click += new System.EventHandler(this.btnCaptureInstantPattern_Click);
            // 
            // btnHash
            // 
            this.btnHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHash.Location = new System.Drawing.Point(288, 100);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(169, 23);
            this.btnHash.TabIndex = 7;
            this.btnHash.Text = "Kıyasla";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(137, 100);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(45, 20);
            this.txtInterval.TabIndex = 8;
            this.txtInterval.Text = "5000";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(12, 105);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(117, 13);
            this.lblInterval.TabIndex = 9;
            this.lblInterval.Text = "Otomatik Kontrol Süresi";
            // 
            // cbOtomatik
            // 
            this.cbOtomatik.AutoSize = true;
            this.cbOtomatik.Location = new System.Drawing.Point(190, 103);
            this.cbOtomatik.Name = "cbOtomatik";
            this.cbOtomatik.Size = new System.Drawing.Size(87, 17);
            this.cbOtomatik.TabIndex = 10;
            this.cbOtomatik.Text = "Otomatik İzle";
            this.cbOtomatik.UseVisualStyleBackColor = true;
            this.cbOtomatik.CheckedChanged += new System.EventHandler(this.cbOtomatik_CheckedChanged);
            // 
            // timerAuto
            // 
            this.timerAuto.Tick += new System.EventHandler(this.timerAuto_Tick);
            // 
            // txtClickY
            // 
            this.txtClickY.Location = new System.Drawing.Point(215, 75);
            this.txtClickY.Name = "txtClickY";
            this.txtClickY.Size = new System.Drawing.Size(45, 20);
            this.txtClickY.TabIndex = 13;
            this.txtClickY.Text = "957";
            // 
            // txtClickX
            // 
            this.txtClickX.Location = new System.Drawing.Point(161, 75);
            this.txtClickX.Name = "txtClickX";
            this.txtClickX.Size = new System.Drawing.Size(48, 20);
            this.txtClickX.TabIndex = 12;
            this.txtClickX.Text = "-1595";
            // 
            // cbClickPosition
            // 
            this.cbClickPosition.AutoSize = true;
            this.cbClickPosition.Location = new System.Drawing.Point(12, 77);
            this.cbClickPosition.Name = "cbClickPosition";
            this.cbClickPosition.Size = new System.Drawing.Size(151, 17);
            this.cbClickPosition.TabIndex = 11;
            this.cbClickPosition.Text = "Tıklanacak Koordinatı Seç";
            this.cbClickPosition.UseVisualStyleBackColor = true;
            this.cbClickPosition.CheckedChanged += new System.EventHandler(this.cbClickPosition_CheckedChanged);
            // 
            // lblWindow
            // 
            this.lblWindow.AutoSize = true;
            this.lblWindow.Location = new System.Drawing.Point(12, 27);
            this.lblWindow.Name = "lblWindow";
            this.lblWindow.Size = new System.Drawing.Size(78, 13);
            this.lblWindow.TabIndex = 14;
            this.lblWindow.Text = "Hangi Pencere";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(289, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(168, 23);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Tazele";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(267, 49);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(36, 20);
            this.txtY2.TabIndex = 18;
            this.txtY2.Text = "953";
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(223, 49);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(39, 20);
            this.txtX2.TabIndex = 17;
            this.txtX2.Text = "-1899";
            // 
            // cbProcs
            // 
            this.cbProcs.FormattingEnabled = true;
            this.cbProcs.Location = new System.Drawing.Point(92, 23);
            this.cbProcs.Name = "cbProcs";
            this.cbProcs.Size = new System.Drawing.Size(190, 21);
            this.cbProcs.TabIndex = 19;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(468, 242);
            this.Controls.Add(this.cbProcs);
            this.Controls.Add(this.txtY2);
            this.Controls.Add(this.txtX2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblWindow);
            this.Controls.Add(this.txtClickY);
            this.Controls.Add(this.txtClickX);
            this.Controls.Add(this.cbClickPosition);
            this.Controls.Add(this.cbOtomatik);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.btnHash);
            this.Controls.Add(this.btnCaptureInstantPattern);
            this.Controls.Add(this.btnCaptureMasterPattern);
            this.Controls.Add(this.pbLastCaptured);
            this.Controls.Add(this.pbMaster);
            this.Controls.Add(this.txtY1);
            this.Controls.Add(this.txtX1);
            this.Controls.Add(this.cbPatternPosition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "İSG Uzmanı";
            this.Move += new System.EventHandler(this.Form1_Move);
            ((System.ComponentModel.ISupportInitialize)(this.pbMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastCaptured)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbMaster;
        private System.Windows.Forms.PictureBox pbLastCaptured;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.CheckBox cbPatternPosition;
        private System.Windows.Forms.Button btnCaptureMasterPattern;
        private System.Windows.Forms.Button btnCaptureInstantPattern;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.CheckBox cbOtomatik;
        private System.Windows.Forms.Timer timerAuto;
        private System.Windows.Forms.TextBox txtClickY;
        private System.Windows.Forms.TextBox txtClickX;
        private System.Windows.Forms.CheckBox cbClickPosition;
        private System.Windows.Forms.Label lblWindow;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.ComboBox cbProcs;
    }
}

