using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace a1
{
    class Program
    {
        public class A
        {
            public int K { get; set; }
            public int C { get; set; }
        }

        static void Main(string[] args)
        {
            //var r = new Random((int)DateTime.Now.Ticks);
            //var n = r.Next(5, 10);
            //char[] arr = new char[n];
            //Console.WriteLine("init:");
            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = (char)r.Next('a', 'z');
            //    Console.Write(arr[i]);
            //}

            //Console.WriteLine();
            //Console.WriteLine();

            //var rand = new Random((int)DateTime.Now.Ticks);
            //int n = rand.Next(5, 20);
            //int k = rand.Next(2, 10);

            //string s = File.ReadAllText(@"F:\ca\amazon\input13.txt");
            string s = "abcdefghhgfedecba";

            Console.WriteLine(Func(s));
    }

        private static string Func(string s)
        {

            Dictionary<int, A> h = new Dictionary<int, A>();
            int[] arr = s.ToArray().Select(l => (int)l).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (h.ContainsKey(arr[i]))
                {
                    h[arr[i]].C++;
                }
                else
                {
                    h.Add(arr[i], new A { K = arr[i], C = 1 });
                }
            }

            var values = h.Values.OrderByDescending(v => v.C);
            Console.WriteLine(string.Join("", values.Select(v => (char)v.K + v.C.ToString())));
            int c = -1;
            bool remove = false;
            bool first = true;
            foreach (var v in values)
            {
                Console.WriteLine("{0}->{1}", (char)v.K, v.C);
                if (c == -1)
                {
                    first = true;
                    c = v.C;
                }
                else if (v.C != c)
                {
                    if (v.C == 1)
                    {
                        if (!remove)
                        {
                            remove = true;
                        }
                        else
                        {
                            return "NO";
                        }
                    }
                    else
                    {
                        if (!remove && v.C + 1 == c)
                        {
                            remove = true;
                        }
                        else if (!remove && v.C - 1 == c)
                        {
                            remove = true;
                        } else if (!remove && v.C == c + 1)
                        {
                            c = c - 1;
                            remove = true;
                        } else if (!remove && c == 1 && first)
                        {
                            c = v.C;
                            remove = true;
                        }
                        else
                        {
                            return "NO";
                        }
                    }
                    first = false;
                }
            }

            return "YES";
        }
    }
    }
