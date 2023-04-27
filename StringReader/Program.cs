using System.Text;

namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Caracteres na primeira linha para ler...");
            sb.AppendLine("Caracteres na segunda linha para ler...");
            sb.AppendLine("Caracteres na terceira linha para ler...");

            using var sr = new StringReader(sb.ToString());
            // var buffer = new char[10];

            // var length = 0;

            do
            {
                System.Console.WriteLine(sr.ReadLine());
            } while (sr.Peek() >= 0);

            // do
            // {
            //     buffer = new char[10];
            //     length = sr.Read(buffer);
            //     Console.Write($"{string.Join("", buffer)}");
            // } while (length >= buffer.Length);

            System.Console.WriteLine();
            System.Console.WriteLine("Pressione [ENTER] para finalizar...");
            Console.ReadKey();
        }
    }
}
