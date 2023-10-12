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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            btnOrderbook = new Button();
            btnHistoricalTrades = new Button();
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(21, 127);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 3;
            label4.Text = "User ID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(88, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 23);
            textBox1.TabIndex = 4;
            textBox1.Text = "127.0.0.1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(88, 95);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 23);
            textBox2.TabIndex = 5;
            textBox2.Text = "8080";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(88, 125);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 23);
            textBox3.TabIndex = 6;
            textBox3.Text = "20240101";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.WhiteSmoke;
            btnStart.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.Location = new Point(21, 160);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(217, 50);
            btnStart.TabIndex = 7;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnStop.Location = new Point(21, 216);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(217, 50);
            btnStop.TabIndex = 8;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnOrderbook
            // 
            btnOrderbook.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnOrderbook.Location = new Point(21, 272);
            btnOrderbook.Name = "btnOrderbook";
            btnOrderbook.Size = new Size(217, 50);
            btnOrderbook.TabIndex = 9;
            btnOrderbook.Text = "Orderbook";
            btnOrderbook.UseVisualStyleBackColor = true;
            // 
            // btnHistoricalTrades
            // 
            btnHistoricalTrades.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnHistoricalTrades.Location = new Point(21, 328);
            btnHistoricalTrades.Name = "btnHistoricalTrades";
            btnHistoricalTrades.Size = new Size(217, 50);
            btnHistoricalTrades.TabIndex = 10;
            btnHistoricalTrades.Text = "Trade History";
            btnHistoricalTrades.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Pink;
            ClientSize = new Size(260, 402);
            Controls.Add(btnHistoricalTrades);
            Controls.Add(btnOrderbook);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button btnStart;
        private Button btnStop;
        private Button btnOrderbook;
        private Button btnHistoricalTrades;
    }
}