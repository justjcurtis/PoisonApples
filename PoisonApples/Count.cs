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

            var appleList = AllApples.Take(b).ToList().Skip(a).Take(b-a);

            var AllPoisoned = appleList.Where(apple => apple.Poisoned).ToList();

            var SecondBiggestGroup = AllPoisoned.GroupBy(apple => apple.Colour).OrderBy(g => g.Count()).ToList()[1].ToList();

            var LargestNonPoisonedRedAppleStreak = appleList.Aggregate(
                    new { Streak = 0, count = 0 },
                    (agg, apple) => apple.Poisoned == false && apple.Colour == "Red" ?
                    new { Streak = Math.Max(agg.Streak, agg.count + 1), count = agg.count + 1 } :
                    new { agg.Streak, count = 0 },
                    agg => agg.Streak);

            var DoubleGreenApples = appleList.Aggregate(
                    new { Counter = 0, smallCounter = 0 },
                    (agg, apple) => apple.Colour == "Green" ?
                    new { Counter = agg.Counter + agg.smallCounter, smallCounter = agg.smallCounter + 1 } :
                    new { agg.Counter, smallCounter = 0 },
                    agg => agg.Counter);

            Console.WriteLine("Summary Compiled.");
            Console.WriteLine("Findings : ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine($"{AllPoisoned.Count()} apples were poisoned in total.");
            Console.WriteLine($"{SecondBiggestGroup.Count()} of all the poisoned apples were {SecondBiggestGroup.First().Colour} making this the second biggest poisoned group.");
            Console.WriteLine($"The largest 'streak' of Red apples that were safe to eat was {LargestNonPoisonedRedAppleStreak}.");
            Console.WriteLine($"out of the {b-a} apples checked, you could get 2 green apples in a row {DoubleGreenApples} times.");
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }
}
