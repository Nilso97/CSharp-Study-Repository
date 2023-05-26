using System.Diagnostics;

namespace EventsDelegatesUnsafe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----- [Calli] -----\n");
            
            var sw = new Stopwatch();

            var values = new int[100000000];

            sw.Start();

            unsafe
            {
                for (int i = 0; i < 100000000; i++)
                {
                    static T Calculate<T>
                        (delegate*<T, T, T> calculated, T x, T y)
                            => calculated(x, y);

                    var calc = Calculate(&Multiplicate, 25, 5);

                    values[i] = calc;

                    Console.WriteLine($"Resultado: {calc}");
                }
            }

            sw.Stop();

            Console.WriteLine($"----- {sw.ElapsedMilliseconds}ms -----");
        }

        public static int Multiplicate(int x, int y)
        {
            return x * y;
        }
    }
}