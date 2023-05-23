namespace DelegatesEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var figure = new GeometricFigure()
            {
                Height = 10,
                Width = 10,
                Depth = 10
            };

            figure.Calculate += new Calculation(CalculateSquareArea);
            figure.Calculate += new Calculation(CalculateCubeVolume);

            figure.EventHandler();
        }

        public static void CalculateSquareArea
            (double height, double width, double depth)
        {
            var area = (height * width);

            Console.WriteLine("--- Evento disparado da classe cliente [ÁREA QUADRADO] ---");
            Console.WriteLine($"Área -> {area}");
        }

        public static void CalculateCubeVolume
            (double height, double width, double depth)
        {
            var volume = (height * width * depth);

            Console.WriteLine("--- Evento disparado da classe cliente [VOLUME CUBO] ---");
            Console.WriteLine($"Volume -> {volume}");
        }
    }
}