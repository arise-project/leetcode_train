using System;
using System.Collections.Generic;
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

            var rand = new Random((int)DateTime.Now.Ticks);
            int n = rand.Next(5, 20);
            int k = rand.Next(2, 10);

            Console.WriteLine("n={0}",n);
            Console.WriteLine("k={0}", k);
            List<A> s = new List<A>();
            for (int i = 1; i <= n; i++)
            {
                var r = new A { a1 = k + i, a2 = i - k };
                if(r.a1 > n && r.a2 < 1)
                {
                    return;
                }
                if(r.a1 > r.a2)
                {
                    int t = r.a2;
                    r.a2 = r.a1;
                    r.a1 = t;
                }
                s.Add(r);
            }

            
            int b = 0;
            while(b <= Math.Pow(2,n))
            {
                int curr = b;
                var c1 = new HashSet<int>(Enumerable.Range(1, n));
                bool f = true;
                List<int> res = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    int select = s[i].a1;
                    if((curr & 1) == 1)
                    {
                        select = s[i].a2;
                    }
                    if(!c1.Contains(select))
                    {
                        f = false;
                        break;
                    }
                    res.Add(select);
                    curr = curr >> 1;
                }

                if(f)
                {
                    Console.WriteLine(string.Join(",", res));
                    return;
                }
                b = b + 1;
            }
        }
    }
}
