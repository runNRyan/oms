using OrderbookLib.Communication;
using OrderbookLib.Events;
using OrderbookLib.Handlers;
using OrderbookLib.Models;
using OrderbookServer.Models;
using System;
using System.Diagnostics;
using System.Net;

namespace OrderbookServer
{
    public partial class Form1 : Form
    {
        private CmServer _server;
        private StreamManager? _streamManager;

        private List<Trade> _tradeList;
        private Dictionary<TickerList, Orderbook> _orderbooks;

        private int NumberOfTickers = Enum.GetValues(typeof(TickerList)).Length;


        /// <summary>
        /// create DTOHub for replying
        /// </summary>
        private DTOHub CreateNewStateDTOHub(DTOHub hub, TcpState state)
        {
            return new DTOHub
            {
                UserId = hub.UserId,
                State = state,
            };
        }

        /// <summary>
        /// logging connection info
        /// </summary>
        private void AddClientMessageList(DTOHub hub)
        {
            string message = hub.State switch
            {
                TcpState.Connect => $"♬ Connected ♬ {hub} ♬",
                TcpState.Disconnect => $"♬ Connection terminated ♬ {hub} ♬",
                _ => $"{hub}: Types {hub.Types}, State {hub.State}"
            };
            lBLog.Items.Add(message);
        }

        /// <summary>
        /// store connection
        /// </summary>
        private void Connected(object? sender, CmEventArgs e)
        {

            _streamManager.Add(e.ClientHandler);

            // server dont have to send 
            var hub = CreateNewStateDTOHub(e.Hub, TcpState.Connect);
            SendInitialDataToClient(e.ClientHandler);
            //_streamManager.SendToAll(hub);


            lBClients.Items.Add(e.Hub);
            AddClientMessageList(hub);
        }

