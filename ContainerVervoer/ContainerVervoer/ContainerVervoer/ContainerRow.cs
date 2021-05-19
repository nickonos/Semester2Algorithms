using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerVervoer
{
    public class ContainerRow
    {
        private List<ContainerStack> ContainerStacks;
        private int maxLength;

        public ContainerRow(int m)
        {
            ContainerStacks = new List<ContainerStack>();
            maxLength = m;

            for(int i =0; i< maxLength; i++)
            {
                ContainerStacks.Add(new ContainerStack());
            }

        }

        public bool AddContainerStack(ContainerStack containerStack)
        {
            if (ContainerStacks.Count + 1 > maxLength)
                return false;

            ContainerStacks.Add(containerStack);

            return true;
        }

        public Container? DevideContainers(List<Container> Containers)
        {
            foreach(Container container in Containers.ToList())
            {
                if(maxLength%2 == 1)
                {
                    if (!ContainerStacks[maxLength / 2].AddContainer(container))
                        if (!AddLeftOrRight(container))
                            return container;

                    Containers.Remove(container);
                    continue;
                }
                if (!AddLeftOrRight(container))
                    return container;
                Containers.Remove(container);
            }

            return null;
            
        }

        private bool AddLeftOrRight(Container container)
        {
            double bal = CalculateRowBalance();
            if (bal > 0)
            {
                for(int i = (maxLength-1)/2; i > 0; i--)
                {
                    if (ContainerStacks[i].AddContainer(container))
                        return true;
                } 
            }
            else
            {
                for(int i = ((maxLength-1)/2) +1; i < maxLength; i++)
                {
                    if (ContainerStacks[i].AddContainer(container))
                        return true;
                }
            }
            return false;
        }

        public IReadOnlyList<ContainerStack> GetContainerStacks()
        {
            return ContainerStacks.AsReadOnly();
        }

        public double CalculateRowBalance()
        {
            double WeightLeft = 0;
            double WeightRight = 0;

            int i = 0;
            foreach (ContainerStack containerStack in ContainerStacks)
            {

                if (maxLength % 2 == 0)
                {
                    if (i < maxLength / 2)
                    {
                        WeightLeft += containerStack.CalculateWeight();
                    }
                    else
                    {
                        WeightRight += containerStack.CalculateWeight();
                    }
                }
                else
                {
                    if (i == maxLength - 1 / 2)
                    {
                    }
                    else if (i < maxLength - 1 / 2)
                    {
                        WeightLeft += containerStack.CalculateWeight();
                    }
                    else
                    {
                        WeightRight += containerStack.CalculateWeight();
                    }
                }
                i++;
            }
            
            double Diff = (WeightRight / (WeightRight + WeightLeft) * 100) - (WeightLeft / (WeightLeft + WeightRight) * 100);
            Console.WriteLine(Diff);
            return Diff;
        }

    }
}
