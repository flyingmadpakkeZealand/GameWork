using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sandbox.TestSpace2
{
    public class TestClass
    {
        public void Start()
        {
            Console.WriteLine("Getting first ten numbers: ");
            IEnumerator<int> enumerator = MethodA(5).GetEnumerator();
            for (int i = 0; i < 10; i++)
            {
                enumerator.MoveNext();
                Console.WriteLine(enumerator.Current);
            }
            enumerator.Dispose();
            Console.WriteLine();

            List<int> numbers = new List<int>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (int resultA in MethodA(5))
            {
                numbers.Add(resultA);
            }
            stopwatch.Stop();
            TimeSpan time = stopwatch.Elapsed;
            Console.WriteLine("Time using cached version: " + time);
            Console.WriteLine("Total numbers found: " + numbers.Count);
            Console.WriteLine();

            List<int> forNumbers = new List<int>();
            stopwatch.Restart();
            for (int i = 0; i < numbers.Count; i++)
            {
                forNumbers.Add(i);
            }
            stopwatch.Stop();
            Console.WriteLine($"Time adding {numbers.Count} numbers to list with for loop: "+ stopwatch.Elapsed);
            Console.WriteLine();

            List<int> foreachNumbers = new List<int>();
            stopwatch.Restart();
            foreach (int number in forNumbers)
            {
                foreachNumbers.Add(number);
            }
            stopwatch.Stop();
            Console.WriteLine($"Time enumerating (foreach) {forNumbers.Count} numbers and adding them to another list: " + stopwatch.Elapsed);
            Console.WriteLine();

            List<int> numbers2 = new List<int>();
            stopwatch.Restart();
            foreach (int resultA in MethodANoCache(5))
            {
                numbers2.Add(resultA);
            }
            stopwatch.Stop();
            TimeSpan time2 = stopwatch.Elapsed;
            Console.WriteLine("Time using no cached version: " + time2);
            Console.WriteLine("Total numbers found: " + numbers2.Count);
            Console.WriteLine();
            Console.WriteLine($"No cached version took {time2.TotalMilliseconds/time.TotalMilliseconds-1:P} more time than cached");
            Console.WriteLine();

            bool same = true;
            foreach ((int First, int Second) zip in numbers.Zip(numbers2))
            {
                if (zip.First != zip.Second)
                {
                    same = false;
                    break;
                }
            }

            Console.WriteLine("Data consistent: " + same);
        }

        private IEnumerable<int> MethodA(int seek)
        {
            if (seek == 1)
            {
                yield return 1;
                yield return 2;
                yield return 3;
                yield break;
            }

            List<int> cache = new List<int>();
            bool cacheFull = false;

            foreach (int resultA in MethodA(seek - 1))
            {
                if (!cacheFull)
                {
                    foreach (int resultB in MethodB(seek - 1))
                    {
                        yield return resultA + resultB;
                        cache.Add(resultB);
                    }

                    cacheFull = true;
                }
                else
                {
                    foreach (int resultB in cache)
                    {
                        yield return resultA + resultB;
                    }
                }
            }
        }

        private IEnumerable<int> MethodB(int seek)
        {
            foreach (int resultA in MethodA(seek))
            {
                yield return resultA;
            }
        }

        private IEnumerable<int> MethodANoCache(int seek)
        {
            if (seek == 1)
            {
                yield return 1;
                yield return 2;
                yield return 3;
                yield break;
            }

            foreach (int resultA in MethodANoCache(seek - 1))
            {
                foreach (int resultB in MethodBNoCache(seek - 1))
                {
                    yield return resultA + resultB;
                }
            }
        }

        private IEnumerable<int> MethodBNoCache(int seek)
        {
            foreach (int resultA in MethodANoCache(seek))
            {
                yield return resultA;
            }
        }
    }
}
