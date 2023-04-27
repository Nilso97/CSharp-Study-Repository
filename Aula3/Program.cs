using System.Diagnostics;

namespace DelegatesEvents
{
    // Callvirt
    public delegate int Calculate(int x, int y);

    internal class Program
    {
        private static void Main(string[] args)
        {
            var sw = new Stopwatch();

            sw.Start();

            var values = new int[10000000];

            for (int i = 0; i < 10000000; i++)
            {
                var calc = new Calculate(Multiplicate);
                var result = calc(15, 3);
                values[i] = result;
            }

            sw.Stop();

            Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds} ms");
        }

        public static int Multiplicate(int x, int y)
        {
            return x * y;
        }
    }
}

