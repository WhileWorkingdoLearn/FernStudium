using System.Text.Json;
using System.Threading;
using System.Xml.Serialization;

namespace Teilaufgabe2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior[] warriors = new Warrior[] {
                new Warrior() {
                                    Name = "Gimli", Weapons = new Weapon[] {
                                            new Weapon() { Type = "battleaxe", Range = WeaponRange.Middle },
                                            new Weapon() {Type = "knife", Range = WeaponRange.Short }
                               }
                 },
                new Warrior() { Name = "Legolas", Weapons = new Weapon[] {
                                            new Weapon() { Type = "longbow", Range = WeaponRange.Long },
                                            new Weapon() { Type = "knife", Range = WeaponRange.Short }
                                }
                 }
            };
            CreateXmlFile(@"C:\Temp\warriors.xml", warriors);
            CreateJsonFile(@"C:\Temp\warriors.json", warriors);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void CreateJsonFile(string file, Warrior[] warriors)
        {
            FileStream stream = new FileStream(file, FileMode.Create);
            JsonSerializer.Serialize<Warrior[]>(stream, warriors);
            stream.Close();
        }

        private static void CreateXmlFile(string file, Warrior[] warriors)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Warrior[]));
            FileStream stream = new FileStream(file, FileMode.Create);
            serializer.Serialize(stream, warriors);
            stream.Close();
        
        }
    }
}