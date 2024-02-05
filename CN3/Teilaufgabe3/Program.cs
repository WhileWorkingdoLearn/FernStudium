using System.Collections.Concurrent;
using System.Diagnostics;

namespace Teilaufgabe3
{
    internal class Program
    {
        private const int NumberOfRobots = 10;
        private const int NumberOfChargingStations = 4;

        private static readonly BlockingCollection<Robot> WartesSchlange = new BlockingCollection<Robot>(NumberOfChargingStations);

        private Task[] consumer = new Task[NumberOfChargingStations];

        static void Main(string[] args)
        {
            ErzeugerProzess(RoboterErzeugen());
            VerbraucherProzess();

            //Alternative Realisierung mithilfe der Parallel-Klasse
            //VerbraucherProzessParallel();
        }

        private static Robot[] RoboterErzeugen()
        {  
            Random random = new Random(DateTime.Now.Millisecond);

            Robot[] robots = new Robot[NumberOfRobots];

            for (int i = 0; i < NumberOfRobots; i++)
            {
                robots[i] = new Robot
                {
                    Number = i + 1,
                    ChargeTime = random.Next(10, 20),
                    BatteryLifeTime = random.Next(5, 10)
                };
            }
            return robots;
        }
        private static void ErzeugerProzess(Robot[] robots)
        {

            Task.Run(() =>
            {
                Console.WriteLine("Producer ist running");

                Stopwatch watch = Stopwatch.StartNew();

                foreach (var robot in robots)
                {
                    if (robot.BatteryLifeTime > (int) watch.ElapsedMilliseconds)
                    {
                        WartesSchlange.Add(robot);

                        Console.WriteLine("Roboter {0} mit Batterielaufzeit {1} steht in der Warteschlange", robot.Number, robot.BatteryLifeTime);
                    }
                    else
                    {
                        Console.WriteLine("Roboter {0} mit Batterielaufzeit {1} hat keine Energie mehr.", robot.Number, robot.BatteryLifeTime);
                    }

                }
                watch.Stop();
                WartesSchlange.CompleteAdding();
                Console.WriteLine("Der Erzeugerprozess wird beendet");
            });
            
        }

        private static void VerbraucherProzess()
        {
            Task[] consumer = new Task[NumberOfChargingStations];

            for (int i = 0; i < consumer.Length; i++)
            {
                consumer[i] = Task.Factory.StartNew(() => {

                    while (!WartesSchlange.IsCompleted)
                    {
                        Robot robot = null;

                        try
                        {
                            robot = WartesSchlange.Take();
                        }
                        catch (InvalidOperationException) { }

                        if (robot != null)
                        {
                            Console.WriteLine("Roboter {0} wird an Ladestation {1} aufgeladen. Ladezeit: {2} Sekunden", robot.Number, Thread.CurrentThread.ManagedThreadId, robot.ChargeTime);
                            Thread.Sleep(robot.ChargeTime * 1000);
                            Console.WriteLine("Roboter {0} ist voll Aufgeladen", robot.Number);
                        }
                    }
                    Console.WriteLine("Ladestation {0} ist fertig", Thread.CurrentThread.ManagedThreadId);
                });
            }
            Task.WaitAll(consumer);

            Console.ReadKey();
        }

        private static void VerbraucherProzessParallel()
        {

            Parallel.ForEach(WartesSchlange.GetConsumingEnumerable(), new ParallelOptions() { MaxDegreeOfParallelism = NumberOfChargingStations }, (robot,id) =>
            {
                Console.WriteLine("Roboter {0} wird an Ladestation {1} aufgeladen. Ladezeit: {2} Sekunden", robot.Number, Thread.CurrentThread.ManagedThreadId, robot.ChargeTime);
                Thread.Sleep(robot.ChargeTime * 1000);
                Console.WriteLine("Roboter {0} ist voll Aufgeladen", robot.Number);
            });

        }
       
    }
}