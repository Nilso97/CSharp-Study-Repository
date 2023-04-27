namespace UnsafeConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Span<int> numbers = stackalloc int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

            Pointer pointer;

            unsafe
            {
                Pointer* p = &pointer;

                p->Value = 100;
                p->Value2 = 100;
                p->Value3 = 100;

                p->Left();

                Console.WriteLine($"Value 1 -> {p[0].Value}");
                Console.WriteLine($"Value 2 -> {p[0].Value2}");
                Console.WriteLine($"Value 3 -> {p[0].Value3}");
            }

            unsafe
            {
                fixed(int* i = &numbers[0])
                {
                    int x = 0;

                    reference:
                        Console.WriteLine(i[x]);
                        if (x > numbers.Length - 1)
                        {
                            return;
                        }
                        ++x;
                    goto reference;
                }
            }
        }

        public unsafe struct Pointer
        {
            public int Value;
            public int Value2;
            public int Value3;

            public void Right() 
            {
                fixed(int* i = &Value)
                {
                    ++i[2];
                }
            }

            public void Left()
            {
                fixed(int* i = &Value)
                {
                    --i[2];
                }
            }
        }
    }
}