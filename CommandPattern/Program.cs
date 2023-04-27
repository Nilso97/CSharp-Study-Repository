namespace CommandPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var command1 = (State) new Receiver().Action(new Command(1, "Comando 1"));

            Console.WriteLine($"StatusCode: {command1.StatusCode} - Message: {command1.Message}\n");

            var command2 = (State) new Receiver().Action(new Command(2, "Comando 2"));

            Console.WriteLine($"StatusCode: {command2.StatusCode} - Message: {command2.Message}");
        }
    }
}
