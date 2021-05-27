using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class ContainerStack
    {
        private List<Container> Containers;

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

        public bool CheckIfContainerFits(Container container)
        {
            if (CalculateWeightOnTop() + container.Weight > 120000)
                return false;

            if (Containers.Count != 0 && Containers.FindLast(c => c.Weight > 1).Type == ContainerType.Valuable || Containers.Count != 0 && Containers.FindLast(c => c.Weight > 1).Type == ContainerType.ValuableCooled)
                return false;

            return true;
        }

        public bool AddContainer(Container container)
        {
            if (!CheckIfContainerFits(container))
                return false;

            Containers.Add(container);
            return true;
        }

        public int GetHeight()
        {
            return Containers.Count;
        }

        public IReadOnlyList<Container> GetContainers()
        {
            return Containers.AsReadOnly();
        }
    }
}
