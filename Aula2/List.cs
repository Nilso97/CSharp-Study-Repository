namespace DelegatesEvents
{
    public delegate void Notification();

    public class List
    {
        private List<List> _items = new List<List>();
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public IReadOnlyCollection<List> GetList => _items;
        public event Notification Notificate;

        public void Add(string item)
        {
            var listItem = new List();
            listItem.Id += this._items.Count;
            listItem.Item = item;
            this._items.Add(listItem);
            EventHandler();
        }

        private void EventHandler()
        {
            Notificate();
        }

        #region Action
        public void PrintAllItems(Action<List> action)
        {
            // Método anônimo
            // this._items.ForEach(s => 
            // {
            //     Console.WriteLine(s);
            // });

            this._items.ForEach(action);
        }     
        #endregion

        #region Func
        public List GetItemById(Func<List, bool> func)
        {
            return this._items.FirstOrDefault(func);            
        }
        #endregion

        #region Predicate
        public bool ExistItem(Predicate<List> pred)
        {
            return this._items.Exists(pred);
        }     
        #endregion

        public override string ToString()
        {
            return $"{this.Id} - {this.Item} - {this.CreatedDate}";
        }
    }
}