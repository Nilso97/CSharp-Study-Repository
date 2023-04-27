using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using csvHelperReader.Model;
using csvHelperReader.Mapping;

namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadCsvWithDynamic();

            ReadCsvWithClass();

            ReadCsvWithDelimiter();

            WriteCsv();

            System.Console.WriteLine("Pressione [ENTER] para finalizar");
            Console.ReadLine();
        }

        public static void WriteCsv()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Output"
            );

            var directory = new DirectoryInfo(path);

            if (!directory.Exists) directory.Create();

            path = Path.Combine(path, "usuarios.csv");

            var persons = new List<Person>()
            {
                new Person()
                {
                    Nome = "John Doe",
                    Email = "john.doe@gmail.com",
                    Telefone = 42999734567
                },

                new Person()
                {
                    Nome = "Karen Williams",
                    Email = "karen.williams@gmail.com",
                    Telefone = 42999453456
                },

                new Person()
                {
                    Nome = "Michael Watsom",
                    Email = "michael.watsom@gmail.com",
                    Telefone = 42999897656
                },

                new Person()
                {
                    Nome = "Paul David",
                    Email = "paul.david@gmail.com",
                    Telefone = 42999078953
                }
            };

            using var sw = new StreamWriter(path);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|"
            };

            using var csvWriter = new CsvWriter(sw, csvConfig);

            csvWriter.WriteRecords(persons);
        }

        public static void ReadCsvWithDynamic()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Input",
                "Produtos.csv"
            );

            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException($"Arquivo {path} não existe.");
            }

            using var sr = new StreamReader(fileInfo.FullName);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

            using var csvReader = new CsvReader(sr, csvConfig);

            var registers = csvReader.GetRecords<dynamic>();

            foreach (var register in registers)
            {
                Console.WriteLine($"Produto: {register.Produto}");
                Console.WriteLine($"Marca: {register.Marca}");
                Console.WriteLine($"Preço: {register.Preço}");

                System.Console.WriteLine("--------------------");
            }
        }

        public static void ReadCsvWithClass()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Input",
                "novos-usuarios.csv"
            );

            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException($"Arquivo {path} não existe.");
            }

            using var sr = new StreamReader(fileInfo.FullName);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

            using var csvReader = new CsvReader(sr, csvConfig);

            var registers = csvReader.GetRecords<User>().ToList();

            foreach (var register in registers)
            {
                Console.WriteLine($"Nome: {register.Nome}");
                Console.WriteLine($"E-mail: {register.Email}");
                Console.WriteLine($"Telefone: {register.Telefone}");

                System.Console.WriteLine("--------------------");
            }
        }

        public static void ReadCsvWithDelimiter()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Input",
                "Livros-preco-com-virgula.csv"
            );

            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException($"Arquivo {path} não existe.");
            }

            using var sr = new StreamReader(fileInfo.FullName);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using var csvReader = new CsvReader(sr, csvConfig);

            csvReader.Context.RegisterClassMap<BookMap>();

            var registers = csvReader.GetRecords<Book>().ToList();

            foreach (var register in registers)
            {
                Console.WriteLine($"Titúlo: {register.Titulo}");
                Console.WriteLine($"Preço: {register.Preco}");
                Console.WriteLine($"Autor: {register.Autor}");
                Console.WriteLine($"Data de lançamento: {register.Lancamento}");

                System.Console.WriteLine("--------------------");
            }
        }
    }
}