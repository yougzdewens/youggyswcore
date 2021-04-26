using System;
using System.IO;
using System.Net;
using System.Timers;

namespace YouggySW
{
    class Program
    {
        private static System.Timers.Timer aTimer;

        static void Main(string[] args)
        {    
            ////aTimer = new System.Timers.Timer(86400000);
            //aTimer = new System.Timers.Timer(5000);
            //aTimer.Elapsed += OnTimedEvent;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;

            //Console.ReadLine();

            LaunchProcess();
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            LaunchProcess();
        }

        private static void LaunchProcess()
        {
            Core.GetStockDataCore getStockDataCore = new Core.GetStockDataCore();

            getStockDataCore.StartGetData();
        }
    }
}
