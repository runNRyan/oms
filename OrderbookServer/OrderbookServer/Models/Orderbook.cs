using OrderbookLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderbookServer.Models
{
    /// <summary>
    /// orderbook data in server 1ticker has 1orderbook 
    /// </summary>

    public class Orderbook
    {
        public readonly TickerList _ticker;
        public int CurrentPrice { get; private set; }
        public SortedDictionary<int, int> Bids { get; private set; }
        public SortedDictionary<int, int> Asks { get; private set; }

        private Queue<SingleOrder> OrderQueue= new Queue<SingleOrder>();
        private readonly object queueLock = new object();
        private readonly object executeLock = new object();
        private bool isRunning = true;

        public event Action<TickerList>? OrderbookChanged;
        public event Action<Trade>? TradeExecuted;

        /// <summary>
        /// order enqueuing 
        /// </summary>
        public void EnquequeOrder(SingleOrder order)
        {
            lock(queueLock)
            {
                OrderQueue.Enqueue(order);
                Monitor.Pulse(queueLock);
            }
        }
        
        /// <summary>
        /// process queue data
        /// </summary>
        private void ProcessQueue(object? state)
        {
            while (isRunning)
            {
                SingleOrder? order = null;
                lock(queueLock)
                {
                    if(!OrderQueue.TryDequeue(out order))
                    {
                        Monitor.Wait(queueLock);
                    }
                }
                if(order != null)
                {
                    ExecuteOrder(order);
                }
            }

        }
        
        
        /// <summary>
        /// for stopping processing 
        /// </summary>
        public void StopProcessing()
        {
            isRunning = false;
            lock (queueLock)
            {
                Monitor.Pulse(queueLock);  // Notify the processing thread to exit
            }
        }
        
        /// <summary>
        /// execute order and change bids & asks
        /// </summary>
        private void ExecuteOrder(SingleOrder order)
        {
            Debug.WriteLine($"Ticker : {_ticker} {order}");

            //int price = _random_trade[0];
            //int amount = _random_trade[1];
            int price = order._price;
            int amount = order._quantity;
            string side = order._quantity > 0 ? "BUY" : "SELL";

            List<int> matching_price = new List<int>();
            List<int> matching_quantities = new List<int>();

            int last_price = 0;
            int matching_quantity = 0;

            lock (executeLock)
            {

                if (amount > 0)  // bid order 
                {
                    foreach (var p in Asks)
                    {
                        if (p.Key <= price)
                        {
                            matching_price.Add(p.Key);
                            matching_quantities.Add(p.Value);
                            matching_quantity += p.Value;
                            last_price = p.Key;
                            if (matching_quantity >= amount)
                            {
                                break;
                            }
                        }
                        else
                            break;
                    }

                    for (int i = 0; i < matching_price.Count - 1; i++)
                    {
                        Asks.Remove(matching_price[i]);
                    }

                    if (matching_quantity > amount)
                    {
                        Asks[last_price] = matching_quantity - amount;
                    }
                    else if (matching_quantity == amount)
                    {
                        Asks.Remove(last_price);
                    }
                    else
                    {
                        Asks.Remove(last_price);
                        if (Bids.ContainsKey(price))
                            Bids[price] += amount - matching_quantity;
                        else
                            Bids[price] = amount - matching_quantity;
                    }

                }
                else            // ask order
                {
                    amount *= -1;
                    foreach (var p in Bids.Reverse())
                    {
                        if (p.Key >= price)
                        {
                            matching_price.Add(p.Key);
                            matching_quantities.Add(p.Value);
                            matching_quantity += p.Value;
                            last_price = p.Key;
                            if (matching_quantity >= amount)
                            {
                                break;
                            }

                        }
                        else
                            break;
                    }

                    for (int i = 0; i < matching_price.Count - 1; i++)
                    {
                        Bids.Remove(matching_price[i]);
                    }

                    if (matching_quantity > amount)
                    {
                        Bids[last_price] = matching_quantity - amount;
                    }
                    else if (matching_quantity == amount)
                    {
                        Bids.Remove(last_price);
                    }
                    else
                    {
                        Bids.Remove(last_price);
                        if (Asks.ContainsKey(price))
                            Asks[price] += amount - matching_quantity;
                        else

                            Asks[price] = amount - matching_quantity;
                    }

                }

            }
            if (matching_quantity > 0)
            {
                CurrentPrice = last_price;

                for (int i = 0; i < matching_price.Count-1; i++)
                {
                    TradeExecuted?.Invoke(new Trade
                    {
                        ExecuteTime = DateTime.Now,
                        Side = side,
                        Ticker = _ticker,
                        Price = matching_price[i],
                        Quantity = matching_quantities[i]
                    });
                    matching_quantity -= matching_quantities[i];
                }
                TradeExecuted?.Invoke(new Trade
                {
                    ExecuteTime = DateTime.Now,
                    Side = side,
                    Ticker = _ticker,
                    Price = last_price,
                    Quantity = Math.Min(matching_quantity, amount)
                }) ;

            }

            OrderbookChanged?.Invoke(_ticker);
        }

        public Orderbook(TickerList ticker, int currentPrice = 10000)
        {
            _ticker = ticker;
            CurrentPrice = currentPrice;
            Bids = GenerateRandomData(true);  // new SortedDictionary<int, int>();
            Asks = GenerateRandomData(false); // new SortedDictionary<int, int>();
            _ = ThreadPool.QueueUserWorkItem(ProcessQueue);
        }

        /// <summary>
        /// generate random orderbook when it start
        /// </summary>
        private SortedDictionary<int, int> GenerateRandomData(bool isBid, int currentPrice = 10000)
        {
            SortedDictionary<int, int> randomData = new SortedDictionary<int, int>();
            Random _random = new Random();
            int NumOfGenerting = 20;

            int multiple = isBid ? -1 : 1;
            int tickPice = (int)(currentPrice / 100);

            for (int i = 0; i < NumOfGenerting; i++)
            {
                int randomPrice = currentPrice + multiple * _random.Next(tickPice);
                int randomQuantity = _random.Next(1, 20); // -1 * multiple * _random.Next(1, 20);

                randomData[randomPrice] = randomData.ContainsKey(randomPrice) ? randomData[randomPrice] + randomQuantity : randomQuantity;
            }

            return randomData;
        }

    }
}