using System;

namespace PrimeNumbers
{
    class BustDivisors : IPrimeCheckMethod
    {
        public int Number { get; private set; }
        public bool Result { get; private set; }
        public bool IsPrime(Progress progress)
        {
            int a = 0;
            if (Number <= 1)
                a++;
            if (Number == 2)
                return Result = true;
            if (Number % 2 == 0)
                a++;
            for (int i = 3; i * i <= Number; i += 2)
            {
                progress((int) i * 100 / Number);
                if (Number % i == 0)
                    a++;
            }
            if (a > 2)
                return Result = false;
            return Result = true;
        }
    }
}
