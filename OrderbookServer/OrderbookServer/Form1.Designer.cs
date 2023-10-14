namespace OrderbookServer
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tBHost = new TextBox();
            tBPort = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            lBClients = new ListBox();
            label4 = new Label();
            lBLog = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(441, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 0;
            label1.Text = "SERVER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(16, 19);
            label2.Name = "label2";
            label2.Size = new Size(64, 19);
            label2.TabIndex = 1;
            label2.Text = "Host IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(16, 49);
            label3.Name = "label3";
            label3.Size = new Size(41, 19);
            label3.TabIndex = 2;
            label3.Text = "Port";
            // 
            // tBHost
            // 
            tBHost.Location = new Point(83, 17);
            tBHost.Name = "tBHost";
            tBHost.Size = new Size(150, 23);
            tBHost.TabIndex = 3;
            tBHost.Text = "127.0.0.1";
            // 
            // tBPort
            // 
            tBPort.Location = new Point(83, 47);
            tBPort.Name = "tBPort";
            tBPort.Size = new Size(150, 23);
            tBPort.TabIndex = 4;
            tBPort.Text = "8080";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.Location = new Point(16, 85);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(217, 50);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStop.Location = new Point(16, 141);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(217, 50);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lBClients
            // 
            lBClients.FormattingEnabled = true;
            lBClients.ItemHeight = 15;
            lBClients.Location = new Point(16, 217);
            lBClients.Name = "lBClients";
            lBClients.Size = new Size(217, 319);
            lBClients.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(16, 195);
            label4.Name = "label4";
            label4.Size = new Size(47, 16);
            label4.TabIndex = 9;
            label4.Text = "Clients";
            // 
            // lBLog
            // 
            lBLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lBLog.Enabled = false;
            lBLog.FormattingEnabled = true;
            lBLog.ItemHeight = 15;
            lBLog.Location = new Point(239, 82);
            lBLog.Name = "lBLog";
            lBLog.Size = new Size(316, 454);
            lBLog.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(567, 551);
            Controls.Add(lBLog);
            Controls.Add(label4);
            Controls.Add(lBClients);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(tBPort);
            Controls.Add(tBHost);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Orderbook Server";
            FormClosing += FormClosingProcess;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tBHost;
        private TextBox tBPort;
        private Button btnStart;
        private Button btnStop;
        private ListBox lBClients;
        private Label label4;
        private ListBox lBLog;
    }
}