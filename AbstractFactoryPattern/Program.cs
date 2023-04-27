using AbstractFactoryPattern.Abstract;
using AbstractFactoryPattern.Factory;

namespace AbstractFactoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AbstractFactory factory = new MediaSocialFactory();
            
            var media = factory.CreateMediaSocial();

            media.Post(title: "Título da publicação", body: "Minha primeira publicação no");
            media.Like();
        }
    }
}
