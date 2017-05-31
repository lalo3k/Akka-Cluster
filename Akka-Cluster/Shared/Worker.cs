using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared
{
    public class Worker : ReceiveActor
    {
        public Worker()
        {
            Receive<CalculateAmicableNumbers>(_ => HandleCalculation(_));
        }

        private void HandleCalculation(CalculateAmicableNumbers message)
        {
            Console.WriteLine($"All amicable numbers below {message.Number} on {Self.Path}");

            HashSet<int> amicableInts = new HashSet<int>();
            for (int i = 2; i <= message.Number; i++)
            {
                if (!amicableInts.Contains(i))
                {
                    int amicableCounterPart;
                    if (TryGetAmicableCounterPart(i, out amicableCounterPart))
                    {
                        Console.WriteLine($"Amicable Pair:: {i}, {amicableCounterPart}");
                    }
                }
            }
            Thread.Sleep(1000);
        }

        private static bool TryGetAmicableCounterPart(int value, out int amicableCounterPart)
        {
            var valueDivisorSum = GetDivisorSum(value);
            if (valueDivisorSum != 0 && valueDivisorSum != value && GetDivisorSum(valueDivisorSum) == value)
            {
                amicableCounterPart = valueDivisorSum;
                return true;
            }
            amicableCounterPart = 0;
            return false;
        }

        private static int GetDivisorSum(int value)
        {
            var divisorSum = 1;
            var counter = 1;
            while (++counter * counter <= value)
            {
                if (value % counter != 0)
                {
                    continue;
                }
                divisorSum += counter;
                var quotient = value / counter;
                if (quotient != counter)
                {
                    divisorSum += quotient;
                }
            }
            return divisorSum;
        }
    }
}
