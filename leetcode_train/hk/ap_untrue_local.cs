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
            public int a1 { get; set; }
            public int a2 { get; set; }
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
            var tests = new List<A> {
                new A { a1 = 69187, a2 = 0 },
                new A { a1 = 55596, a2 =42041 },
                new A { a1 = 49056, a2 =0 },
                new A { a1 = 93559, a2 =72338 },
                new A { a1 = 1394, a2 =0 },
                new A { a1 = 68546, a2 =34273 },
                new A { a1 = 4979, a2 =3186 },
                new A { a1 = 89291, a2 =0 },
                new A { a1 = 86542, a2 =1 },
                new A { a1 = 69652, a2 =0 },
            };
            //69187, 0
            //55596, 42041
            //49056, 0
            //93559, 72338
            //1394, 0
            //68546, 34273
            //4979, 3186
            //89291, 0
            //------ > 86542, 1
            //69652, 0
            File.Delete(@"c:\1.txt");
            foreach(var test in tests)
            {
                List<A> s = new List<A>();
                bool skip = false;
                for (int i = 1; i <= test.a1; i++)
                {
                    var r = new A { a1 = test.a2 + i, a2 = i - test.a2 };
                    if (r.a1 > test.a1 && r.a2 < 1)
                    {
                        skip = true;
                        break;
                    }
                    if (r.a1 > r.a2)
                    {
                        int t = r.a2;
                        r.a2 = r.a1;
                        r.a1 = t;
                    }
                    s.Add(r);
                }

                if(skip)
                {
                    File.AppendAllLines(@"c:\1.txt", new string[] { "-1" });
                    continue;
                }

                var init = Enumerable.Range(1, test.a1).ToList();
                List<int> res;
                if(test.a2 > 0 && test.a1 / test.a2 > 2 && test.a1 % test.a2  == 0)
                {
                    for(int i = 0; i < init.Count;i+= 2*test.a2)
                    {
                        for(int j=0;j<test.a2;j++)
                        {
                            var t = init[i+j];
                            init[i] = init[i + test.a2 +j];
                            init[i + test.a2 + j] = t;
                        }
                    }
                    res = init;
                }
                else
                {
                    res = init.Skip(test.a2).Union(init.Take(test.a2)).ToList();
                }
                
                File.AppendAllLines(@"c:\1.txt", new string[] { string.Join(" ", res) } );
            }

            var origin = File.ReadAllLines(@"F:\ca\amazon\output09.txt");
            var result = File.ReadAllLines(@"c:\1.txt");

            for(int i =0; i < result.Length;i++)
            {
                if(origin[i] == result[i])
                {
                    //Console.WriteLine("{0}, {1}", tests[i].a1, tests[i].a2);
                }
                else
                {
                    Console.WriteLine("------>{0}, {1}", tests[i].a1, tests[i].a2);
                    Console.WriteLine(origin[i]);
                }
            }
        }
    }
}
