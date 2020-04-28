using Shop.View;
using System;
using System.Threading;
using System.Timers;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //aTimer.Interval = 10;
            aTimer.AutoReset = false;
            aTimer.Start();
            Thread.Sleep(4000);
            Console.Clear();
            Console.CursorVisible = true;
            Display display = new Display();

        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.CursorVisible = false;
            Console.WriteLine(new string(' ', 20));
            Console.WriteLine(new string(' ', 20));
            Console.WriteLine(new string(' ', 20));
            Console.WriteLine(new string(' ', 20));
            Console.WriteLine(new string(' ', 10));
            Console.Write(new string(' ', 2));
            Console.WriteLine(new string('*', 41));
            Console.Write(new string(' ', 2));
            Console.WriteLine("* SHOP Created by: Muhamed and Plmanena *");
            Console.Write(new string(' ', 2));
            Console.WriteLine(new string('*', 41));

        }




        //static void Main(string[] args)
        //{
        //        Display display = new Display();

        //        // Restore original colors  
        //        Console.ResetColor();
        //}
    }
}
