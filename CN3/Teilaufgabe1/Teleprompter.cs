using Microsoft.VisualBasic;

namespace Teilaufgabe1
{
    internal class Teleprompter
    {
        static void Main(string[] args)
        {

            Console.WriteLine("[Press Esc to stop the teleprompter, '<' or '-' to slowdown and '>' or '+' to speed up.]\n");
            StartTeleprompter().Wait();
            Console.WriteLine("\n\n[Press Return to exit.]");
            Console.ReadLine();
        }
        private static Task GetInputAsync(Config config)
        {
            Task task = new Task(cfg =>
            {
                if (cfg == null) throw new ArgumentNullException(nameof(cfg));

                Config configuration = (Config)cfg;
                ConsoleKeyInfo keyInput;

                do
                {
                    keyInput = Console.ReadKey();
                    switch (keyInput.KeyChar.ToString())
                    {
                        
                        case "+":
                        case ">":
                            Console.WriteLine(configuration.DelayInMilliseconds);
                            configuration.UpdateDelay(100);
                            break;
                        case "-":
                        case "<":
                            Console.WriteLine(configuration.DelayInMilliseconds);
                            configuration.UpdateDelay(-100);
                            break;
                    }
                } while (keyInput.Key != ConsoleKey.Escape);


                cfg = true;

            }, config);

            task.Start();

            return task;
        }

        private static Task ShowTextAsync(Config config)
        {
            Task task = new Task(cfg =>
            {
                if (cfg == null) throw new ArgumentNullException(nameof(cfg));
                Config configuration = (Config)cfg;
                foreach (var word in ReadFrom(@"D:\Programmieren\Projects\dotNet\Einsendeaufgaben\CN3\Teilaufgabe1\Quotes.txt"))
                {
                    Console.Write(word + " ");
                    Thread.Sleep(configuration.DelayInMilliseconds);
                }

            }, config);
            task.Start ();
            return task;
        }

        private static Task StartTeleprompter()
        {
            Config cfg = new Config();
            Task getInput = GetInputAsync(cfg);
            Task showText = ShowTextAsync(cfg);
            return Task.Run(() =>
            {
                Task.WaitAll(getInput, showText);
            });
        }

        /*
 Diese Methode liest die Datei zeilenweise ein und gibt die einzelnen Wörter mit »yield return« zurück.
Falls eine Zeile mehr als 70 Zeichen enthält, dann soll ein zusätzlicher Zeilenumbruch mit yield return Environment.
NewLine« hinzugefügt werden.
 */
        private static IEnumerable<string> ReadFrom(string file)
        {
           
            var reader = new StreamReader(file);
          
            while (reader.Peek() != -1)
            {
                var line = reader.ReadLine();
              
                var words = line?.Split(' ');

                foreach(var word in words)
                {
                    yield return word;
                }
                if (line != null && line.Length > 70)
                {
                   // Console.WriteLine(line.Length + " laenger als 70.");
                    yield return "" + Environment.NewLine;
                }
            }
            
            reader.Close();

        }
    }
}