using Avans_DevOps.Items;
using Avans_DevOps.Sprints;

namespace Avans_DevOps.Models
{
    public class Backlog
    {

        private IList<Item> _items { get; set; }
        private Sprint _sprint;

        public Backlog(Sprint sprint){
            _items = [];
            _sprint = sprint;
        }

        public void Add(Item item) {
            item.SetBacklog(this);
            _items.Add(item);
        }

        public void Remove(Item item) { 
            _items.Remove(item);
        }

        public IList<Item> GetItems()
        {
            return _items;
        }

        public Sprint GetSprint()
        {
            return _sprint;
        }

        public void Clear(){
            _items.Clear();
        }
    }
}
