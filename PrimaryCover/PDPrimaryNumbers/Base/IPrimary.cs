using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDPrimaryNumbers.Base
{
    public interface IPrimary
    {
        bool IsPrimary(int N);
        int NextPrimary(int N);
        int Pi(int N);
    }

    public interface ICascadePrime
    {
        int Next();
    }
}
