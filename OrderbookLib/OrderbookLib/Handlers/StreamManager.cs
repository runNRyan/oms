using OrderbookLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Handlers
{
    public class StreamManager
    {
        private List<ClientHandler> _streamManager = new();

        public void Add(ClientHandler clientHandler)
        {
            _streamManager.Add(clientHandler);
        }

        public void Remove(ClientHandler clientHandler)
        {
            _streamManager = _streamManager.FindAll(handler => !handler.Equals(clientHandler));
        }

        public void SendToAll(DTOHub hub)
        {
            _streamManager.ForEach(handler => handler.Send(hub));
        }
    }
}
