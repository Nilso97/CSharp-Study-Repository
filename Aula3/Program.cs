using System.Diagnostics;

namespace DelegatesEvents
{
    public delegate int Calculate(int x, int y);

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("----- [Callvirt] -----\n");

            var sw = new Stopwatch();

            var values = new int[100000000];

            sw.Start();

            for (int i = 0; i < 100000000; i++)
            {
                var calc = new Calculate(Multiplicate);
            
                var result = calc(15, 3); // or calc.Invoke(15, 3)
                values[i] = result;

                Console.WriteLine($"Resultado: {result}");
            }

            sw.Stop(); 

            Console.WriteLine($"\n----- {sw.ElapsedMilliseconds}ms -----");
        }

        public static int Multiplicate(int x, int y)
        {
            return x * y;
        }
    }
}