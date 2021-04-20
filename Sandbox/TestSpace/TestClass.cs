using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.TestSpace
{
    class TestClass
    {
        public int X { get; set; }

        public int Y { get; set; }

        public TestClass(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static implicit operator TestClass(ValueTuple<int, int> coords) => new TestClass(coords.Item1, coords.Item2);
    }
}
