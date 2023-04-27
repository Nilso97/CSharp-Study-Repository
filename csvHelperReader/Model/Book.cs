using CsvHelper.Configuration.Attributes;

namespace csvHelperReader.Model
{
    public class Book
    {
        // [Name("titulo")]
        // [Index(0)]
        public string Titulo { get; set; }

        // [Name("autor")]
        // [Index(2)]
        public string Autor { get; set; }

        //[Name("preço")]
        // [Index(1)]
        // [CultureInfo("pt-BR")]
        public decimal Preco { get; set; }

        // [Name("lançamento")]
        // [Index(3)]
        // [Format("dd/mm/yyyy")]
        public DateOnly Lancamento { get; set; }
    }
}