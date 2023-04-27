using BuilderPattern.Products;

namespace BuilderPattern.Build
{
    public abstract class MediaSocialBuilder
    {
        protected MediaSocial _socialMedia;
        public MediaSocial socialMedia => _socialMedia;

        public abstract void BuildPost();
        public abstract void BuildLike();
    }
}