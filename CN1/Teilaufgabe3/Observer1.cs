using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einsendeaufgabe
{
    internal class Observer1 : IObserver
    {
        public void DisplayNumber(Model m)
        {
            Console.WriteLine("" + m.RandomNumber);
        }
    }
}
