using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class ContainerStack
    {
        //MaxWeightOnTop = 120000
        public List<Container> Containers { get; set; }

        public ContainerStack()
        {
            Containers = new List<Container>();
        }

        public int CalculateWeightOnTop()
        {
            int Weight = 0;

            foreach(Container container in Containers)
            {
                if (Containers.IndexOf(container) == 0)
                    continue;

                Weight += container.Weight;
            }

            return Weight;
        }

        public int CalculateWeight()
        {
            int Weight = 0;

            foreach (Container container in Containers)
            {
                Weight += container.Weight;
            }

            return Weight;
        }
    }
}
