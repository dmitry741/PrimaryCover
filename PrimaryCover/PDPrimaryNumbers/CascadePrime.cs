using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDPrimaryNumbers
{
    public class CascadePrime : Base.ICascadePrime
    {
        List<int> _primes = new List<int>();

        bool FermaCriterium(int N)
        {
            long P = 1;
            const int c_shift = 16;
            int Div = (N - 1) / c_shift;
            int Rem = (N - 1) % c_shift;

            for (int i = 0; i < Div; i++)
            {
                P <<= c_shift;

                if (P > N)
                {
                    P %= N;
                }
            }

            return ((P << Rem) % N == 1);
        }

        public void Reset()
        {
            _primes.Clear();
        }

        public int Next()
        {
            int prime;
            int count = _primes.Count();

            if (count > 0)
            {
                int last = _primes[count - 1];
                int N = (last % 2 == 0) ? last + 1 : last + 2;
               
                while (true)
                {
                    if (!FermaCriterium(N))
                    {
                        N += 2;
                        continue;
                    }

                    int root = Convert.ToInt32(Math.Sqrt(N)) + 1;
                    bool bOut = false;

                    foreach (int p in _primes)
                    {
                        if (p > root)
                            break;

                        if (N % p == 0)
                        {
                            bOut = true;
                            break;
                        }
                    }

                    if (!bOut)
                    {
                        prime = N;
                        break;
                    }

                    N += 2;
                }

            }
            else
            {
                prime = 2;
            }

            _primes.Add(prime);

            return prime;
        }
    }
}
