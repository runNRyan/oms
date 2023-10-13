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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            button2 = new Button();
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
            // textBox1
            // 
            textBox1.Location = new Point(6, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(123, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 81);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(123, 23);
            textBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // button1
            // 
            button1.Location = new Point(54, 124);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(345, 291);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(142, 187);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // button2
            // 
            button2.Location = new Point(54, 153);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
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
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private ComboBox cBTicker;
        private Label label3;
    }
}