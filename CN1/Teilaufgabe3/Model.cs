using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Einsendeaufgabe
{
    internal class Model : Subject
    {
        private Random _random;

        private int randomNumber;

        public int RandomNumber { 
            get {
                return randomNumber; 
            }
            set
            {
                randomNumber = value;
            }
        }

        public Model() {
            _random = new Random();
            randomNumber = _random.Next(1, 51);
        }


        public void NextRandomNumber() {
            randomNumber =  _random.Next(1, 51);
            NotifyObservers(this);
        }
    }
}
