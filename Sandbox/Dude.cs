using System;
using System.Collections.Generic;
using System.Text;
using GameWork;
using GameWork.Modules.InventoryModule;

namespace Sandbox
{
    public class Dude : Character
    {
        public Inventory Inventory => (Inventory) _inventory;

        public Dude(string name) : base(name, new Inventory())
        {
            
        }
    }
}
