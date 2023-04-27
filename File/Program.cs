using System.IO;

namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name;

            System.Console.WriteLine("Digite o nome do arquivo que deseja criar:");
            name = Console.ReadLine();
            
            name = FileNameCorrector(name); 

            var path = Path.Combine(Environment.CurrentDirectory, $"{name}.txt");

            CreateFile(path);

            System.Console.WriteLine();

            System.Console.WriteLine("Aperte ENTER para finalizar.");
            Console.ReadLine();
        }

        public static string FileNameCorrector(string name)
        {
            foreach (var @char in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(@char, '-');
            }

            return name;
        }

        public static void CreateFile(string path)
        {
            try
            {
                using var sw = File.CreateText(path);

                sw.WriteLine("Hello World!");
                sw.WriteLine("Olá Mundo!");   
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("O nome do arquivo está inválido!");
            }
        }
    }
}
