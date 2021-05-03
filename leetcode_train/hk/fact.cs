class Result
{

        public static BigInteger ipow(int b, int exp)
        {
            BigInteger result = 1;
            BigInteger bigb = b;
            for (; ; )
            {
                if ((exp & 1) == 1)
                    result *= bigb;
                exp >>= 1;
                if (exp == 0)
                    break;
                bigb *= bigb;
            }

            return result;
        }

        //https://www.geeksforgeeks.org/print-all-prime-numbers-less-than-or-equal-to-n/
        public static bool isPrime(int n)
        {
            // Corner cases
            if (n <= 1)
                return false;
            if (n <= 3)
                return true;

            // This is checked so
            // that we can skip
            // middle five numbers
            // in below loop
            if (n % 2 == 0 ||
                n % 3 == 0)
                return false;

            for (int i = 5;
                     i * i <= n; i = i + 6)
                if (n % i == 0 ||
                    n % (i + 2) == 0)
                    return false;

            return true;
        }

        static IEnumerable<int> primeList(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                if (isPrime(i))
                    yield return i;
            }
        }

        public static int d(int n, int k)
        {
            int sum = 0;

            int pow = k;
            int quotient = 1;
            while (quotient > 0)
            {
                quotient = n / pow;
                sum += quotient;
                pow*=k;
            }

            return sum;
        }


        //https://janmr.com/blog/2010/10/prime-factors-of-factorial-numbers/
        //https://codereview.stackexchange.com/questions/90911/calculating-the-factorial-of-a-number-efficiently/90941
        public static BigInteger factorailPrime(int n)
        {
            var primes = primeList(n);
            var expo = primes.Select(p => d(n, p)).ToArray();
            var multi = primes.Select((p, i) => ipow(p, expo[i])).ToArray();
            BigInteger result = new BigInteger(1);
            for(int i=0; i<multi.Length;i++)
            {
                result *= multi[i];
            }

            return result;
        }
        
    /*
     * Complete the 'extraLongFactorials' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void extraLongFactorials(int n)
    {
        Console.WriteLine(factorailPrime(n));
    }

}