using System;
using System.Diagnostics;
using System.Threading;

using R5T.Helsingborg.Lib;


namespace R5T.Helsingborg
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Does not work in remote debugger.
            //Console.WriteLine($"{nameof(Debugger)}.{nameof(Debugger.Break)}");
            //Debugger.Break();

            Console.WriteLine("Debugger attach point.");
            while(!Debugger.IsAttached)
            {
                Console.WriteLine("Waiting for debugger to attach...");

                Thread.Sleep(1000);
            }

            Program.SubMain();
        }

        private static void SubMain()
        {
            var baseMessage = "This is the SubMain message.";

            var messageCount = 0;

            while(true)
            {
                var message = $"{baseMessage} (count: {++messageCount})";

                Utilities.PrintMessage(message);

                var sleepMilliseconds = 1000;

                Thread.Sleep(sleepMilliseconds);
            }
        }
    }
}
