﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class Container
    {
        public ContainerType Type { get; private set; }
        public int Weight { get; private set; }

        public Container(ContainerType type, int weight)
        {
            Type = type;
            Weight = weight;
        }
    }
}
