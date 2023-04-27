using BuilderPattern.Products;

namespace BuilderPattern.Build
{
    public class MediaSocialFacebookBuilder : MediaSocialBuilder
    {
        public MediaSocialFacebookBuilder()
        {
            _socialMedia = new MediaSocial("Facebook", ConsoleColor.Blue);    
        }

        public override void BuildLike()
        {
            _socialMedia.Like("Publicação da Microsoft");
        }

        public override void BuildPost()
        {
            _socialMedia.Post(
                title: "Título da publicação",
                body: "Descrição da publicação"
            );
        }
    }
}