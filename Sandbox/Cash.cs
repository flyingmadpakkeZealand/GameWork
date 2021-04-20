using System;
using System.Collections.Generic;
using System.Text;
using GameWork.Modules.InventoryModule;

namespace Sandbox
{
    public class Cash : IInventoryItem
    {
        public string[] Tags { get; } = {"Valuable", "Currency"};
    }
}
