using BuilderPattern.Products;

namespace BuilderPattern.Build
{
    public class MediaSocialTwitterBuilder : MediaSocialBuilder
    {
        public MediaSocialTwitterBuilder()
        {
            _socialMedia = new MediaSocial("Twitter", ConsoleColor.Cyan);
        }

        public override void BuildLike()
        {
            _socialMedia.Like("Publicação do GitHub");
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