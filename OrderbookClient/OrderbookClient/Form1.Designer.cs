namespace OrderbookClient
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
            label4 = new Label();
            tBHost = new TextBox();
            tBPort = new TextBox();
            tBUserId = new TextBox();
            btnConnect = new Button();
            btnStop = new Button();
            btnOrderbook = new Button();
            btnHistoricalTrades = new Button();
            btnCloseAll = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(169, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 32);
            label1.TabIndex = 0;
            label1.Text = "Client";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(22, 40);
            label2.Name = "label2";
            label2.Size = new Size(64, 19);
            label2.TabIndex = 1;
            label2.Text = "Host IP";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(22, 70);
            label3.Name = "label3";
            label3.Size = new Size(41, 19);
            label3.TabIndex = 2;
            label3.Text = "Port";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(22, 100);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 3;
            label4.Text = "User ID";
            // 
            // tBHost
            // 
            tBHost.Location = new Point(89, 38);
            tBHost.Name = "tBHost";
            tBHost.Size = new Size(150, 23);
            tBHost.TabIndex = 4;
            tBHost.Text = "127.0.0.1";
            // 
            // tBPort
            // 
            tBPort.Location = new Point(89, 68);
            tBPort.Name = "tBPort";
            tBPort.Size = new Size(150, 23);
            tBPort.TabIndex = 5;
            tBPort.Text = "8080";
            // 
            // tBUserId
            // 
            tBUserId.Location = new Point(89, 98);
            tBUserId.Name = "tBUserId";
            tBUserId.Size = new Size(150, 23);
            tBUserId.TabIndex = 6;
            tBUserId.Text = "20240101";
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.WhiteSmoke;
            btnConnect.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnConnect.Location = new Point(22, 133);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(217, 50);
            btnConnect.TabIndex = 7;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStop.Location = new Point(22, 189);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(217, 50);
            btnStop.TabIndex = 8;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnOrderbook
            // 
            btnOrderbook.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnOrderbook.Location = new Point(22, 245);
            btnOrderbook.Name = "btnOrderbook";
            btnOrderbook.Size = new Size(217, 50);
            btnOrderbook.TabIndex = 9;
            btnOrderbook.Text = "Orderbook";
            btnOrderbook.UseVisualStyleBackColor = true;
            btnOrderbook.Click += btnOrderbook_Click;
            // 
            // btnHistoricalTrades
            // 
            btnHistoricalTrades.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnHistoricalTrades.Location = new Point(22, 301);
            btnHistoricalTrades.Name = "btnHistoricalTrades";
            btnHistoricalTrades.Size = new Size(217, 50);
            btnHistoricalTrades.TabIndex = 10;
            btnHistoricalTrades.Text = "Trade History";
            btnHistoricalTrades.UseVisualStyleBackColor = true;
            btnHistoricalTrades.Click += btnHistoricalTrades_Click;
            // 
            // btnCloseAll
            // 
            btnCloseAll.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCloseAll.Location = new Point(22, 357);
            btnCloseAll.Name = "btnCloseAll";
            btnCloseAll.Size = new Size(217, 50);
            btnCloseAll.TabIndex = 11;
            btnCloseAll.Text = "Close All";
            btnCloseAll.UseVisualStyleBackColor = true;
            btnCloseAll.Click += btnCloseAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(260, 418);
            Controls.Add(btnCloseAll);
            Controls.Add(btnHistoricalTrades);
            Controls.Add(btnOrderbook);
            Controls.Add(btnStop);
            Controls.Add(btnConnect);
            Controls.Add(tBUserId);
            Controls.Add(tBPort);
            Controls.Add(tBHost);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "OrderBook Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tBHost;
        private TextBox tBPort;
        private TextBox tBUserId;
        private Button btnConnect;
        private Button btnStop;
        private Button btnOrderbook;
        private Button btnHistoricalTrades;
        private Button btnCloseAll;
    }
}