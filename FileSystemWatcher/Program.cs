namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = "/home/nilsojr/Documentos/Globo";

            using var fsw = new FileSystemWatcher(path);

            fsw.Created += OnCreated;
            fsw.Renamed += OnRenamed;
            fsw.Deleted += OnDeleted;

            fsw.EnableRaisingEvents = true; 

            fsw.IncludeSubdirectories = true; 

            Console.WriteLine($"Monitorando eventos na pasta {path}");

            System.Console.WriteLine("Pressione [ENTER] para finalizar...");
            Console.ReadLine();
        }

        public static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Foi criado o arquivo {e.Name}");
        }

        public static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Foi renomeado o arquivo {e.OldName} para {e.Name}");
        }

        public static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Foi deletado o arquivo {e.Name}");
        }
    }
}
