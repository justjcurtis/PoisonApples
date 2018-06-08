using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonApples
{
    class Program
    {
        static void Main(string[] args)
        {
            var prog = new Program();
            prog.Run();
        }

        private void Run()
        {
            var picker = new PickApples();
            var counter = new Count();

            var running = true;
            var loopcount = 0;
            
            while (running)
            {
                var a = loopcount * 10000;
                var b = a + 10000;
                
                Console.WriteLine("Picking Apples...");
                Console.WriteLine();

                var AllApples = picker.pickApples();

                counter.RunningCommentry(AllApples, a, b);

                counter.CreateSummery(AllApples, a, b);

                Console.WriteLine("Continue ? (y/n)");
                var Continue = Console.ReadLine();

                running = (Continue == "y");
                loopcount++;
            }

        }

    }
}
