using OrderbookLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace OrderbookServer.Models
{
    public static class HistoricalTrades
    {
        private static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dat\tradeHistory");
        private static string filePath = Path.Combine(folderPath, "trades.json");

        /// <summary>
        /// Load stored data in local
        /// run when application start
        /// </summary>
        public static List<Trade> LoadTradesFromFile()
        {
            Directory.CreateDirectory(folderPath);

            List<Trade>? trades = new List<Trade>();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                trades = JsonSerializer.Deserialize<List<Trade>>(json);
            }

            if (trades != null)
                return trades;

            return new List<Trade>();

        }

        /// <summary>
        /// Save  data in local
        /// run when application stop
        /// </summary>
        public static void SaveTradesToFile(List<Trade> trades)
        {
            string json = JsonSerializer.Serialize(trades);
            File.WriteAllText(filePath, json);
        }


        public static List<Trade> GenerateRandomTrades(int numberOfTrades)
        {

            Random random = new Random();
            List<Trade> trades = new List<Trade>();

            for (int i = 0; i < numberOfTrades; i++)
            {
                Trade trade = new Trade
                {
                    ExecuteTime = DateTime.Now.AddMinutes(-1*random.Next(1, 100)),
                    Side = random.Next(2) == 0 ? "Buy" : "Sell",
                    Ticker = (TickerList)random.Next(1, Enum.GetValues(typeof(TickerList)).Length),
                    Price = random.Next(9000, 11000),
                    Quantity = random.Next(1, 50)
                };

                trades.Add(trade);
            }

            return trades;
        }

        //private HistoricalTrades()
        //{
        //    // Initialize the list of trades
        //    trades = new List<Trade>();
        //}

        //public static HistoricalTrades Instance
        //{
        //    get
        //    {
        //        // Lazy initialization: create the instance on first use
        //        if (instance == null)
        //        {
        //            instance = new HistoricalTrades();
        //        }
        //        return instance;
        //    }
        //}

        //public List<Trade> GetTrades()
        //{
        //    return trades;
        //}

        //public void AddTrade(Trade trade)
        //{
        //    trades.Add(trade);
        //}
    }

}