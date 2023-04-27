﻿namespace DelegatesEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List();
            
            list.Notificate += Notify;
            list.Notificate += NotifyAgain;

            list.Add("A");
            list.Add("B");
            list.Add("C");

            Action<List> action = new Action<List>(
                i => Console.WriteLine(i)
            );

            Func<List, bool> func = new Func<List, bool>(
                i => i.Id == 1
            );

            Predicate<List> predicate = new Predicate<List>(
                i => i.Id == 3
            );

            list.PrintAllItems(action);

            Console.WriteLine();

            var item = list.GetItemById(func);

            var exist = list.ExistItem(predicate);

            Console.WriteLine($"\nItem encontrado: {item}");

            Console.WriteLine($"\nItem existe? {exist}");
        }

        public static void Notify()
        {
            Console.WriteLine("Fui notificado!");
        }

        public static void NotifyAgain()
        {
            Console.WriteLine("Fui notificado novamente!");
        }
    }
}

