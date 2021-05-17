﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public enum ContainerType
    {
        Default,
        Valuable,
        Cooled,
        ValuableCooled
    }

    public class IntVector2
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public IntVector2() { }

        public IntVector2(int x, int y)
        {
            Length = x;
            Width = y;
        }
    }

}
