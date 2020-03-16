using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDPrimaryNumbers.Base
{
    public interface IPrimary
    {
        /// <summary>
        /// Метод проверяет является ли число простым.
        /// </summary>
        /// <param name="N">Натуральное число.</param>
        /// <returns>true если число простое, false в противном случае.</returns>
        bool IsPrimary(int N);

        /// <summary>
        /// Метод ищет следующие простое число после N.
        /// </summary>
        /// <param name="N">Натуральное число, после которого ищется следующее простое число.</param>
        /// <returns>Следующее простое число.</returns>
        int Next(int N);

        /// <summary>
        /// Метод ищет количество простых числе меньших чем N.
        /// </summary>
        /// <param name="N"></param>
        /// <returns>Количество простых числе меньших чем N</returns>
        int Pi(int N);
    }

    public interface ICascadePrime
    {
        /// <summary>
        /// Метод ищет следующие простое число после N.
        /// </summary>
        /// <param name="N">Натуральное число, после которого ищется следующее простое число.</param>
        /// <returns>Следующее простое число.</returns>
        int Next();
    }
}
