namespace Teilaufgabe3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teilaufgabe 2: ");
            Zufallszahlen();
            Console.WriteLine();
            Console.WriteLine("Teilaufgabe 3: ");
            Fussballvereine();
        }
        public static void Zufallszahlen()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            SortedTrashContainer<int> trash = new SortedTrashContainer<int>(10);
            //trash.Remove(); // InvalidOperationException("Der Mülleimer ist leer.");
            for (int i = 0; i < trash.Capacity; i++) trash.Add(random.Next(10));
            System.Diagnostics.Debug.Assert(trash.isFull, "Der Mülleimer ist nicht voll.");
            //trash.Add(10); // InvalidOperationException("Der Mülleimer ist voll.");
            Console.WriteLine("== Zufallszahlen ==");
            foreach (var item in trash) Console.Write(item + " ");
            trash.Remove();
            System.Diagnostics.Debug.Assert(!trash.isFull, "Der Mülleimer ist noch voll.");
            trash.Clear();
            System.Diagnostics.Debug.Assert(trash.Count == 0, "Der Mülleimer ist nicht leer.");
            Console.WriteLine();
        }

        public static void Fussballvereine()
        {
            Fussballverein v1 = new Fussballverein
            {
                Name = "FC Bayern München",
                Punkte = 68,
                Tordifferenz = 56
            };
            Fussballverein v2 = new Fussballverein
            {
                Name = "1. FSV Mainz 05",
                Punkte = 29,
                Tordifferenz = -11
            };
            Fussballverein v3 = new Fussballverein
            {
                Name = "FC Augsburg",
                Punkte = 29,
                Tordifferenz = -19
            };
            Fussballverein v4 = new Fussballverein
            {
                Name = "Borussia Dortmund",
                Punkte = 50,
                Tordifferenz = 27
            };
            SortedTrashContainer<Fussballverein> bundesliga = new SortedTrashContainer<Fussballverein>(4);
            bundesliga.Add(v4);
            bundesliga.Add(v2);
            bundesliga.Add(v1);
            bundesliga.Add(v3);
            Console.WriteLine("== Erste Bundesliga ==");
           foreach (var item in bundesliga) Console.WriteLine(item.Name);
        }
    }
}