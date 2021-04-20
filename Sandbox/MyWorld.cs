using System;
using System.Collections.Generic;
using System.Text;
using GameWork;
using GameWork.Modules.InventoryModule;

namespace Sandbox
{
    public class MyWorld : World
    {
        public List<GameObject> Dudes { get; private set; }

        protected override void PopulateWorld()
        {
            Dudes = new List<GameObject>();
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                if (rand.Next(2) == 1)
                {
                    Dude dude = new Dude("Cool Dude");
                    if(rand.Next(2) == 1) dude.Inventory.Add(new Chick());
                    if(rand.Next(2) == 1) dude.Inventory.Add(new Cash());
                    Dudes.Add(dude);
                }
            }
        }
    }
}
