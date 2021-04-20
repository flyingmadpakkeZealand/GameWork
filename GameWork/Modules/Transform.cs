using System;
using System.Drawing;

namespace GameWork.Modules
{
    public class Transform : IStockModule
    {
        private Point _point;

        public Transform()
        {
            _point = Point.Empty;
        }

        public Transform(int x, int y)
        {
            _point = new Point(x, y);
        }

        public static implicit operator Transform(ValueTuple<int, int> coords) => new Transform(coords.Item1, coords.Item2);
    }
}
