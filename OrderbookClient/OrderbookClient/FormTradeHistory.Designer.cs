namespace OrderbookClient
{
    partial class FormTradeHistory
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
            dGVTradeHistory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dGVTradeHistory).BeginInit();
            SuspendLayout();
            // 
            // dGVTradeHistory
            // 
            dGVTradeHistory.AllowUserToAddRows = false;
            dGVTradeHistory.AllowUserToDeleteRows = false;
            dGVTradeHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dGVTradeHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGVTradeHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVTradeHistory.Location = new Point(12, 12);
            dGVTradeHistory.Name = "dGVTradeHistory";
            dGVTradeHistory.RowHeadersVisible = false;
            dGVTradeHistory.RowTemplate.Height = 25;
            dGVTradeHistory.Size = new Size(384, 601);
            dGVTradeHistory.TabIndex = 0;
            // 
            // FormTradeHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 625);
            Controls.Add(dGVTradeHistory);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormTradeHistory";
            Text = "Trade History";
            ((System.ComponentModel.ISupportInitialize)dGVTradeHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGVTradeHistory;
    }
}