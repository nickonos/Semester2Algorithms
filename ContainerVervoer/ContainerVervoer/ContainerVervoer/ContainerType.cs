using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public enum ContainerType
    {
        Default = 1,
        Valuable = 2,
        Cooled = 3,
        ValuableCooled = 4
    }

    public class IntVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntVector2() { }

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
