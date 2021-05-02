using System;
using System.Collections.Generic;

namespace a1
{
    class Program
    {
        private static HashSet<string> res = new HashSet<string>();
        // Prints the array
        static void printArr(char[] a, int n)
        {
            //for (int i = 0; i < n; i++)
            //    Console.Write(a[i]);
            var s = new String(a);
            if(!res.Contains(s))
            {
                res.Add(s);
            }
            //Console.WriteLine();
        }

        // Generating permutation using Heap Algorithm
        static void heapPermutation(char[] a, int size, int n)
        {
            // if size becomes 1 then prints the obtained
            // permutation
            if (size == 1)
                printArr(a, n);

            for (int i = 0; i < size; i++)
            {
                heapPermutation(a, size - 1, n);

                // if size is odd, swap 0th i.e (first) and
                // (size-1)th i.e (last) element
                if (size % 2 == 1)
                {
                    char temp = a[0];
                    a[0] = a[size - 1];
                    a[size - 1] = temp;
                }

                // If size is even, swap ith and
                // (size-1)th i.e (last) element
                else
                {
                    char temp = a[i];
                    a[i] = a[size - 1];
                    a[size - 1] = temp;
                }
            }
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

            var arr = new char[] { 'd','k','h','c' };

            var initA = new String(arr);

            heapPermutation(arr, arr.Length, arr.Length);

            var resA = new string[res.Count];
            res.CopyTo(resA);
            Array.Sort(resA);
            bool f = false;
            for(int i = 0; i < resA.Length; i++)
            {
                if(f && resA[i] != initA)
                {
                    Console.WriteLine(resA[i]);
                    break;
                }
                else if(resA[i] == initA)
                {
                    Console.WriteLine("===>" + resA[i]);
                    f = true;
                }
            }
        }
    }
}
