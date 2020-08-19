using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sheet_calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(50);
            Console.WriteLine($"Start date: {startDate.ToLongDateString()}");

            /*
             path:/home/eugene/Projects/leetcode_train/sheet/algorithms_leetcode.csv
             path:/home/eugene/Projects/leetcode_train/sheet/js_algo_book.csv
             path:/home/eugene/Projects/leetcode_train/sheet/amazon_interview.csv
             path:/home/eugene/Projects/leetcode_train/sheet/labuladong_book.csv
             */
            bool addSheet = true;
            var sheets = new List<string> { 
            "/home/eugene/Projects/leetcode_train/sheet/algorithms_leetcode.csv",
            "/home/eugene/Projects/leetcode_train/sheet/js_algo_book.csv",
            "/home/eugene/Projects/leetcode_train/sheet/amazon_interview.csv",
            "/home/eugene/Projects/leetcode_train/sheet/labuladong_book.csv" };

            /*
            Console.WriteLine($"Enter sheets:");
            while (addSheet)
            {
                Console.Write("path:");
                var sheet = Console.ReadLine();
                if(File.Exists(sheet))
                {
                    sheets.Add(sheet);
                }
                if(sheet == "exit")
                {
                    addSheet = false;
                }
            }
            */

            var data = new Dictionary<string, string[]>();
            foreach(var sheet in sheets)
            {
                var fileName = Path.GetFileNameWithoutExtension(sheet);
                var lines = File.ReadLines(sheet).ToArray();

                data.Add(fileName, lines);
            }

            int[] numbers = data.Select(d => d.Value.Length).ToArray();
            double[] indices = new double[numbers.Length];
            double[] speeds = numbers.Select(n => (double)n / numbers.Max() * 2).ToArray();



            Console.WriteLine($"Shedule:");
            Console.WriteLine();
            Console.WriteLine();

            while (startDate < endDate)
            {
                Console.WriteLine("===================================");

                Console.WriteLine($"Day: {startDate.ToLongDateString()}");
                Console.WriteLine();
                Console.WriteLine("Tasks:");
                int i = 0;
                foreach(var sheet in data.Keys)
                {
                    Console.WriteLine($"{sheet} : {data[sheet][(int)indices[i]]}");
                    indices[i] += speeds[i];
                    i++;
                }

                startDate = startDate.AddDays(1);
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine();
            }


        }
    }
}
