using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderbookLib.Models
{
    public class DTOHub: ConnectionDetails
    {
        public static DTOHub? Parse(string json) => JsonSerializer.Deserialize<DTOHub>(json)!;

        public TcpState State { get; set; }

        public DTOType Types { get; set; }

        // for orderbook
        public TickerList Ticker { get; set; }
        //public Dictionary<int, int>? Bids { get; set; }
        public List<int>? BidsPirce { get; set; }
        public List<int>? BidsQuantity { get; set; }

        //public Dictionary<int, int>? Asks { get; set; }
        public List<int>? AsksPirce { get; set; }
        public List<int>? AsksQuantity { get; set; }


        // for historical trades
        public List<Trade>? HistoricalTrades { get; set; } // = new List<Trade>();

        // for SingleOrder
        public SingleOrder? ManualOrder { get; set; }

        public string ToJsonString() => JsonSerializer.Serialize(this);
    }
}
