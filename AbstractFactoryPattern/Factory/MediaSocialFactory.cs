using AbstractFactoryPattern.Abstract;
using AbstractFactoryPattern.Abstract.Products;
using AbstractFactoryPattern.Factory.Products;

namespace AbstractFactoryPattern.Factory
{
    public class MediaSocialFactory : AbstractFactory
    {
        public override MediaSocial CreateMediaSocial()
        {
            return new MediaSocialTwitter();
        }
    }
}