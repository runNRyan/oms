using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderbookClient
{
    public partial class FormTradeHistory : Form
    {

        private static FormTradeHistory instance;


        private FormTradeHistory()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            MappingCBandDGV();
        }

        // singleton
        public static FormTradeHistory Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FormTradeHistory();
                }
                return instance;
            }
        }

        private void MappingCBandDGV()
        {
            try
            {
                if (Form1.TradeHistoryDT is not null)
                    dGVTradeHistory.DataSource = Form1.TradeHistoryDT;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
