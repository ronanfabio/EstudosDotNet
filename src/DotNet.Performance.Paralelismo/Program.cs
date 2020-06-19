using System;
using System.Diagnostics;

namespace DotNet.Performance.Paralelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);

            sw.Start();
            var result = Version5.PrimesInRange(200, 800_000);
            sw.Stop();

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds / 1000}s com {Environment.ProcessorCount} processadores");
            Console.WriteLine($"GC Gen #2 : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1 : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - before0}");
            Console.WriteLine($"Localizados {result} números primos no intervalo");
            Console.WriteLine("Done!");

            // Original - Sem paralelismo
            // Tempo total: 115s com 4 processadores
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0

            // Version 2 - Com threads e com concorrencia a variavel acumuladora
            //Tempo total: 48s com 4 processadores
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0

            // Version 3 - Com threads e sem concorrencia a variavel acumuladora
            // Tempo total: 50s com 4 processadores
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0

            // Version4 - Com ThreadPool
            // Tempo total: 34s com 4 processadores
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0

            // Version5 - Com Parallel
            // Tempo total: 28s com 4 processadores
            // GC Gen #2 : 0
            // GC Gen #1 : 0
            // GC Gen #0 : 0
        }
    }
}
