using OrderbookLib.Communication;
using OrderbookLib.Events;
using OrderbookLib.Models;
using System.Net;

namespace OrderbookServer
{
    public partial class Form1 : Form
    {
        private CmServer _server;

        private DTOHub CreateNewStateDTOHub(DTOHub hub, TcpState state)
        {
            return new DTOHub
            {
                UserId = hub.UserId,
                State = state,
            };
        }
        private void AddClientMessageList(DTOHub hub)
        {
            string message = hub.State switch
            {
                TcpState.Connect => $"≮ 立加 ≮ {hub} ≮",
                TcpState.Disconnect => $"≮ 立加 辆丰 ≮ {hub} ≮",
                _ => $"{hub}: Types {hub.Types}, State {hub.State}"
            };
            lBLog.Items.Add(message);
        }

        private void Connected(object? sender, CmEventArgs e)
        {
            var hub = CreateNewStateDTOHub(e.Hub, TcpState.Connect);

            lBClients.Items.Add(e.Hub);
            AddClientMessageList(hub);
        }
        private void Disconnected(object? sender, CmEventArgs e)
        {
            var hub = CreateNewStateDTOHub(e.Hub, TcpState.Disconnect);

            lBClients.Items.Remove(e.Hub);
            AddClientMessageList(hub);
        }
        private void Received(object? sender, CmEventArgs e)
        {
            AddClientMessageList(e.Hub);
        }
        private void RunningStateChanged(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnStop.Enabled = isRunning;
        }

        public Form1()
        {
            InitializeComponent();

            _server = new CmServer(IPAddress.Parse("127.0.0.1"), 8080);
            _server.Connected += Connected;
            _server.Disconnected += Disconnected;
            _server.Received += Received;
            _server.RunningStateChanged += RunningStateChanged;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _ = _server.StartAsync();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            _server.Stop();
        }
    }
}