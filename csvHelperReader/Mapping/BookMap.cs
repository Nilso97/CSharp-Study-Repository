using System.Globalization;
using CsvHelper.Configuration;
using csvHelperReader.Model;

namespace csvHelperReader.Mapping
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Map(b => b.Titulo).Name("titulo");

            Map(b => b.Autor).Name("autor");

            Map(b => b.Preco)
                .Name("preço")
                .TypeConverterOption
                .CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));

            Map(b => b.Lancamento)
                .Name("lançamento")
                .TypeConverterOption.Format(new [] { "dd/mm/yyyy" });
        }
    }
}