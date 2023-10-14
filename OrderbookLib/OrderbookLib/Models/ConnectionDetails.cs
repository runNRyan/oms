using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderbookLib.Models
{
    /// <summary>
    /// class for contain information of tcp connection
    /// </summary>
    public class ConnectionDetails
    {
        public int UserId { get; set; }
        
        // TODO socker connection for every tickers ?
        // public TickerList Ticker { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}";
        }
    }
}
