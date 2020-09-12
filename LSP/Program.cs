using System;
using System.Collections.Generic;

namespace LSP
{
    internal static class Program
    {
        private static void Main()
        {
            var adders = new List<AdderBase>
            {
                new AdderBase(),
                new GoodAdder(),
                new BadAdder(),
                new AnotherAdder()
            };

            PrintAdderResults(1, 1, adders);
            PrintAdderResultsLSPViolation(5, 5, adders);
        }

        // Follows the OCP, DIP, assumes the LSP
        private static void PrintAdderResults(int a, int b, IEnumerable<AdderBase> adders)
        {
            foreach (var adder in adders)
            {
                Console.WriteLine(adder.Add(a, b));
            }
        }

        /// <summary>
        /// If clients need to perform case analysis then your type violates the LSP
        /// </summary>
        private static void PrintAdderResultsLSPViolation(int a, int b, IEnumerable<AdderBase> adders)
        {
            foreach (var adder in adders)
            {
                // var bad = (BadAdder) adder;
                if (adder is BadAdder) continue;

                // var bad = adder as BadAdder;
                // if(bad != null) continue;

                Console.WriteLine(adder.Add(a, b));
            }
        }
    }
}
