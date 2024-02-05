using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe2
{
    public interface IInitializing<P>
    {
        void Initialize(P p);
    }
}
