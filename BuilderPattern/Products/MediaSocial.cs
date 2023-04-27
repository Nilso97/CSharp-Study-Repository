namespace BuilderPattern.Products
{
    public class MediaSocial
    {
        private readonly string _socialMediaName;
        private readonly ConsoleColor _color;

        public MediaSocial(string socialMediaName, ConsoleColor color)
        {
            _socialMediaName = socialMediaName;
            _color = color;
        }

        public void Post(string title, string body)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(this._socialMediaName);
            Console.WriteLine($"Título: {title}");
            Console.WriteLine($"Descrição: {body}");
        }

        public void Like(string publication)
        {
            Console.WriteLine($"A [{publication}] foi curtida no {this._socialMediaName}");
            Console.ResetColor();
        }
    }
}