using System;
using System.Diagnostics;
using System.IO;


//github nothr branch that has parallelization thingy, run tomorrow
namespace ADS
{
    class Program
    {
        static void Main(string[] args)
        {
            //range of values of n to test
            int[] testValues = { 1, 2, 5, 10, 20, 25, 50, 100, 150, 200, 500, 1000 };
            //int[] testValues = Enumerable.Range(1, 1000).ToArray(); // Generates numbers 1 to 1000
            string csvFilepath = "Project1ADS.csv"; //path to save csv file

            // Initialize StreamWriter to write data to CSV file
            using (StreamWriter writer = new StreamWriter(csvFilepath))
            {
                writer.WriteLine("n,O(n^2) Time(ms),O(2^n) Time(ms)");

                foreach (int n in testValues)
                {
                    // Run each algorithm 5 times and average the results
                    long fib1TotalTime = 0;
                    long fib2TotalTime = 0;
                    int repeat = 5;

                    for (int i = 0; i < repeat; i++)
                    {
                        //fibonacci O(n^2) - Matrix exponentiation with artificial complexity
                        Stopwatch sw = Stopwatch.StartNew();
                        Fibonacci1(n);
                        sw.Stop();
                        fib1TotalTime += sw.ElapsedTicks; // More precision than ms
                        //long fib1time = sw.ElapsedMilliseconds;

                        //fibonacci O(2^n) - Naive recursion (exponential recursive algorithm)
                        sw.Restart();
                        Fibonacci2(n);
                        sw.Stop();
                        fib2TotalTime += sw.ElapsedTicks;
                        //long fib2time = sw.ElapsedMilliseconds;
                    }
                    // Average the times over the 5 runs
                    long fib1AvgTime = fib1TotalTime / repeat;
                    long fib2AvgTime = fib2TotalTime / repeat;

                    // Write the results to CSV (convert ticks to milliseconds)

                    writer.WriteLine($"{n},{fib1AvgTime / (TimeSpan.TicksPerMillisecond)},{fib2AvgTime / (TimeSpan.TicksPerMillisecond)}");
                    Console.WriteLine($"n={n}: O(n^2) took {fib1AvgTime / TimeSpan.TicksPerMillisecond} ms, O(2^n) took {fib2AvgTime / TimeSpan.TicksPerMillisecond} ms");
                }
                
            }
            Console.WriteLine($"Computation complete. Results saved to {csvFilepath}");
        }
        //fibonnaci sequence with artificial O(n^2) complexity
        public static int Fibonacci1(int n)
        {
            if (n <= 1)
                return n;

            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            // Build the Fibonacci sequence up to n
            for (int i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];

                // Artificial slowdown to simulate O(n^2) complexity
                for (int j = 0; j < i; j++)
                {
                    // Just an empty loop to add extra work
                }
            }

            return fib[n];
        }

        //fibonnaci sequence naive recursion O(2^n)
        public static int Fibonacci2(int n)
        {
            if (n <= 1)
                return n;
            return Fibonacci2(n - 1) + Fibonacci2(n - 2);
        }
    }

}