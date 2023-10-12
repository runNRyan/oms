using OrderbookLib.Handlers;
using OrderbookLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Events
{
    public class CmEventArgs : EventArgs
    {
        public CmEventArgs(ClientHandler clientHandler, DTOHub hub)
        {
            ClientHandler = clientHandler;
            Hub = hub;
        }

        public ClientHandler ClientHandler { get; }
        public DTOHub Hub { get; }
    }
}
