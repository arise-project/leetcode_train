class Result
{

    /*
     * Complete the 'absolutePermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     */

        public class A
        {
            public int a1 { get; set; }
            public int a2 { get; set; }
        }
        
    public static List<int> absolutePermutation(int n, int k)
    {
List<A> s = new List<A>();
            for (int i = 1; i <= n; i++)
            {
                var r = new A { a1 = k + i, a2 = i - k };
                if(r.a1 > n && r.a2 < 1)
                {
                    return new List<int> { -1};
                }
                if(r.a1 > r.a2)
                {
                    int t = r.a2;
                    r.a2 = r.a1;
                    r.a1 = t;
                }
                s.Add(r);
            }

                        
            var init = Enumerable.Range(1, n).ToList();
                List<int> res;
                if(k > 0 && n / k > 2 && n % k  == 0)
                {
                    for(int i = 0; i < init.Count;i+= 2*k)
                    {
                        for(int j=0;j<k;j++)
                        {
                            var t = init[i+j];
                            init[i] = init[i + k +j];
                            init[i + k + j] = t;
                        }
                    }
                    res = init;
                }
                else
                {
                    res = init.Skip(k).Union(init.Take(k)).ToList();
                }
            
            return res;
    }

}