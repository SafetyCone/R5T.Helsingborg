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
            var writer = Console.Out;
            var reader = Console.In;

            //// Does not work in remote debugger.
            //Console.WriteLine($"{nameof(Debugger)}.{nameof(Debugger.Break)}");
            //Debugger.Break();

            // This DOES work in a remote debugger.
            writer.WriteLine("Debugger attach point.");
            while(!Debugger.IsAttached)
            {
                writer.WriteLine("Waiting for debugger to attach...");
                writer.WriteLine("(Or press enter to continue)");

                var line = reader.ReadLine();
                if(String.IsNullOrEmpty(line))
                {
                    writer.WriteLine("Skipping debugger.");

                    break;
                }
            }
            writer.WriteLine("Continuing...");

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
