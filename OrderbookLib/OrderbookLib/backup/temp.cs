




//private const int NumOfGenerting = 20;
//private System.Timers.Timer _timer;
//private Random _random = new Random();


//_timer = new System.Timers.Timer();
//SetRandomInterval();


//using System;
///// <summary>
///// generate random order 
///// </summary>
//private void GenerateRandomOrder()
//{
//    int multiple = _random.Next(2) == 0 ? 1 : -1;
//    int tickPice = (int)(CurrentPrice / 100);
//    // int randomPrice =
//    _random_trade[0] = CurrentPrice + multiple * _random.Next(tickPice);
//    // int randomQuantity =
//    _random_trade[1] = multiple * _random.Next(1, 20);
//}




//private void SetRandomInterval()
//{
//    // Generate a random interval between 1000 and 5000 milliseconds (1 to 5 seconds)
//    int randomInterval = _random.Next(1000, 5001);
//    _timer.Interval = randomInterval;
//}
//private int[] _random_trade = new int[2];




//using System;
//using System.Collections.Generic;
//using System.Threading;

//public class DataProcessor
//{
//    public void Process(string data)
//    {
//        Console.WriteLine("Processing data in DataProcessor: " + data);
//        // Add your specific data processing logic here
//    }
//}

//public class QueueManager
//{
//    private Queue<string> myQueue = new Queue<string>();
//    private readonly object queueLock = new object();
//    private bool isRunning = true;
//    private DataProcessor dataProcessor = new DataProcessor();

//    public void EnqueueData(string data)
//    {
//        lock (queueLock)
//        {
//            myQueue.Enqueue(data);
//            Monitor.Pulse(queueLock);  // Notify the processing thread that there's new data
//        }
//    }

//    public void StartProcessing()
//    {
//        ThreadPool.QueueUserWorkItem(ProcessQueue);
//    }

//    public void StopProcessing()
//    {
//        isRunning = false;
//        lock (queueLock)
//        {
//            Monitor.Pulse(queueLock);  // Notify the processing thread to exit
//        }
//    }

//    private void ProcessQueue(object state)
//    {
//        while (isRunning)
//        {
//            string data = null;
//            lock (queueLock)
//            {
//                if (myQueue.Count > 0)
//                {
//                    data = myQueue.Dequeue();
//                }
//                else
//                {
//                    Monitor.Wait(queueLock);  // Wait for new data to be added to the queue
//                }
//            }

//            if (data != null)
//            {
//                // Call the function to process the data
//                dataProcessor.Process(data);
//            }
//        }
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        QueueManager queueManager = new QueueManager();
//        queueManager.StartProcessing();

//        // Enqueue some data to trigger the processing function
//        queueManager.EnqueueData("Data 1");
//        queueManager.EnqueueData("Data 2");

//        // Simulate some delay before stopping processing
//        Thread.Sleep(3000);

//        queueManager.StopProcessing();
//    }
//}
