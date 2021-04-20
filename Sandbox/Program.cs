using System;
using System.Collections.Generic;
using System.Linq;
using GameWork;
using GameWork.Modules;
using GameWork.Modules.InventoryModule;
using Sandbox.TestSpace;
using Sandbox.TestSpace2;


namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = nameof(TestSpace2.TestClass);
            

            GameObject gameObject = new GameObject();
            gameObject.AddModule(new Inventory());
            MyWorld world = new MyWorld();

            Console.WriteLine("Amount of dudes in world: " + world.Dudes.Count);
            Console.WriteLine("Printing dudes and their inventory:");
            foreach (Dude dude in world.Dudes)
            {
                Console.WriteLine("Name: " + dude.Name);
                foreach (IInventoryItem item in dude.Inventory.GetGroup("Living"))
                {
                    Console.Write("Chick, tags: ");
                    item.Tags.ToList().ForEach(tag => Console.Write(tag + " "));
                    Console.WriteLine();
                }

                foreach (IInventoryItem item in dude.Inventory.GetGroup("Valuable"))
                {
                    Console.Write("Cash, tags: ");
                    item.Tags.ToList().ForEach(tag => Console.Write(tag + " "));
                    Console.WriteLine();
                }
            }

            string test2 = nameof(TestSpace.TestClass);

            //List<int> numbers = new List<int>(){1,2,3};
            //var enumerator = numbers.GetEnumerator();
            //enumerator.MoveNext();
            //int first = enumerator.Current;

            //List<int> otherNumbers = new List<int>();

            //while (enumerator.MoveNext())
            //{
            //    otherNumbers.Add(enumerator.Current);
            //}
            //enumerator.Dispose();

            //enumerator.MoveNext();
            //int fail = enumerator.Current;

            //TestSpace2.TestClass testClass = new TestSpace2.TestClass();

            //testClass.Start();
        }
    }
}
