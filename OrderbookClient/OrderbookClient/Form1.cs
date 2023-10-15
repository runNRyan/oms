using OrderbookLib.Communication;
using OrderbookLib.Events;
using OrderbookLib.Handlers;
using OrderbookLib.Models;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OrderbookClient
{
    public partial class Form1 : Form
    {
        private CmClient _client;
        public static ClientHandler? _clientHandler;

        // for ping count
        private int _countForReconnect = 0;
        private int _attemptReconnect = 0;

        // dataset for contain datatable for orderbook dataGridView
        public static DataSet? OrderbookDS = null;
        public static List<string>? OrderbookNames = null;

        // DataTable for trade histories
        public static DataTable? TradeHistoryDT = null;

        private int UserId => int.Parse(tBUserId.Text);

        /// <summary>
        /// make clientHandler for connection
        /// </summary>
        private void Connected(object? sender, CmEventArgs e)
        {
            _clientHandler = e.ClientHandler;
            Debug.WriteLine("서버가 연결 되었습니다.");
        }

        /// <summary>
        /// clear clientHandler for connection
        /// </summary>
        private void Disconnected(object? sender, CmEventArgs e)
        {
            _clientHandler = null;
            Debug.WriteLine("서버의 연결이 끊겼습니다.");
        }

        /// <summary>
        /// processing DTOHub from server
        /// </summary>
        private void Received(object? sender, CmEventArgs e)
        {
            DTOHub hub = e.Hub;

            if (hub.UserId == UserId)
            {
                string message = hub.State switch
                {
                    TcpState.Connect => $"{hub.UserId}님이 접속하였습니다.",
                    TcpState.Disconnect => $"{hub.UserId}님이 종료하였습니다.",
                    _ => $"{hub.UserId}: {hub.Types}"
                };
                Debug.WriteLine(message);
            }

            //Task.Factory.StartNew(() => ProcessDTOHub(hub));
            ProcessDTOHub(hub);

        }

        /// <summary>
        /// enable / disable UI elements by application status
        /// </summary>
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

        /// <summary>
        /// Initialize OrderbookDS, TradeHistoryDT
        /// </summary>
        private void InitializeDSDT()
        {
            OrderbookDS = new DataSet();
            OrderbookNames = new List<string>();

            foreach (var p in Enum.GetNames(typeof(TickerList)))
            {
                OrderbookNames.Add(p);
                DataTable dt = new DataTable();
                dt.TableName = p;
                dt.Columns.Add(p, typeof(string));      // Column : "Layer"
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

        /// <summary>
        /// compute internal OrderbookDS and TradeHistoryDT with DTOHub
        /// </summary>
        private void ProcessDTOHub(DTOHub hub)
        {
            try
            {
                _countForReconnect = 0;
                _attemptReconnect = 0;
                switch (hub.Types)
                {
                    case DTOType.HistoricalTrades:
                        lock (TradeHistoryDT)
                        {
                            List<Trade>? tempTrades = hub.HistoricalTrades;
                            if (tempTrades != null)
                            {
                                TradeHistoryDT.Clear();
                                foreach (var trade in tempTrades)
                                {
                                    TradeHistoryDT.Rows.Add(trade.ExecuteTime, trade.Side, trade.Ticker, trade.Price, trade.Quantity);
                                }
                            }
                        }
                        break;

                    case DTOType.Orderbook:

                        lock (OrderbookDS.Tables[hub.Ticker.ToString()])
                        {

                            DataTable dt = OrderbookDS.Tables[hub.Ticker.ToString()];

                            int cnt = Math.Min(hub.BidsPirce.Count, 10);

                            for (int i = 0; i < cnt; i++)
                            {
                                dt.Rows[i + 10][1] = hub.BidsPirce[i];
                                dt.Rows[i + 10][2] = hub.BidsQuantity[i];
                            }

                            cnt = Math.Min(hub.AsksPirce.Count, 10);

                            for (int i = 9; i >= (10 - cnt); i--)
                            {
                                dt.Rows[i][1] = hub.AsksPirce[9 - i];
                                dt.Rows[i][2] = hub.AsksQuantity[9 - i];
                            }
                        }
                        break;

                    case DTOType.Ping:
                        _countForReconnect = 0;
                        _attemptReconnect = 0;
                        break;

                    default:
                        break;


                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }


        public Form1()
        {
            InitializeComponent();
            // disable Maximize control button
            this.MaximizeBox = false;

            RunningStateChanged(false);
            InitializeDSDT();

            _client = new CmClient(IPAddress.Parse(tBHost.Text), int.Parse(tBPort.Text));
            _client.Connected += Connected;
            _client.Disconnected += Disconnected;
            _client.Received += Received;
            _client.RunningStateChanged += RunningStateChanged;

            ThreadPool.QueueUserWorkItem(PingConditionCheck);


        }

        /// <summary>
        /// ping check function running in threadpool
        /// if threre is not any signal from server for 15 min ? 
        /// and the system will try 5 times reconnect.
        /// </summary>
        /// <param name="state"></param>
        private async void PingConditionCheck(object state)
        {
            while (true)
            {
                if (_countForReconnect++ > 15)
                {
                    _attemptReconnect++;
                    _client.Close();
                    await _client.ConnectAsync(new ConnectionDetails
                    {
                        UserId = UserId
                    });

                    _countForReconnect++;
                }
                Thread.Sleep(60000);
                if (_attemptReconnect++ > 5)
                {
                    _client.Close();
                    break;
                }
            }
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