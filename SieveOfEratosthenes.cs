using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbers
{
    class SieveOfEratosthenes : IPrimeCheckMethod
    {
        public bool IsPrime(int number)
        {
            bool[] sieve = new bool[number + 1];

            for (int i = 0; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }

            for (int i = 2; i*i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    for (int j = i * 2; j < sieve.Length; j += i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            if (sieve[number])
                return true;

            return false;
        }
    }
}
