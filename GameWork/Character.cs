using System;
using System.Collections.Generic;
using System.Text;
using GameWork.Modules;
using GameWork.Modules.InventoryModule;

namespace GameWork
{
    public abstract class Character : GameObject
    {
        public string Name { get; set; }

        protected readonly IInventoryModule _inventory;

        protected Character(string name, params IModule[] modules) : base(modules)
        {
            _inventory = GetOrAddModule(new Inventory()); //TODO: Broken because their could be different types if inventories.
            Name = name;
        }

        protected Character(params IModule[] modules) : this(null, modules) { }
    }
}
