using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookLib.Models
{
    /// <summary>
    /// enum for status of tcp socket connection
    /// </summary>
    public enum DTOType
    {
        None, Orderbook, HistoricalTrades
    }
}