        /// <summary>
        /// send current data to client 
        /// </summary>
        private void SendInitialDataToClient(ClientHandler _clientHandler)
        {
            try
            {

                _clientHandler.Send((new DTOHub
                {
                    Types = DTOType.HistoricalTrades,
                    HistoricalTrades = _tradeList
                }));

                foreach (TickerList p in Enum.GetValues(typeof(TickerList)))
                {
                    if (p == TickerList.None) continue;

                    var bid = _orderbooks[p].Bids.Reverse().Take(10);
                    var ask = _orderbooks[p].Asks.Take(10);


                    _clientHandler.Send(new DTOHub
                    {
                        Types = DTOType.Orderbook,
                        Ticker = p,
                        BidsPirce = bid.Select(pair => pair.Key).ToList(),
                        BidsQuantity = bid.Select(pair => pair.Value).ToList(),
                        AsksPirce = ask.Select(pair => pair.Key).ToList(),
                        AsksQuantity = ask.Select(pair => pair.Value).ToList()
                    });

                }


            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

        }

        /// <summary>
        /// remove connection
        /// </summary>
        private void Disconnected(object? sender, CmEventArgs e)
        {

            _streamManager.Remove(e.ClientHandler);

            // server dont have to send 
            var hub = CreateNewStateDTOHub(e.Hub, TcpState.Disconnect);
            //_streamManager.SendToAll(hub);

            lBClients.Items.Remove(e.Hub);
            AddClientMessageList(hub);
        }

        /// <summary>
        /// for processing received from client
        /// </summary>
        private void Received(object? sender, CmEventArgs e)
        {

            // server dont have to send 
            //_streamManager.SendToAll(e.Hub);

            AddClientMessageList(e.Hub);
            Task.Factory.StartNew(() => ProcessDTOHub(e.Hub));
        }

        /// <summary>
        /// enable / disable UI elements by application status
        /// </summary>
        private void RunningStateChanged(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            tBHost.Enabled = !isRunning;
            tBPort.Enabled = !isRunning;
            btnStop.Enabled = isRunning;
        }

        /// <summary>
        /// Create orderbooks based on a ticker list
        /// </summary>
        private void GenerateOrderbooks()
        {
            _orderbooks = new Dictionary<TickerList, Orderbook>();

            foreach (TickerList p in Enum.GetValues(typeof(TickerList)))
            {
                var newOrderbook = new Orderbook(p);
                newOrderbook.OrderbookChanged += SendChangedOrderbook;
                newOrderbook.TradeExecuted += SendExecutedTrade;
                _orderbooks.Add(p, newOrderbook);
            }
        }

        /// <summary>
        /// Send Orderbook by ticker
        /// </summary>
        private void SendChangedOrderbook(TickerList ticker)
        {
            var bid = _orderbooks[ticker].Bids.Reverse().Take(10);
            var ask = _orderbooks[ticker].Asks.Take(10);

            Debug.WriteLine($"ticker orderbook {ticker}");
            _streamManager.SendToAll(new DTOHub
            {
                Types = DTOType.Orderbook,
                Ticker = ticker,
                BidsPirce = bid.Select(pair => pair.Key).ToList(),
                BidsQuantity = bid.Select(pair => pair.Value).ToList(),
                AsksPirce = ask.Select(pair => pair.Key).ToList(),
                AsksQuantity = ask.Select(pair => pair.Value).ToList()
            });


        }

        /// <summary>
        /// Send TradeHistory by ticker 
        /// </summary>
        private void SendExecutedTrade(Trade trade)
        {

            _tradeList.Add(trade);

            _streamManager.SendToAll(new DTOHub
            {
                Types = DTOType.HistoricalTrades,
                HistoricalTrades = _tradeList
            });
        }

        /// <summary>
        /// Process manual Order from clients
        /// </summary>
        private void ProcessDTOHub(DTOHub hub)
        {
            try
            {
                switch (hub.Types)
                {
                    case DTOType.SingleOrder:
                        _orderbooks[hub.Ticker].EnquequeOrder(hub.ManualOrder);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private System.Timers.Timer _timer;
        private Random _random = new Random();

        /// <summary>
        /// To make changes in orderbook we have 
        /// generate random order in random time
        /// </summary>
        private void GenerateRandomOrderinRandomTIme(object sender, EventArgs e)
        {
            try
            {
                TickerList __ticker = (TickerList)_random.Next(1, NumberOfTickers);
                int _currentPrice = _orderbooks[__ticker].CurrentPrice;
                int tickPrice = (int)(_currentPrice / 100);
                int multiple = _random.Next(2) == 0 ? -1 : 1;
                int randomPrice = _currentPrice + multiple * _random.Next(tickPrice);
                int randomQuantity = multiple * _random.Next(1, 20);
                var _randomOrder = new SingleOrder
                {
                    _price = randomPrice,
                    _quantity = randomQuantity

                };

                _orderbooks[__ticker].EnquequeOrder(_randomOrder);

                // Set a new random interval
                SetRandomInterval();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// ensure generate random order in random time
        /// </summary>
        private void SetRandomInterval()
        {
            // Generate a random interval between 1000 and 5000 milliseconds (1 to 5 seconds)
            int randomInterval = _random.Next(5000, 10000);
            _timer.Interval = randomInterval;
        }


        public Form1()
        {
            InitializeComponent();
            GenerateOrderbooks();
            RunningStateChanged(false);

            _tradeList = HistoricalTrades.LoadTradesFromFile();

            // for test
            //_tradeList = HistoricalTrades.GenerateRandomTrades(30);

            _streamManager = new StreamManager();
            _server = new CmServer(IPAddress.Parse(tBHost.Text), int.Parse(tBPort.Text));
            _server.Connected += Connected;
            _server.Disconnected += Disconnected;
            _server.Received += Received;
            _server.RunningStateChanged += RunningStateChanged;

            _timer = new System.Timers.Timer();
            _timer.Elapsed += GenerateRandomOrderinRandomTIme;
            SetRandomInterval();
        }

        // start server
        private void btnStart_Click(object sender, EventArgs e)
        {
            _ = _server.StartAsync();
            _timer.Start();
        }

        // stop server
        private void btnStop_Click(object sender, EventArgs e)
        {
            _server.Stop();
            _timer.Stop();
        }

        // before close form 
        private void FormClosingProcess(object sender, FormClosingEventArgs e)
        {
            HistoricalTrades.SaveTradesToFile(_tradeList);
        }


        #region for Test

        // for test
        //private void btnTest_Click(object sender, EventArgs e)
        //{
        //    lBLog.Items.Add("응 테스트 메세지 전송");
        //    //_streamManager.SendToAll(new DTOHub
        //    //{
        //    //    Types = DTOType.HistoricalTrades,
        //    //    HistoricalTrades = _tradeList
        //    //});


        //    var bid = _orderbooks[TickerList.AA0].Bids.Reverse().Take(10);
        //    var ask = _orderbooks[TickerList.AA0].Asks.Take(10);


        //    _streamManager.SendToAll(new DTOHub
        //    {
        //        Types = DTOType.Orderbook,
        //        Ticker = TickerList.AA0,
        //        BidsPirce = bid.Select(pair => pair.Key).ToList(),
        //        BidsQuantity = bid.Select(pair => pair.Value).ToList(),
        //        AsksPirce = ask.Select(pair => pair.Key).ToList(),
        //        AsksQuantity = ask.Select(pair => pair.Value).ToList()
        //    });
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var a = new SingleOrder
        //    {
        //        _price = int.Parse(textBox3.Text),
        //        _quantity = int.Parse(textBox4.Text)
        //    };
        //    TickerList __ticker = (TickerList)Enum.Parse(typeof(TickerList), textBox5.Text);
        //    _orderbooks[__ticker].EnquequeOrder(a);
        //}
        #endregion 

    }
}