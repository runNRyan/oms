//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using OrderbookLib.Models;

//namespace OrderbookLib.backup
//{
//    /// <summary>
//    /// DTO for making trades table at clients
//    /// </summary>
//    public class DTOHistoricalTrades : ConnectionDetails
//    {
//        public static DTOHistoricalTrades? Parse(string json) => JsonSerializer.Deserialize<DTOHistoricalTrades>(json)!;

//        public List<Trade> Trades { get; set; } = new List<Trade>();

//        public string ToJsonString() => JsonSerializer.Serialize(this);
//    }
//}
