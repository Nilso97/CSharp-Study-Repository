using BuilderPattern.Build;

namespace BuilderPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MediaSocialBuilder builder;
            Director director;

            builder = new MediaSocialFacebookBuilder();
            director = new Director(builder);

            System.Console.WriteLine();

            builder = new MediaSocialTwitterBuilder();
            director = new Director(builder);
        }
    }
}
