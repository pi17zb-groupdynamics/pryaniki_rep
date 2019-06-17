using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbers
{
    class MillerRabin : IPrimeCheckMethod
    {
        public bool IsPrime(int number)
        {
            int k = Math.Max(2, Convert.ToInt32(Math.Log(number, 2)));
            if ((number < 2) || (number % 2 == 0)) return (number == 2);

            int s = number - 1;
            while (s % 2 == 0) s >>= 1;

            Random r = new Random();
            for (int i = 0; i < k; i++)
            {
                int a = r.Next(number - 1) + 1;
                int temp = s;
                long mod = 1;
                for (int j = 0; j < temp; ++j) mod = (mod * a) % number;
                while (temp != number - 1 && mod != 1 && mod != number - 1)
                {
                    mod = (mod * mod) % number;
                    temp *= 2;
                }

                if (mod != number - 1 && temp % 2 == 0) return false;
            }
            return true;
        }
    }
}
