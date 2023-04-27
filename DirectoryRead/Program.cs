namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = "/home/nilsojr/Documentos/Trabalhando com Arquivos e Streams em C#/Directory/Globo";

            // ReadDirectory(path);

            ReadFiles(path);

            System.Console.WriteLine("Digite [ENTER] para finalizar...");
            Console.ReadLine();
        }

        public static void ReadFiles(string path)
        {
            var files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                
                Console.WriteLine($"[Nome]: {fileInfo.Name}");
                Console.WriteLine($"[Último acesso]: {fileInfo.LastAccessTime}");
                Console.WriteLine($"[Tamanho]: {fileInfo.Length}");
                Console.WriteLine($"[Último acesso]: {fileInfo.LastAccessTime}");
                Console.WriteLine($"[Pasta]: {fileInfo.DirectoryName}");

                System.Console.WriteLine("--------------------");
            }
        }

        public static void ReadDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

                foreach (var dir in directories)
                {
                    var dirInfo = new DirectoryInfo(dir);

                    Console.WriteLine($"[Nome]: {dirInfo.Name}");
                    Console.WriteLine($"[Raiz]: {dirInfo.Root}");

                    if (dirInfo.Parent != null) Console.WriteLine($"[Pai]: {dirInfo.Parent.Name}");

                    System.Console.WriteLine("--------------------");
                }
            } 
            else
            {
                Console.WriteLine($"Diretório {path} não existe!");
            }
        }
    }
}
