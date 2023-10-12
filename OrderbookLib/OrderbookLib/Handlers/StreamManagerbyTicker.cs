using OrderbookLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Handlers
{
    /// <summary>
    /// TODO for generating stream by ticker
    /// </summary>
    public class StreamManagerbyTicker
    {
        private Dictionary<TickerList, List<ClientHandler>> _roomHandlersDict = new();
    }
}
