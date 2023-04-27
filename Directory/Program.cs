using System.IO;

namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDirectory();

            CreateFile();

            var origin = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
            var destiny = Path.Combine(Environment.CurrentDirectory, 
                "Globo",
                "América do Sul",
                "Brasil",
                "brasil.txt"
            );

            MoveFile(origin, destiny);

            var origin_ = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
            var destiny_ = Path.Combine(Environment.CurrentDirectory, 
                "Globo",
                "América do Sul",
                "Argentina",
                "argentina.txt"
            );
            
            CopyFile(origin_, destiny_);
        }

        public static void CreateDirectory()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Globo");

            if (!Directory.Exists(path))
            {
                var directory = Directory.CreateDirectory(path);

                var dirAmNorth = directory.CreateSubdirectory("América do Norte");
                var dirAmCentral = directory.CreateSubdirectory("América Central");
                var dirAmSouth = directory.CreateSubdirectory("América do Sul");

                dirAmNorth.CreateSubdirectory("USA");
                dirAmNorth.CreateSubdirectory("México");
                dirAmNorth.CreateSubdirectory("Canada");

                dirAmCentral.CreateSubdirectory("Costa Rica");
                dirAmCentral.CreateSubdirectory("Panama");

                dirAmSouth.CreateSubdirectory("Brasil");
                dirAmSouth.CreateSubdirectory("Argentina");
                dirAmSouth.CreateSubdirectory("Paraguai");
            }
        }

        public static void CreateFile()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
            using var sw = File.CreateText(path);

            if (!File.Exists(path))
            {
                sw.WriteLine("População: 213MM");
                sw.WriteLine("IDH: 0,901");
                sw.WriteLine("Dados atualizados em: 17/03/2023");
            }
        }

        public static void CopyFile(string pathOrigin, string pathDestination)
        {
            if (!File.Exists(pathOrigin))
            {
                System.Console.WriteLine("Erro ao mover arquivo! Arquivo de origem não existe.");
                
                return;
            }

            if (File.Exists(pathDestination))
            {
                System.Console.WriteLine($"Arquivo já existente no diretório: {pathDestination}");
                
                return;
            }

            File.Copy(pathOrigin, pathDestination);
        }

        public static void MoveFile(string pathOrigin, string pathDestination)
        {
            if (!File.Exists(pathOrigin))
            {
                System.Console.WriteLine("Erro ao mover arquivo! Arquivo de origem não existe.");
                
                return;
            }

            if (File.Exists(pathDestination))
            {
                System.Console.WriteLine($"Arquivo já existente no diretório: {pathDestination}");

                return;
            }

            File.Move(pathOrigin, pathDestination);
        }
    }
}
