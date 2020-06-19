using System;
using System.Diagnostics;

namespace DotNet.Performance.GCImpact
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);
            Func<string, bool> sut = Version5.ValidarCPF;

            sw.Start();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (!sut("771.189.500-33"))
                {
                    throw new Exception("Error!");
                }

                if (sut("771.189.500-34"))
                {
                    throw new Exception("Error!");
                }
            }
            sw.Stop();

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"GC Gen #2 : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1 : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - before0}");
            Console.WriteLine("Done!");

            // Original
            // Tempo total: 1934ms
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 275

            // Version2
            // Tempo total: 1028ms
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 61

            // Version 3
            // Tempo total: 2147ms
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0

            // Version 4
            // Tempo total: 448ms
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0

            // Version 5
            // Tempo total: 544ms
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0
        }
    }
}
