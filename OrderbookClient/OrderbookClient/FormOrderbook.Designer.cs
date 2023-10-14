namespace OrderbookClient
{
    partial class FormOrderbook
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
            dGVOrderbook = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnBuyOrder = new Button();
            groupBox1 = new GroupBox();
            tBQuantity = new TextBox();
            tBPrice = new TextBox();
            btnSellOrder = new Button();
            cBTicker = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dGVOrderbook).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dGVOrderbook
            // 
            dGVOrderbook.AllowUserToAddRows = false;
            dGVOrderbook.AllowUserToDeleteRows = false;
            dGVOrderbook.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dGVOrderbook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGVOrderbook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dGVOrderbook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVOrderbook.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVOrderbook.Location = new Point(12, 12);
            dGVOrderbook.Name = "dGVOrderbook";
            dGVOrderbook.RowHeadersVisible = false;
            dGVOrderbook.RowTemplate.Height = 25;
            dGVOrderbook.Size = new Size(323, 466);
            dGVOrderbook.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 4;
            label1.Text = "Price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 5;
            label2.Text = "Quantity";
            // 
            // btnBuyOrder
            // 
            btnBuyOrder.Location = new Point(6, 110);
            btnBuyOrder.Name = "btnBuyOrder";
            btnBuyOrder.Size = new Size(60, 60);
            btnBuyOrder.TabIndex = 6;
            btnBuyOrder.Text = "Buy";
            btnBuyOrder.UseVisualStyleBackColor = true;
            btnBuyOrder.Click += btnBuyOrder_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(tBQuantity);
            groupBox1.Controls.Add(tBPrice);
            groupBox1.Controls.Add(btnSellOrder);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnBuyOrder);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(345, 291);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(142, 187);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Order";
            // 
            // tBQuantity
            // 
            tBQuantity.Location = new Point(6, 81);
            tBQuantity.Name = "tBQuantity";
            tBQuantity.Size = new Size(123, 23);
            tBQuantity.TabIndex = 9;
            tBQuantity.KeyPress += textBox_onlynum;
            // 
            // tBPrice
            // 
            tBPrice.Location = new Point(6, 37);
            tBPrice.Name = "tBPrice";
            tBPrice.Size = new Size(123, 23);
            tBPrice.TabIndex = 8;
            tBPrice.KeyPress += textBox_onlynum;
            // 
            // btnSellOrder
            // 
            btnSellOrder.Location = new Point(69, 110);
            btnSellOrder.Name = "btnSellOrder";
            btnSellOrder.Size = new Size(60, 60);
            btnSellOrder.TabIndex = 7;
            btnSellOrder.Text = "Sell";
            btnSellOrder.UseVisualStyleBackColor = true;
            btnSellOrder.Click += btnSellOrder_Click;
            // 
            // cBTicker
            // 
            cBTicker.DropDownStyle = ComboBoxStyle.DropDownList;
            cBTicker.FormattingEnabled = true;
            cBTicker.Location = new Point(351, 43);
            cBTicker.Name = "cBTicker";
            cBTicker.Size = new Size(137, 23);
            cBTicker.TabIndex = 8;
            cBTicker.SelectionChangeCommitted += cBTicker_selectionEvent;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(351, 12);
            label3.Name = "label3";
            label3.Size = new Size(61, 22);
            label3.TabIndex = 9;
            label3.Text = "Ticker";
            // 
            // FormOrderbook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 490);
            Controls.Add(label3);
            Controls.Add(cBTicker);
            Controls.Add(groupBox1);
            Controls.Add(dGVOrderbook);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormOrderbook";
            Text = "Order book";
            ((System.ComponentModel.ISupportInitialize)dGVOrderbook).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dGVOrderbook;
        private Label label1;
        private Label label2;
        private Button btnBuyOrder;
        private GroupBox groupBox1;
        private Button btnSellOrder;
        private ComboBox cBTicker;
        private Label label3;
        private TextBox tBQuantity;
        private TextBox tBPrice;
    }
}