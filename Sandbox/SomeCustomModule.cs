using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GameWork.Modules;
using GameWork.Modules.InventoryModule;

namespace Sandbox
{
    public class SomeCustomModule : IInventoryModule, ICustomModule
    {
        public IEnumerator<IInventoryItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; }
        public void Add(IInventoryItem item)
        {
            throw new NotImplementedException();
        }
    }
}
