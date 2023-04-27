using BuilderPattern.Build;

namespace BuilderPattern
{
    public class Director
    {
        public Director(MediaSocialBuilder builder)
        {
            builder.BuildPost();
            builder.BuildLike();
        }        
    }
}