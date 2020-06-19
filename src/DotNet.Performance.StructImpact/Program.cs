using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DotNet.Performance.StructImpact
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfPoints = 10_000_000;

            var points = new List<Point3_3>(numberOfPoints);
            for (var i = 0; i < numberOfPoints; i++)
            {
                points.Add(new Point3_3
                {
                    X = i,
                    Y = i,
                    Z = i
                });
            }

            Console.WriteLine($"{points.Count} points created.");
            Console.WriteLine($"{Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} memory allocated.");

            var before0 = GC.CollectionCount(0);
            var pointToFind = new Point3_3 { X = -1, Y = -1, Z = -1 };

            var sw = Stopwatch.StartNew();
            var contains = points.Contains(pointToFind);
            sw.Stop();

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - before0}");
            Console.WriteLine("Done!");

            // Original - class
            // 480 memory allocated.
            // Tempo total: 98ms
            // GC Gen #0 : 0

            // Version2 - struct
            // 246 memory allocated.
            // Tempo total: 2555ms
            // GC Gen #0 : 561

            // Version2 - struct com equals
            // 246 memory allocated.
            // Tempo total: 170ms
            // GC Gen #0 : 127

            // Version3 - struct com equals tipado
            // 246 memory allocated.
            // Tempo total: 48ms
            // GC Gen #0 : 0
        }
    }
}
