namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateCsv();

            Console.WriteLine("\n\nPressione [ENTER] para finalizar.");
            Console.ReadLine();
        }

        public static void CreateCsv()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Output");

            var persons = new List<Person>()
            {
                new Person()
                {
                    Name = "José da Silva",
                    Email = "js@gmail.com",
                    Telephone = 123456,
                    BirthDate = new DateOnly(year: 1970, month: 2, day: 14)
                },

                new Person()
                {
                    Name = "Pedro Paiva",
                    Email = "pp@gmail.com",
                    Telephone = 456789,
                    BirthDate = new DateOnly(year: 2002, month: 4, day: 20)
                },

                new Person()
                {
                    Name = "Maria Antonia",
                    Email = "ma@gmail.com",
                    Telephone = 123456,
                    BirthDate = new DateOnly(year: 1982, month: 12, day: 4)
                },

                new Person()
                {
                    Name = "Carla Moraes",
                    Email = "cms@gmail.com",
                    Telephone = 9987411,
                    BirthDate = new DateOnly(year: 2000, month: 7, day: 20)
                }
            };

            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();

                path = Path.Combine(path, "usuarios.csv");
            }

            using var sw = new StreamWriter(path);

            sw.WriteLine("nome, email, telefone, nascimento");

            foreach (var person in persons)
            {
                var line = $"{person.Name}, {person.Email}, {person.Telephone}, {person.BirthDate}";

                sw.WriteLine(line);
            }
        }

        public static void CsvRead()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Input", "usuarios-exportacao.csv");

            if (File.Exists(path))
            {
                using var sr = new StreamReader(path);

                var header = sr.ReadLine()?.Split(',');

                while (true)
                {
                    var line = sr.ReadLine()?.Split(',');

                    if (line == null) break;

                    if (header?.Length != line.Length)
                    {
                        Console.WriteLine("Arquivo fora do padrão.");
                    }

                    for (int i = 0; i < line.Length; i++)
                    {
                        Console.WriteLine($"{header?[i]}: {line[i]}");
                    }

                    Console.WriteLine("--------------------");
                }
            }
            else
            {
                Console.WriteLine($"Arquivo {path} não existe!");
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public int Telephone { get; set; }
            public DateOnly BirthDate { get; set; }
        }
    }
}
