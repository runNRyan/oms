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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            lBClients = new ListBox();
            label4 = new Label();
            label5 = new Label();
            lBLog = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(467, 0);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 0;
            label1.Text = "SERVER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(21, 67);
            label2.Name = "label2";
            label2.Size = new Size(64, 19);
            label2.TabIndex = 1;
            label2.Text = "Host IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(21, 97);
            label3.Name = "label3";
            label3.Size = new Size(41, 19);
            label3.TabIndex = 2;
            label3.Text = "Port";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(88, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "127.0.0.1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(88, 95);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "8080";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.Location = new Point(21, 133);
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
            btnStop.Location = new Point(21, 189);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(217, 50);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lBClients
            // 
            lBClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lBClients.FormattingEnabled = true;
            lBClients.ItemHeight = 15;
            lBClients.Location = new Point(21, 275);
            lBClients.Name = "lBClients";
            lBClients.Size = new Size(217, 304);
            lBClients.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(21, 253);
            label4.Name = "label4";
            label4.Size = new Size(47, 16);
            label4.TabIndex = 9;
            label4.Text = "Clients";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(259, 65);
            label5.Name = "label5";
            label5.Size = new Size(34, 16);
            label5.TabIndex = 10;
            label5.Text = "LOG";
            // 
            // lBLog
            // 
            lBLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lBLog.FormattingEnabled = true;
            lBLog.ItemHeight = 15;
            lBLog.Location = new Point(259, 95);
            lBLog.Name = "lBLog";
            lBLog.Size = new Size(316, 484);
            lBLog.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(593, 592);
            Controls.Add(lBLog);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lBClients);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Orderbook Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnStart;
        private Button btnStop;
        private ListBox lBClients;
        private Label label4;
        private Label label5;
        private ListBox lBLog;
    }
}