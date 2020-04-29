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
            aTimer.AutoReset = false;
            aTimer.Start();
            Thread.Sleep(7000);
            Console.CursorVisible = true;
            Display display = new Display();

        }
        /// <summary>
        /// Splash screen with countdown timer.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            for (int a = 6; a > 0; a--)
            {
            Console.CursorVisible = false;
            Console.Write(new string(' ', 2));
            Console.WriteLine(new string('*', 40));
            Console.Write(new string(' ', 2));
            Console.WriteLine("* Shop Created by Muhamed and Plmanena *");
            Console.Write(new string(' ', 2));
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("");
            Console.Write("The program will start after: {0}", a);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            }


        }
    }
}
