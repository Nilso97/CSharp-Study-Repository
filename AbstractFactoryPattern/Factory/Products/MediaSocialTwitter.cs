using AbstractFactoryPattern.Abstract.Products;

namespace AbstractFactoryPattern.Factory.Products
{
    public class MediaSocialTwitter : MediaSocial
    {
        public override void Like()
        {
            System.Console.WriteLine("Post curtido no Twitter");
        }

        public override void Post(string title, string body)
        {
            Console.WriteLine($"Título: {title}");
            Console.WriteLine($"Descrição: {body}" + " Twitter");
        }
    }
}