// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Security.Cryptography;
using Teilaufgabe2;

namespace Einsendeaufgabe
{
    public class ConvertToHex {

        public static void ConvertHexToBinaryOpenConsole()
        {

                Console.WriteLine("Geben Sie eine 8-stellige Hexadezimalzahl ein:");
                string answer = Console.ReadLine().ToString();

                if (answer != null &&  answer.Length ==  8){
                      // Erzeugt ein Neues Object, welches den Parameter Hexwert in die entsprechenden Werte konvertiert  
                    new HexObj(answer).PrintValues();
               
                } else
            {
                Console.WriteLine("Hexzahl muss 8 Zeichen lang sein");
            }
            

        }

        // Mehtode hier für die Formale Aufgabenstellung. Code ist entsprechend auch im HexObj hinterlegt.
        private static string hexStringToBinary(string hexNumber) {
            int hexAsInt = Convert.ToInt32(hexNumber, 16);
            return Convert.ToString(hexAsInt, 2);
        }

        public static void Main(string[] args)
        {
            // Starte Consoleneingabe
            ConvertToHex.ConvertHexToBinaryOpenConsole();
        } 
    }
}