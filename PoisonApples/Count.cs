using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonApples
{
    public class Count
    {

        public void RunningCommentry(IEnumerable<Apple> AllApples, int a, int b)
        { 
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
            Console.WriteLine();
        }
        
        public void CreateSummery(IEnumerable<Apple> AllApples, int a, int b)
        {
            Console.WriteLine("Creating Summary...");
            Console.WriteLine();

            var AllPoisoned = AllApples.Skip(a).Take(10000).Where(apple => apple.Poisoned).ToList();

            var SecondBiggestGroup = AllPoisoned.GroupBy(apple => apple.Colour).OrderBy(g => g.Count()).ToList()[1].ToList().First().Colour;

            var x = String.Join(", ", AllApples.Skip(a).Take(10000).ToList().Select(apple => apple.Poisoned.ToString() + " - " + apple.Colour));//.Replace(", True, ", "#").Split('#').OrderByDescending(s => s.Length).First().Length / 7;
            
            //var LargestNonPoisonedRedAppleStreak = 

            Console.WriteLine();
        }
    }
}
