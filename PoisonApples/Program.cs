using System;

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

            var running = true;
            var loopcount = 0;
            while (running)
            {
                var a = loopcount * 10000;
                var b = a + 10000;
                var picker = new PickApples();
                var AllApples = picker.pickApples();
                
                foreach (var apple in AllApples)
                {
                    Console.WriteLine($"Apple {a} is {apple.Colour}");
                    if (apple.Poisoned)
                    {
                        Console.WriteLine("...it's poisoned btw.");
                    }
                    a++;
                    if (a > b) break;
                }
                Console.WriteLine("Continue ? (y/n)");
                var Continue = Console.ReadLine();

                running = (Continue == "y");
                loopcount++;
            }
        }
    }
}
