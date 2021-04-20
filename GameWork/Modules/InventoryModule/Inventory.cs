using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameWork.Modules.InventoryModule
{
    public class Inventory : IInventory<List<IInventoryItem>>, IStockModule
    {
        protected List<IInventoryItem> _allItems;
        protected Dictionary<string, List<IInventoryItem>> _tagsLookup;

        public int Count => _allItems.Count;

        public IInventoryItem this[int index] => _allItems[index];

        public Inventory()
        {
            _allItems = new List<IInventoryItem>();
            _tagsLookup = new Dictionary<string, List<IInventoryItem>>();
        }

        public virtual List<IInventoryItem> GetGroup(string tag)
        {
            return _tagsLookup.TryGetValue(tag, out List<IInventoryItem> group) ? group : new List<IInventoryItem>();
        }

        public virtual void Add(IInventoryItem item)
        {
            _allItems.Add(item);

            foreach (string tag in item.Tags)
            {
                if (_tagsLookup.ContainsKey(tag))
                {
                    _tagsLookup[tag].Add(item);
                }
                else
                {
                    _tagsLookup.Add(tag, new List<IInventoryItem>(){item});
                }
            }
        }

        public IEnumerator<IInventoryItem> GetEnumerator()
        {
            return _allItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
