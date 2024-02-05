using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe1
{
    public static class Erweiterungsmethoden
    {
        public static IEnumerable<T> MischenMit<T>(this IEnumerable<T> stapel1,IEnumerable<T> stapel2)
        {
            if (stapel1 == null || stapel2 == null) throw new ArgumentNullException();
            if(stapel1.Count() != stapel2.Count()) throw new ArgumentException("Cards must have the same count! count was: var1" + stapel1.Count() + " : var2 " + stapel2.Count());

            var sequenceOne = stapel1.GetEnumerator();
            var secquenceTwo = stapel2.GetEnumerator();
            while (sequenceOne.MoveNext() && secquenceTwo.MoveNext())
            {
                yield return sequenceOne.Current;
                yield return secquenceTwo.Current;
            }

        }
        public static bool VergleichenMit<T>(this IEnumerable<T> stapel1, IEnumerable<T> stapel2)
        {
            if (stapel1 == null || stapel2 == null) throw new ArgumentNullException();
            if (stapel1.Count() != stapel2.Count()) throw new ArgumentException("Cards must have the same count! count was: var1" + stapel1.Count() + " : var2 " + stapel2.Count());

            bool state = true;
            var sequenceOne = stapel1.GetEnumerator();
            var secquenceTwo = stapel2.GetEnumerator();
            while (sequenceOne.MoveNext() && secquenceTwo.MoveNext())
            {
                if(!sequenceOne.Current.Equals( secquenceTwo.Current))
                {
                    state = false;
                    break;
                }
            }
            return state;
        }
    }
}
