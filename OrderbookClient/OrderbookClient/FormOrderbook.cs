using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderbookClient
{
    public partial class FormOrderbook : Form
    {
        public FormOrderbook()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            cBTicker.DataSource = Form1.OrderbookNames;

            MappingCBandDGV();
        }

        private void cBTicker_selectionEvent(object sender, EventArgs e)
        {
            MappingCBandDGV();
        }

        private void MappingCBandDGV()
        {
            try
            {
                if (Form1.OrderbookDS is not null)
                    dGVOrderbook.DataSource = Form1.OrderbookDS.Tables[cBTicker.Text];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
