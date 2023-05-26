namespace DelegatesEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List();
            list.Notificate += Notificated;
            
            list.Add("TV Smart 32");
            list.Add("Microondas Eletrolux");
            list.Add("Geladeira Consul");

            list.GetList.FirstOrDefault(i => i.Id == 2);

            Action<List> action = new Action<List>
            (
                i => Console.WriteLine(i)
            );

            Func<List, bool> func = new Func<List, bool>
            (
                i => i.Id == 1
            );

            Predicate<List> predicate = new Predicate<List>
            (
                i => i.Id == 3
            );

            list.PrintAllItems(action);

            var item = list.GetItemById(func);
            var exist = list.ExistItem(predicate);
            
            Console.WriteLine($"\n{item}");
            Console.WriteLine(exist);
        }

        public static void Notificated()
        {
            Console.WriteLine("Novo item adicionado ao carrinho:");
        }    
    }
}