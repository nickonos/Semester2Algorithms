using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class ContainerRow
    {
        public List<ContainerStack> ContainerStacks { get; set; }

        public ContainerRow()
        {
            ContainerStacks = new List<ContainerStack>();
        }
    }
}
