class Result
{
    private static HashSet<string> res = new HashSet<string>();
        

    /*
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
            var arr = w.ToArray();
            bool f1 = false;
            List<char> sub1 = new List<char>();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                sub1.Add(arr[i]);
                if (arr[i] > arr[i - 1])
                {
                    f1 = true;
                    break;
                }
            }

            if(!f1)
            {
                Console.WriteLine("no answer");
                return "no answer";
            }

            for(int i = 0; i < sub1.Count;i++)
            {
                if(sub1[i]>arr[arr.Length - sub1.Count - 1])
                {
                    char t = arr[arr.Length - sub1.Count - 1];
                    arr[arr.Length - sub1.Count - 1] = sub1[i];
                    sub1[i] = t;
                    break;
                }
            }

            var newSub = sub1.ToArray();
            Array.Sort(newSub);

            int index = 0;
            for(int i = arr.Length - sub1.Count; i< arr.Length;i++)
            {
                arr[i] = newSub[index++];
            }
            Console.WriteLine(new string(arr));
            return new string(arr);
    }

}