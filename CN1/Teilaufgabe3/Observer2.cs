using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einsendeaufgabe
{
    internal class Observer2 : IObserver
    {
        public void DisplayNumber(Model m)
        {
            
            String answer = "";
            for (int i = 0; i < m.RandomNumber; i++)
            {
                answer += "#";
            }
            Console.WriteLine(answer);
        }
    }
}
