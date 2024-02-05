namespace Teilaufgabe2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory<A, String>("en-US");
            foreach (var item in factory.MakeItems(3))
            {
                Console.Write(item.Culture + " ");
            }
            Console.ReadKey(true);
        }
    }
}