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

                p->Value_1 = 100;
                p->Value_2 = 200;
                p->Value_3 = 300;

                p->Left();

                Console.WriteLine($"Value 1: {p[0].Value_1}");
                Console.WriteLine($"Value 2: {p[0].Value_2}");
                Console.WriteLine($"Value 3: {p[0].Value_3}\n");

                fixed(int* i = &numbers[0])
                {
                    int x = 0;

                    reference:
                        Console.WriteLine(i[x]);

                        if (x == numbers.Length - 1) 
                            return;
                        ++x;
                    goto reference;
                }
            }
        }

        public unsafe struct Pointer
        {
            public int Value_1;
            public int Value_2;
            public int Value_3;

            public void Right()
            {
                fixed(int* i = &Value_1)
                {
                    ++i[2];
                }
            }

            public void Left()
            {
                fixed(int* i = &Value_1)
                {
                    --i[1];
                }
            }           
        }
    }
}