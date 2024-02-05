// See https://aka.ms/new-console-template for more information
using System.Text;


namespace Einsendeaufgabe
{
    class Converter
    {
        public static void ConvertToBinary()
        {
            Console.WriteLine("Geben Sie bitte eine natürliche Zahl ein:");

            String answer = Console.ReadLine();

            int intNumber;

            while (!Int32.TryParse(answer, out  intNumber) || intNumber < 1)
            {
                
                Console.WriteLine("Ungültige Eingabe.");
                Console.WriteLine("Geben Sie bitte eine natürliche Zahl ein:");
                answer = Console.ReadLine();

            }
  
            Console.WriteLine(Converter.ToBinary(intNumber));
            
        }
        
        public static String ToBinary(int value)
        {
           // if (value < 1) throw new ArgumentException("Ungueltige Eingabe");

            StringBuilder stringBuilder = new StringBuilder();

            while (value > 0)
            {

                int intAsByte = value % 2;
                value /=  2;
                stringBuilder.Insert(0, intAsByte);
            }
           

            return stringBuilder.ToString();
        }
        
        static void Main(string[] args)
        {
            Converter.ConvertToBinary();
        }
    }
}