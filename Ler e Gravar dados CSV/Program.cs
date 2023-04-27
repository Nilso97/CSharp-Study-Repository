using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Curso
{
    public class Program
    {
        public static List<Venda> vendas;

        public static void Main(string[] args)
        {
            CsvReadFile();

            CsvCreateFile();
            
            System.Console.WriteLine("Pressione [ENTER] para finalizar");

            Console.Read();
        }

        public static void CsvReadFile()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Data.csv"); 

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(path))
            
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<VendaMap>();

                vendas = csv.GetRecords<Venda>().ToList();

                foreach (var venda in vendas)
                {
                    Console.WriteLine($"Cliente: {venda.NomeCliente}, Pacote: {venda.NomePacote}, Data de nascimento: {venda.DataNascimento}, Data de atendimento: {venda.DataAtendimento}, Cidade e Estado: {venda.CidadeEstado}");

                    System.Console.WriteLine("--------------------\n");
                }
            }
        }

        public static void CsvCreateFile()
        { 
            var path = Path.Combine(
                Environment.CurrentDirectory, 
                "Arquivos"
            );

            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                System.Console.WriteLine($"Criando diretório localizado em {path}\n");

                Thread.Sleep(3000);

                directory.Create();
            }
            else
            {
                Console.WriteLine($"Diretório [{path}] já existe!\n");
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            System.Console.WriteLine("Criando o arquivo CSV...\n");

            Thread.Sleep(3000);

            using (var writer = new StreamWriter($"{path}/dados-vendas.csv"))

            using (var csv = new CsvWriter(writer, config)) 
            {
                csv.Context.RegisterClassMap<VendaMap>();

                csv.WriteHeader<Venda>();

                csv.NextRecord();

                csv.WriteRecords(vendas);
            }

            System.Console.WriteLine("Arquivo criado com sucesso!\n");
        }
    }
}
