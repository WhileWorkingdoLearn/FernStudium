using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe1
{
    internal class Config
    {
       private int _delayInMilliseconds = 200;
       
        public int DelayInMilliseconds
        {
            get { return _delayInMilliseconds; }
        }

        private bool _done;

        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }


        /*
         Der Parameter increment kann positiv oder negativ sein, je nachdem ob man die Pause nach 
        einem Wort verkürzen oder verlängern möchte. Die neue Dauer darf jedoch nicht kleiner als
        100ms und nicht größer als 1000ms werden. Außerdem muss das Ändern des Wertes threadsicher sein
         */
        


        public void UpdateDelay(int increment) {
            lock (this)
            {
                if (_delayInMilliseconds + increment < 100)
                {
                    return;
                }
                if (_delayInMilliseconds + increment > 1000)
                {
                    return;
                }
                _delayInMilliseconds += increment;
            }
        }
    

    }
}
