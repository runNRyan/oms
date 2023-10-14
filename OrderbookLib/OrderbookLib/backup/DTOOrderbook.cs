////using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using OrderbookLib.Models;

//namespace OrderbookLib.backup
//{
//    /// <summary>
//    /// DTO for making orderbooks table at clients
//    /// Bids, Asks will contain 5 layers for each
//    /// </summary>
//    public class DTOOrderbook : ConnectionDetails
//    {
//        public static DTOOrderbook? Parse(string json) => JsonSerializer.Deserialize<DTOOrderbook>(json)!;

//        public TickerList Ticker { get; set; }
//        public Dictionary<int, int> Bids { get; set; }
//        public Dictionary<int, int> Asks { get; set; }


//        public string ToJsonString() => JsonSerializer.Serialize(this);
//    }
//}
