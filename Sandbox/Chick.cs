using System;
using System.Collections.Generic;
using System.Text;
using GameWork.Modules.InventoryModule;

namespace Sandbox
{
    public class Chick : IInventoryItem
    {
        public string[] Tags { get; } = {"Living"};
    }
}
