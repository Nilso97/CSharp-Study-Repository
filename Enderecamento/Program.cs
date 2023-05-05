namespace Enderecamento
{
    public class Program
    {
        public static void Main(String[] args)
        {
            // Value Types -> Stack
            int sideA = 5;
            int sideB = 10;
            int squareArea = CalculateSquareArea(ref sideA);

            Console.WriteLine(sideA);
            Console.WriteLine(sideB);
            Console.WriteLine(squareArea + "\n");

            // Reference Type -> Heap
            var rectangle1 = new Rectangle();
            var rectangle2 = new Rectangle();

            rectangle1.SideA = 100;
            rectangle1.SideB = 200;

            rectangle2.SideA = 300;
            rectangle2.SideB = 400;

            rectangle1 = rectangle2; // apontamento (ponteiro*)

            rectangle2.SideA = 1;

            Console.WriteLine($"Retângulo 1 (Lado A) -> {rectangle1.SideA}");
            Console.WriteLine($"Retângulo 1 (Lado B) -> {rectangle1.SideB}");

            Console.WriteLine($"Retângulo 2 (Lado A) -> {rectangle2.SideA}");
            Console.WriteLine($"Retângulo 2 (Lado B) -> {rectangle2.SideB}");

            int CalculateSquareArea(ref int side)
            {
                side = side * side;

                return side;
            }
        }

    }
}

// class, struct, record
public class Rectangle
{
    public int SideA { get; set; }
    public int SideB { get; set; }
}