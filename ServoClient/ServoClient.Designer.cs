namespace ServoClient
{
    partial class ServoClient
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.servoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBoxKp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtBoxKi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBoxKd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBoxErrorMax = new System.Windows.Forms.TextBox();
            this.btnGetConfig = new System.Windows.Forms.Button();
            this.btnSetConfig = new System.Windows.Forms.Button();
            this.btnStartData = new System.Windows.Forms.Button();
            this.cbQuad = new System.Windows.Forms.CheckBox();
            this.cbStep = new System.Windows.Forms.CheckBox();
            this.cbError = new System.Windows.Forms.CheckBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBoxPWMPeriod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBoxIntMax = new System.Windows.Forms.TextBox();
            this.ChartRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.servoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(789, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // servoToolStripMenuItem
            // 
            this.servoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.commPortToolStripMenuItem});
            this.servoToolStripMenuItem.Name = "servoToolStripMenuItem";
            this.servoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.servoToolStripMenuItem.Text = "Servo";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // commPortToolStripMenuItem
            // 
            this.commPortToolStripMenuItem.Name = "commPortToolStripMenuItem";
            this.commPortToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.commPortToolStripMenuItem.Text = "Comm Port";
            // 
            // Chart1
            // 
            this.Chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            legend2.Name = "Legend1";
            this.Chart1.Legends.Add(legend2);
            this.Chart1.Location = new System.Drawing.Point(13, 63);
            this.Chart1.Name = "Chart1";
            this.Chart1.Size = new System.Drawing.Size(764, 379);
            this.Chart1.TabIndex = 2;
            this.Chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kp";
            // 
            // TxtBoxKp
            // 
            this.TxtBoxKp.Location = new System.Drawing.Point(32, 36);
            this.TxtBoxKp.Name = "TxtBoxKp";
            this.TxtBoxKp.Size = new System.Drawing.Size(55, 20);
            this.TxtBoxKp.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ki";
            // 
            // TxtBoxKi
            // 
            this.TxtBoxKi.Location = new System.Drawing.Point(109, 36);
            this.TxtBoxKi.Name = "TxtBoxKi";
            this.TxtBoxKi.Size = new System.Drawing.Size(64, 20);
            this.TxtBoxKi.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kd";
            // 
            // TxtBoxKd
            // 
            this.TxtBoxKd.Location = new System.Drawing.Point(198, 36);
            this.TxtBoxKd.Name = "TxtBoxKd";
            this.TxtBoxKd.Size = new System.Drawing.Size(58, 20);
            this.TxtBoxKd.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ErrorMax";
            // 
            // TxtBoxErrorMax
            // 
            this.TxtBoxErrorMax.Location = new System.Drawing.Point(312, 36);
            this.TxtBoxErrorMax.Name = "TxtBoxErrorMax";
            this.TxtBoxErrorMax.Size = new System.Drawing.Size(31, 20);
            this.TxtBoxErrorMax.TabIndex = 15;
            // 
            // btnGetConfig
            // 
            this.btnGetConfig.Enabled = false;
            this.btnGetConfig.Location = new System.Drawing.Point(605, 34);
            this.btnGetConfig.Name = "btnGetConfig";
            this.btnGetConfig.Size = new System.Drawing.Size(75, 23);
            this.btnGetConfig.TabIndex = 16;
            this.btnGetConfig.Text = "Get Config";
            this.btnGetConfig.UseVisualStyleBackColor = true;
            this.btnGetConfig.Click += new System.EventHandler(this.btnGetConfig_Click);
            // 
            // btnSetConfig
            // 
            this.btnSetConfig.Enabled = false;
            this.btnSetConfig.Location = new System.Drawing.Point(702, 34);
            this.btnSetConfig.Name = "btnSetConfig";
            this.btnSetConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSetConfig.TabIndex = 17;
            this.btnSetConfig.Text = "Set Config";
            this.btnSetConfig.UseVisualStyleBackColor = true;
            this.btnSetConfig.Click += new System.EventHandler(this.btnSetConfig_Click);
            // 
            // btnStartData
            // 
            this.btnStartData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartData.Enabled = false;
            this.btnStartData.Location = new System.Drawing.Point(16, 448);
            this.btnStartData.Name = "btnStartData";
            this.btnStartData.Size = new System.Drawing.Size(75, 23);
            this.btnStartData.TabIndex = 19;
            this.btnStartData.Text = "Start Data";
            this.btnStartData.UseVisualStyleBackColor = true;
            this.btnStartData.Click += new System.EventHandler(this.btnStartData_Click);
            // 
            // cbQuad
            // 
            this.cbQuad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbQuad.AutoSize = true;
            this.cbQuad.Location = new System.Drawing.Point(107, 452);
            this.cbQuad.Name = "cbQuad";
            this.cbQuad.Size = new System.Drawing.Size(66, 17);
            this.cbQuad.TabIndex = 20;
            this.cbQuad.Text = "Encoder";
            this.cbQuad.UseVisualStyleBackColor = true;
            this.cbQuad.CheckedChanged += new System.EventHandler(this.cbQuad_CheckedChanged);
            // 
            // cbStep
            // 
            this.cbStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbStep.AutoSize = true;
            this.cbStep.Location = new System.Drawing.Point(179, 452);
            this.cbStep.Name = "cbStep";
            this.cbStep.Size = new System.Drawing.Size(48, 17);
            this.cbStep.TabIndex = 21;
            this.cbStep.Text = "Step";
            this.cbStep.UseVisualStyleBackColor = true;
            this.cbStep.CheckedChanged += new System.EventHandler(this.cbStep_CheckedChanged);
            // 
            // cbError
            // 
            this.cbError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbError.AutoSize = true;
            this.cbError.Checked = true;
            this.cbError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbError.Location = new System.Drawing.Point(234, 452);
            this.cbError.Name = "cbError";
            this.cbError.Size = new System.Drawing.Size(48, 17);
            this.cbError.TabIndex = 22;
            this.cbError.Text = "Error";
            this.cbError.UseVisualStyleBackColor = true;
            this.cbError.CheckedChanged += new System.EventHandler(this.cbError_CheckedChanged);
            // 
            // btnClearData
            // 
            this.btnClearData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearData.Location = new System.Drawing.Point(299, 448);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(75, 23);
            this.btnClearData.TabIndex = 23;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "PWM Period";
            // 
            // TxtBoxPWMPeriod
            // 
            this.TxtBoxPWMPeriod.Location = new System.Drawing.Point(422, 36);
            this.TxtBoxPWMPeriod.Name = "TxtBoxPWMPeriod";
            this.TxtBoxPWMPeriod.Size = new System.Drawing.Size(54, 20);
            this.TxtBoxPWMPeriod.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "IntegralMax";
            // 
            // TxtBoxIntMax
            // 
            this.TxtBoxIntMax.Location = new System.Drawing.Point(543, 36);
            this.TxtBoxIntMax.Name = "TxtBoxIntMax";
            this.TxtBoxIntMax.Size = new System.Drawing.Size(54, 20);
            this.TxtBoxIntMax.TabIndex = 27;
            // 
            // ChartRefreshTimer
            // 
            this.ChartRefreshTimer.Tick += new System.EventHandler(this.ChartRefreshTimer_Tick);
            // 
            // ServoClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 477);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtBoxIntMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtBoxPWMPeriod);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.cbError);
            this.Controls.Add(this.cbStep);
            this.Controls.Add(this.cbQuad);
            this.Controls.Add(this.btnStartData);
            this.Controls.Add(this.btnSetConfig);
            this.Controls.Add(this.btnGetConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBoxKp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtBoxKi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtBoxKd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtBoxErrorMax);
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServoClient";
            this.Text = "Servo Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem servoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commPortToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBoxKp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBoxKi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBoxKd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBoxErrorMax;
        private System.Windows.Forms.Button btnGetConfig;
        private System.Windows.Forms.Button btnSetConfig;
        private System.Windows.Forms.Button btnStartData;
        private System.Windows.Forms.CheckBox cbQuad;
        private System.Windows.Forms.CheckBox cbStep;
        private System.Windows.Forms.CheckBox cbError;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBoxPWMPeriod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtBoxIntMax;
        private System.Windows.Forms.Timer ChartRefreshTimer;
    }
}

