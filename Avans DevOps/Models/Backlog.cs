using Avans_DevOps.Items;

namespace Avans_DevOps.Models
{
    public class Backlog
    {

        private IList<Item> _items { get; set; }

        public Backlog(){
            _items = [];
        }

        public void Add(Item item) { 
            _items.Add(item);
        }

        public void Remove(Item item) { 
            _items.Remove(item);
        }

        public IList<Item> GetItems()
        {
            return _items;
        }

        public void Clear(){
            _items.Clear();
        }
    }
}
