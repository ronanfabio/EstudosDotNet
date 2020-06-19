using System;
using System.Threading;
using System.Linq;

namespace DotNet.Performance.Paralelismo
{
    public class Version3
    {
        public static long PrimesInRange(long start, long end)
        {
            var range = end - start;
            var numberOfThreads = (long)Environment.ProcessorCount;

            var threads = new Thread[numberOfThreads];
            var results = new long[numberOfThreads];

            var chunkSize = range / numberOfThreads;

            for (long i = 0; i < numberOfThreads; i++)
            {
                var chunkStart = start + i * chunkSize;
                var chunkEnd = (i == (numberOfThreads - 1)) ? end : chunkStart + chunkSize;
                var current = i;

                threads[i] = new Thread(() =>
                {
                    results[current] = 0;
                    for (var number = chunkStart; number < chunkEnd; ++number)
                    {
                        if (IsPrime(number))
                        {
                            results[current]++;
                        }
                    }
                });

                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return results.Sum();
        }

        private static bool IsPrime(long number)
        {
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (long divisor = 3; divisor < (number / 2); divisor += 2)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
