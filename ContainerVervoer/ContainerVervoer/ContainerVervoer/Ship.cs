using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ContainerVervoer
{
    public class Ship
    {
        //Waardevolle containers mogen geen containers bovenop wel op containers
        //Waardevolle containers moeten of voor of achteraan het schip
        //Gekoelde containers moeten voor aan het schip zitten
        //50% van het maximale gewicht moet benut zijn
        //het schip moet links en rechts evenveel gewicht hebben (σ: 20%)
        private int MaximumWeight;
        private List<ContainerRow> Deck;
        private List<Container> TotalContainers;
        private IntVector2 ShipSize;

        public Ship(IntVector2 intVector2, int maxWeight)
        {
            TotalContainers = new List<Container>();
            Deck = new List<ContainerRow>();
            MaximumWeight = maxWeight;
            ShipSize = intVector2;
        }

        public void Sort()
        {
            if (TotalContainers == null || TotalContainers.Count == 0)
                return;

            foreach(Container container in TotalContainers.FindAll(c => c.Type == ContainerType.Cooled || c.Type == ContainerType.ValuableCooled))
            {

            }
        }

        public void AddContainers(List<Container> containers)
        {
            TotalContainers.AddRange(containers);
        }

        private double CalculateWeightDifference()
        {
            int WeightLeft = 0;
            int WeightRight = 0;

            foreach(ContainerRow row in Deck)
            {
                foreach(ContainerStack stack in row.ContainerStacks)
                {
                    if(ShipSize.Width%2 == 0)
                    {
                        if ( row.ContainerStacks.IndexOf(stack) < ShipSize.Width / 2)
                        {
                            WeightLeft += stack.CalculateWeight();
                        }
                        else
                        {
                            WeightRight += stack.CalculateWeight();
                        }
                    }
                    else
                    {
                        if (row.ContainerStacks.IndexOf(stack) == ShipSize.Width - 1 / 2) 
                        {
                        }
                        else if (row.ContainerStacks.IndexOf(stack) < ShipSize.Width - 1 / 2)
                        {
                            WeightLeft += stack.CalculateWeight();
                        }
                        else
                        {
                            WeightRight += stack.CalculateWeight();
                        }
                    }
                }
            }
            double Diff = ((double)WeightRight/(double)(WeightRight + WeightLeft) *100) - ((double)WeightLeft / (double)(WeightLeft + WeightRight)*100);
            Console.WriteLine(Diff);
            return Diff;
        }
    }
}
