// See https://aka.ms/new-console-template for more information
using System;

namespace Einsendeaufgabe
{
    class Program
    {
        public static void Main(string[] args)
        {
            Model model = new Model();
            Observer1 observer1 = new Observer1();
            Observer2 observer2 = new Observer2();
            Console.WriteLine("Press '1' to register Observer1 and Alt+1 to unregister Observer1.");
            Console.WriteLine("Press '2' to register Observer2 and Alt+2 to  unregister Observer2.");
            Console.WriteLine("Press any key to compute the next random number.");
            Console.WriteLine("Press the Escape (Esc) key to quit: \n");
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        if ((cki.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            Console.WriteLine("Unregister Observer1");
                            model.UnregisterObserver(observer1);
                        }
                        else
                        {
                            Console.WriteLine("Register Observer1");
                            model.RegisterObserver(observer1);
                        }
                        break;
                    case ConsoleKey.D2:
                        if ((cki.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            Console.WriteLine("Unregister Observer2");
                            model.UnregisterObserver(observer2);
                        }
                        else
                        {
                            Console.WriteLine("Register Observer2");
                            model.RegisterObserver(observer2);
                        }
                        break;
                }
                Console.WriteLine("\nModel computes next random number...");
                model.NextRandomNumber();
                Console.WriteLine();
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}