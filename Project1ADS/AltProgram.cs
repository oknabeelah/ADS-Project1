using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks; // Required for Task

namespace ADS
{
    class Program1
    {
        static void Main(string[] args)
        {
            // Your code for testing Fibonacci algorithms
            int[] testValues = { 5, 10, 15, 20, 25, 30 };

            Parallel.ForEach(testValues, n =>
            {
                RunTestsForN(n);
            });

            Console.WriteLine("Computation complete.");
        }

        static void RunTestsForN(int n)
        {
            int repeat = 5;
            long fib1TotalTime = 0;
            long fib2TotalTime = 0;

            for (int i = 0; i < repeat; i++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                Fibonacci1(n);
                stopwatch.Stop();
                fib1TotalTime += stopwatch.ElapsedTicks;

                stopwatch.Restart();
                Fibonacci2(n);
                stopwatch.Stop();
                fib2TotalTime += stopwatch.ElapsedTicks;
            }

            long fib1AvgTime = fib1TotalTime / repeat;
            long fib2AvgTime = fib2TotalTime / repeat;

            Console.WriteLine($"n={n}: O(n^2) avg time: {fib1AvgTime / TimeSpan.TicksPerMillisecond} ms, O(2^n) avg time: {fib2AvgTime / TimeSpan.TicksPerMillisecond} ms");
        }

        public static int Fibonacci1(int n)
        {
            if (n <= 1)
                return n;

            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
                for (int j = 0; j < i; j++) { }
            }

            return fib[n];
        }

        public static int Fibonacci2(int n)
        {
            if (n <= 1)
                return n;
            return Fibonacci2(n - 1) + Fibonacci2(n - 2);
        }
    }
}
