using PDPrimaryNumbers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDPrimaryNumbers
{
    public class PrimaryNum : IPrimary
    {
        /// <summary>
        /// Метод проверяет необходимое условие простоты числа.
        /// </summary>
        /// <param name="N">Натруальное число.</param>
        /// <returns>true если необходимое условие простоты числа выполяется, false в противном случае.</returns>
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

        /// <summary>
        /// Метод проверяет достаточное условие простоты числа.
        /// </summary>
        /// <param name="N">Натуральное число.</param>
        /// <returns>tue если число простое, false в пртивоположном случае.</returns>
        bool SimpleCriterium(int N)
        {
            bool result = true;
            int N0 = Convert.ToInt32(Math.Sqrt(N)) + 1;

            for (int d = 5; d < N0; d += 2)
            {
                if (N % d == 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool IsPrimary(int N)
        {
            bool result = false;

            do
            {
                if (N < 2)
                    break;

                if (N < 4)
                {
                    result = true;
                    break;
                }

                if (N % 2 == 0)
                    break;

                if (!FermaCriterium(N))
                    break;

                if (!SimpleCriterium(N))
                    break;

                result = true;

            } while (false);

            return result;
        }

        public int Next(int N)
        {
            if (N < 2)
                return 2;

            int primary = (N % 2 == 0) ? N + 1 : N + 2;

            while (!FermaCriterium(primary) || !SimpleCriterium(primary))
            {
                primary += 2;
            }            

            return primary;
        }

        public int Pi(int N)
        {
            if (N < 2)
                return 0;

            int count = 1;

            for (int i = 3; i <= N; i += 2)
            {
                if (IsPrimary(i))
                    count++;
            }

            return count;
        }
    }
}
