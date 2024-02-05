using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teilaufgabe1
{
    public enum Kartenfarbe
    {
        Karo,
        Herz,
        Pik,
        Kreuz
    }
    public enum Kartenwert { 
        Sieben, 
        Acht,
        Neun, 
        Zehn, 
        Bube, 
        Dame, 
        König, 
        Ass
    }
    public class Spielkarte
    {
        private Kartenwert _wert;

        private Kartenfarbe _farbe;

        public Kartenwert Wert
        {
            get { return Wert; }
        }

        public Kartenfarbe Farbe
        {
            get { return _farbe; }
        }
        public Spielkarte(Kartenwert wert,Kartenfarbe farbe) {
            _wert = wert;
            _farbe = farbe;
        }

        public static IEnumerable<Kartenfarbe> Kartenfarben() {
            foreach (Kartenfarbe farbe in Enum.GetValues(typeof(Kartenfarbe))) {  yield return farbe; }
        }
        public static IEnumerable<Kartenwert> Kartenwerte() {
            foreach (Kartenwert wert in Enum.GetValues(typeof (Kartenwert))) {  yield return wert; }
        }

        override
        public string ToString()
        {
            return _farbe.ToString() + "-" + _wert.ToString();
        }
    }
}
