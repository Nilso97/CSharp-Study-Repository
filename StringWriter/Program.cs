namespace Curso
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = "Lorem ipsum dolor sit amet. Ut architecto atque est consequuntur dolores hic molestias galisum ut neque itaque quo illum assumenda? Ut delectus sint et quam quis qui quas tenetur aut magni debitis! Est galisum aperiam est ipsa mollitia aut recusandae fugiat.\n\n" + 
            
            "Et molestiae possimus qui voluptatem dolores cum dolor expedita qui itaque harum qui iste exercitationem. Qui harum nihil et commodi rerum et quia officia aut voluptatem numquam est facilis veritatis et alias illo et itaque nihil.\n\n" + 
            
            "Cum debitis rerum aut voluptatum internos aut ipsa quae et galisum iure. Nam dicta ipsa ut omnis natus ad quisquam modi eum corrupti minus.";

            Console.WriteLine($"Texto original: {text}");

            string line, paragraph = null;

            var sr = new StringReader(text);

            while (true)
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    paragraph += line + " ";
                } else 
                {
                    paragraph += '\n';
                    break;
                }
            }

            System.Console.WriteLine();

            Console.WriteLine($"Texto modificado: {paragraph}");    

            int characterRead;
            char convertedCharacter; 

            var sw = new StringWriter();
            sr = new StringReader(paragraph);    

            while (true)
            {
                characterRead = sr.Read();
                if (characterRead == -1) break;

                convertedCharacter = Convert.ToChar(characterRead);

                if (convertedCharacter == '.') 
                {
                    sw.Write("\n\n");

                    sr.Read();
                    sr.Read();
                } else
                {
                    sw.Write(convertedCharacter);
                }
            }

            Console.WriteLine($"Texto armazenado no Stringwriter: {sw.ToString()}");

            System.Console.WriteLine("\n\nDigite [ENTER] para finalizar...");
            Console.ReadLine();
        }
    }
}
