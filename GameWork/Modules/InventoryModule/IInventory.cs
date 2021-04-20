using System;
using System.Collections.Generic;
using System.Text;

namespace GameWork.Modules.InventoryModule
{
    public interface IInventory<out T> : IInventoryModule
        where T : ICollection<IInventoryItem>
    {
        T GetGroup(string tag);
    }
}
