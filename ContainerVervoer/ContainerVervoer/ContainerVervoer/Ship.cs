using System;
using System.Collections.Generic;
using System.Linq;
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
            for(int i= 0; i< ShipSize.Length; i++)
            {
                Deck.Add(new ContainerRow(ShipSize.Width));
            }
        }

        public List<ContainerRow> GetContainerRows()
        {
            return Deck;
        }

        public void Sort()
        {
            if (TotalContainers == null || TotalContainers.Count == 0)
                return;

            FillFirstRow();

            FillRemainingRows();

            //ContainerRow row = new ContainerRow(ShipSize.Width);
            //ContainerStack stack = new ContainerStack();
            //foreach(Container container in TotalContainers.ToList())
            //{
            //    if (!stack.AddContainer(container))
            //    {
            //        if (!row.AddContainerStack(stack))
            //        {
            //            Deck.Add(row);

            //            row = new ContainerRow(ShipSize.Width);
            //            Console.WriteLine(CalculateShipBalance());
            //        }

            //        stack = new ContainerStack();
            //    }
            //    else
            //    {
            //        TotalContainers.Remove(container);
            //    }
                
            //}
        }


        private void FillFirstRow()
        {
            ContainerRow row = new ContainerRow(ShipSize.Width);

            List<Container> containers = TotalContainers.FindAll(c => c.Type == ContainerType.Cooled);

            foreach(Container container in containers)
            {
                TotalContainers.Remove(container);
            }

            if (row.DevideContainers(containers) != null)
                throw new Exception("Cooled containers don't fit in row 1");

            
            containers = TotalContainers.FindAll(c => c.Type == ContainerType.ValuableCooled);

            foreach (Container container in containers)
            {
                TotalContainers.Remove(container);
            }

            if (row.DevideContainers(containers) != null)
                //throw new Exception("Valuable Cooled containers don't fit in row 1");

            Deck[0] = row;
        }

        public void FillRemainingRows()
        {
            foreach(ContainerRow containerRow in Deck.ToList())
            {
                Container container = containerRow.DevideContainers(TotalContainers.FindAll(c => c.Type == ContainerType.Default));

                if (container == null)
                    return;

                TotalContainers.RemoveRange(0, TotalContainers.IndexOf(container));
            }
        }

        public void AddContainers(List<Container> containers)
        {
            TotalContainers.AddRange(containers);
        }

        private double CalculateShipBalance()
        {
            double WeightLeft = 0;
            double WeightRight = 0;

            foreach(ContainerRow row in Deck)
            {
                int i = 0;
                foreach (ContainerStack containerStack in row.GetContainerStacks())
                {

                    if(ShipSize.Width%2 == 0)
                    {
                        if ( i < ShipSize.Width / 2)
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
                        if (i == ShipSize.Width - 1 / 2) 
                        {
                        }
                        else if (i < ShipSize.Width - 1 / 2)
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
            }
            double Diff = (WeightRight/(WeightRight + WeightLeft) *100) - (WeightLeft / (WeightLeft + WeightRight)*100);
            return Diff;
        }
    }
}
