using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe2
{
    internal class HexObj
    {
        private string _hex;

        private int _hexAsInt;

        private string _hexAsBinary;

        private float _hexAsFloat;

        private string _signBit;
        
        private string _exponent;

        private string _fraction;

        public HexObj(string hex) {
                init(hex);
        }

        private void init(string init)
        {
            // init wird im Konstruktor als auch über die Setter Methode des Objects aufgerufen

            if (init.Length != 8) { throw new InvalidOperationException("HEX must be 8 digits long"); }

            // Convertierung des HEX String, in die entsprechenden Wertde.
            this._hex = init;

            // Umwandlung des HEX-String in einen Integer
            this._hexAsInt = Convert.ToInt32(_hex, 16);

            // Umwanldung des Integers in die Binärdarstellung
            this._hexAsBinary = Convert.ToString(_hexAsInt, 2);

            // Falls Binärdarstellung nur 31  digits lang ist, wird eine 0 vorangesetzt.
            this._hexAsBinary = this._hexAsBinary.Length < 32 ? "0" + this._hexAsBinary : this._hexAsBinary;

            // Zerlegung der Dualzahl in seine einzelnen Komponenten nach IEEE-754-Format: 
            this._signBit = this._hexAsBinary.Substring(0, 1);

            this._exponent =  this._hexAsBinary.Substring(1, 8);

            this._fraction = this._hexAsBinary.Substring(9).TrimEnd('0');

            // Konvertierung der dualzahl in eine Gleitzahl
            this._hexAsFloat = BitConverter.ToSingle(BitConverter.GetBytes(this._hexAsInt), 0);

            
        }

        public string Hex
        {
            set
            {
                init(value);
            }

            get { return this._hex; } }

        public int HexAsInt 
        {
            get { return _hexAsInt; }
        }

        public string HexAsBinary
        {
            get { return _hexAsBinary; }
        }

        public float HexAsFloat 
        { 
            get { return _hexAsFloat; }
        }

        public string SignBit
        {
            get { return _signBit; }
        }

        public string Exponent
        {
            get {return _exponent; }
        }

        public string Fraction
        { get { return _fraction; }
        
        }

        public string getSign()
        {
            return this._signBit == "1" ? "-" : "+";
        }

        public int getExponentAsInt()
        {
            return Convert.ToInt32(_exponent, 2);
        }
        public void PrintValues()
        {
            string resultString = "";

            string binearzahl = "0x" + this._hex + " als Binärzahl: " + this._hexAsBinary;

            String vorzeichen = "Vorzeichenbit: " + this._signBit + " => '" + this.getSign() + "'";

            int e = this.getExponentAsInt() - 127;

            string charakteristik = "Charakteristik: " + "C =" + this._exponent + "=" + this.getExponentAsInt() + " => Exponent E=C-127=" + e;

            string mantisse = "1," + this._fraction;

            string normalisierteDualzahl = "Normalisierte Darstellung als Binärzahl: " + this.getSign() + mantisse + "*2^" + e;

            double doubleM = Convert.ToDouble(this.getSign() + mantisse);

            string gleitkommazahl = "Als Gleitkommazahl: " + this._hexAsFloat;

            string nl = "\n";

            resultString = binearzahl
                + nl
                + vorzeichen
                + nl
                + charakteristik
                + nl
                + mantisse
                + nl
                + normalisierteDualzahl
                + nl
                + gleitkommazahl;

            Console.WriteLine(resultString);
        }

    }
}
