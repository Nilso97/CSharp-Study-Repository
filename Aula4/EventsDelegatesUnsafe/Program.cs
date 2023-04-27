using System.Diagnostics;

namespace EventsDelegatesUnsafe
{
    // Callin
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var values = new int[10000000];

            sw.Start();
            unsafe
            {
                for (int i = 0; i < 10000000; i++)
                {
                    static T Calculate<T>(delegate*<T, T, T> calculated, T x, T y) => calculated(x, y);

                    var calc = Calculate(&Multiplicate, 25, 5);

                    values[i] = calc;
                }
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