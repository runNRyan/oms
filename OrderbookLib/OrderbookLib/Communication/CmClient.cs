using OrderbookLib.Events;
using OrderbookLib.Handlers;
using OrderbookLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Communication
{
    public class CmClient:CmBase
    {
        private TcpClient? _client;
        private DTOHub ConvertDTOHub(ConnectionDetails details)
        {
            return new DTOHub
            {
                UserId = details.UserId,
                State = TcpState.Initial
            };
        }

        public override event EventHandler<CmEventArgs>? Connected;
        public override event EventHandler<CmEventArgs>? Disconnected;
        public override event EventHandler<CmEventArgs>? Received;


        public CmClient(IPAddress iPAddress, int port) : base(iPAddress, port)
        {
        }

        public async Task ConnectAsync(ConnectionDetails details)
        {
            if (IsRunning) return;

            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(IPAddress, Port);
                IsRunning = true;

                DTOHub hub = ConvertDTOHub(details);
                ClientHandler clientHandler = new ClientHandler(_client);
                Connected?.Invoke(this, new CmEventArgs(clientHandler, hub));
                clientHandler.Disconnected += ClientHandler_Disconnected;
                clientHandler.Received += Received;

                _ = clientHandler.HandleClientAsync();
                clientHandler?.Send(hub);
            }
            catch (Exception ex)
            {
                DisposeClient();
                Debug.Print($"서버 연결 시도 중 오류 발생: {ex.Message}");
            }
        }

        private void DisposeClient()
        {
            _client?.Dispose();
            IsRunning = false;
        }

        private void ClientHandler_Disconnected(object? sender, CmEventArgs e)
        {
            DisposeClient();
            Disconnected?.Invoke(sender, e);
        }

        public void Close()
        {
            DisposeClient();
        }









    }


}
