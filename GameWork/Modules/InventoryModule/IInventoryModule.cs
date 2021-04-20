using System;
using System.Collections.Generic;
using System.Text;

namespace GameWork.Modules.InventoryModule
{
    public interface IInventoryModule : IEnumerable<IInventoryItem>, IModule
    {
        int Count { get; }
        void Add(IInventoryItem item);
    }
}
