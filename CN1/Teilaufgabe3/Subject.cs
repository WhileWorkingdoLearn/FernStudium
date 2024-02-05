using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einsendeaufgabe
{
    internal class Subject : IObservable  
    {
        private List<IObserver> observers = new List<IObserver>();

        public void NotifyObservers(Model m)
        {
            foreach (var observer in observers)
            {
                if (observer != null)
                {
                    observer.DisplayNumber(m);
                }
            }
    
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove(observer);          
        }
    }
}
