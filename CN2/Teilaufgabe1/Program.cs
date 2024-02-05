namespace Teilaufgabe1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kartenfarben: ");
            foreach (Kartenfarbe farbe in Spielkarte.Kartenfarben())
            {
                Console.Write(farbe + " ");
            }
            Console.WriteLine();
            Console.Write("Kartenwerte: ");
            foreach (Kartenwert wert in Spielkarte.Kartenwerte())
            {
                Console.Write(wert + " ");
            }
            Console.WriteLine();

            IEnumerable<Spielkarte> Kartenspiel = from farbe in Spielkarte.Kartenfarben()
                                                  from wert in Spielkarte.Kartenwerte()
                                                  select new Spielkarte(wert, farbe);
            Console.Write("Kartenspiel: ");
            foreach (Spielkarte k in Kartenspiel)
            {
                Console.Write(k + " ");
            }
            
            Console.WriteLine();
            Console.Write("Asse: ");
            // IEnumerable<Spielkarte> Asse = from karte in Kartenspiel where karte.Wert.Equals(Kartenwert.Ass) select karte; throws stack overflow error;
            IEnumerable <Spielkarte> Asse = from farbe in Spielkarte.Kartenfarben()
                                              from wert in Spielkarte.Kartenwerte()
                                              where (wert.Equals(Kartenwert.Ass))
                                              select new Spielkarte(wert, farbe);

            foreach (Spielkarte k in Asse) Console.Write(k + " ");
            Console.WriteLine();
            
            var Spielkarten = Kartenspiel.Take(16).MischenMit(Kartenspiel.Skip(16));
            Console.Write("Spielkarten: ");
            foreach (var k in Spielkarten) Console.Write(k + " ");
            Console.WriteLine("\nSpielkarten gemischt: "
            + !Kartenspiel.VergleichenMit(Spielkarten));
        }
    }
}