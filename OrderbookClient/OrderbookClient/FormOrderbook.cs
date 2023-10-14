using OrderbookLib.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        // after select combobox
        private void cBTicker_selectionEvent(object sender, EventArgs e)
        {
            MappingCBandDGV();
            
            if (cBTicker.Text == "None") return;


            TickerList _ticker = (TickerList)Enum.Parse(typeof(TickerList), cBTicker.Text);

            DTOHub hub = new DTOHub
            {
                State = TcpState.Subscribe,
                Ticker = _ticker
            };
            Form1._clientHandler.Send(hub);


        }

        // mapping datagridview's datasource
        private void MappingCBandDGV()
        {
            try
            {
                if (Form1.OrderbookDS is not null)
                    dGVOrderbook.DataSource = Form1.OrderbookDS.Tables[cBTicker.Text];
                if (cBTicker.Text == "None")
                    groupBox1.Enabled = false;
                else
                    groupBox1.Enabled = true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void textBox_onlynum(object sender, KeyPressEventArgs e)
        {
            //숫자와 백스페이스만 입력
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }

        }

        //  buy order
        private void btnBuyOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var order = new SingleOrder
                {
                    _price = int.Parse(tBPrice.Text),
                    _quantity = int.Parse(tBQuantity.Text)
                };

                TickerList _ticker = (TickerList)Enum.Parse(typeof(TickerList), cBTicker.Text);

                DTOHub hub = new DTOHub
                {
                    Types = DTOType.SingleOrder,
                    Ticker = _ticker,
                    ManualOrder = order
                };

                Form1._clientHandler.Send(hub);


            }
            catch (Exception ex )
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        //  sell order 
        private void btnSellOrder_Click(object sender, EventArgs e)
        {
            try
            {
                var order = new SingleOrder
                {
                    _price = int.Parse(tBPrice.Text),
                    _quantity = -1 * int.Parse(tBQuantity.Text)
                };

                TickerList _ticker = (TickerList)Enum.Parse(typeof(TickerList), cBTicker.Text);

                DTOHub hub = new DTOHub
                {
                    Types = DTOType.SingleOrder,
                    Ticker = _ticker,
                    ManualOrder = order
                };

                Form1._clientHandler.Send(hub);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
    }
}
