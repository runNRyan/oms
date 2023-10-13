using OrderbookLib.Communication;
using OrderbookLib.Events;
using OrderbookLib.Handlers;
using OrderbookLib.Models;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace OrderbookClient
{
    public partial class Form1 : Form
    {
        private CmClient _client;
        private ClientHandler? _clientHandler;

        // dataset for contain datatable for orderbook dataGridView
        public static DataSet? OrderbookDS;
        public static List<string>? OrderbookNames;

        public static DataTable? TradeHistoryDT;


        private int UserId => int.Parse(tBUserId.Text);

        private void Connected(object? sender, CmEventArgs e)
        {
            _clientHandler = e.ClientHandler;
            Debug.WriteLine("서버가 연결 되었습니다.");
        }

        private void Disconnected(object? sender, CmEventArgs e)
        {
            _clientHandler = null;
            Debug.WriteLine("서버의 연결이 끊겼습니다.");
        }

        private void Received(object? sender, CmEventArgs e)
        {
            DTOHub hub = e.Hub;
            string message = hub.State switch
            {
                TcpState.Connect => $"{hub.UserId}님이 접속하였습니다.",
                TcpState.Disconnect => $"{hub.UserId}님이 종료하였습니다.",
                _ => $"{hub.UserId}: {hub.Types}"
            };
            Debug.WriteLine(message);
        }

        // enable / disable UI elements by application status
        private void RunningStateChanged(bool isRunning)
        {
            // false means functions are not working, need to set
            tBHost.Enabled = !isRunning;
            tBPort.Enabled = !isRunning;
            tBUserId.Enabled = !isRunning;
            btnConnect.Enabled = !isRunning;

            // true means functions are working
            btnStop.Enabled = isRunning;
            btnOrderbook.Enabled = isRunning;
            btnHistoricalTrades.Enabled = isRunning;

        }

        // Initialize orderbook dataset
        private void InitializeDSDT()
        {
            OrderbookDS = new DataSet();
            OrderbookNames = new List<string>();

            foreach (var p in Enum.GetNames(typeof(TickerList)))
            {
                OrderbookNames.Add(p);

                DataTable dt = new DataTable();
                dt.TableName = p;
                dt.Columns.Add("Layer", typeof(string));
                dt.Columns.Add("Price", typeof(int));
                dt.Columns.Add("Quantity", typeof(int));
                for (int i = 10; i > 0; i--)
                {
                    dt.Rows.Add("Ask " + i.ToString());
                }
                for (int i = 1; i < 11; i++)
                {
                    dt.Rows.Add("Bid " + i.ToString());
                }
                // for test 
                dt.Rows[0][0] = p;
                OrderbookDS.Tables.Add(dt);
            }

            TradeHistoryDT = new DataTable();
            TradeHistoryDT.TableName = "TradeHistory";
            TradeHistoryDT.Columns.Add("Time", typeof(DateTime));
            TradeHistoryDT.Columns.Add("Side", typeof(string));
            TradeHistoryDT.Columns.Add("Ticker", typeof(string));
            TradeHistoryDT.Columns.Add("Price", typeof(int));
            TradeHistoryDT.Columns.Add("Quantity", typeof(int));

        }






        public Form1()
        {
            InitializeComponent();
            // disable Maximize control button
            this.MaximizeBox = false;

            // RunningStateChanged(false);
            InitializeDSDT();

            _client = new CmClient(IPAddress.Parse("127.0.0.1"), 8080);
            _client.Connected += Connected;
            _client.Disconnected += Disconnected;
            _client.Received += Received;
            _client.RunningStateChanged += RunningStateChanged;

        }

        // Open connection with server 
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await _client.ConnectAsync(new ConnectionDetails
            {
                UserId = UserId
            });
        }

        // Close connection with server 
        private void btnStop_Click(object sender, EventArgs e)
        {
            _client.Close();
        }

        // make new form for orderbook
        private void btnOrderbook_Click(object sender, EventArgs e)
        {
            FormOrderbook form = new FormOrderbook();

            form.Show();
        }

        // make new and only one form for trade history
        private void btnHistoricalTrades_Click(object sender, EventArgs e)
        {
            FormTradeHistory form = FormTradeHistory.Instance;

            if (!form.Visible)
                form.Show();
            else
                form.BringToFront();
        }

        // Close all child forms
        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = Application.OpenForms.Count - 1; i > 0; i--)
                {
                    Application.OpenForms[i].Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}