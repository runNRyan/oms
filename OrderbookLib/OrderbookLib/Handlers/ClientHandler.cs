using OrderbookLib.Events;
using OrderbookLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Handlers
{
    public class ClientHandler: AbstractCmEvent
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;

        public override event EventHandler<CmEventArgs>? Connected;
        public override event EventHandler<CmEventArgs>? Disconnected;
        public override event EventHandler<CmEventArgs>? Received;

        public ClientHandler(TcpClient client)
        {
            _client = client;
            _stream = client.GetStream();
        }

        public DTOHub? InitialData { get; private set; }

        public async Task HandleClientAsync()
        {
            byte[] sizeBuffer = new byte[4];
            int read;

            try
            {
                while (true)
                {
                    read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                    if (read == 0)
                        break;

                    int size = BitConverter.ToInt32(sizeBuffer);
                    byte[] buffer = new byte[size];

                    read = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (read == 0)
                        break;

                    string message = Encoding.UTF8.GetString(buffer, 0, read);

                    var hub = DTOHub.Parse(message)!;
                    if (hub.State == TcpState.Initial)
                    {
                        InitialData = hub;
                        Debug.Print("클라이언트 연결 이벤트 발생");
                        Connected?.Invoke(this, new CmEventArgs(this, hub));
                    }
                    else
                    {
                        Debug.Print("클라이언트 데이터 수신 이벤트 발생");
                        Received?.Invoke(this, new CmEventArgs(this, hub));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트 요청 처리 중 오류 발생: {ex.Message}");
            }
            finally
            {
                _client.Close();
                Disconnected?.Invoke(this, new CmEventArgs(this, InitialData!));
            }
        }

        public void Send(DTOHub hub)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(hub.ToJsonString());
                byte[] lengthBuffer = BitConverter.GetBytes(buffer.Length);

                _stream.Write(lengthBuffer);
                _stream.Write(buffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
            }
        }




    }
}
