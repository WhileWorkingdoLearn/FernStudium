using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einsendeaufgabe
{
    internal interface IObservable
    {
        void NotifyObservers(Model o);
        void RegisterObserver(IObserver observer);

        void UnregisterObserver(IObserver observer);
    }
}
