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

            Console.WriteLine($"c= {TotalContainers.FindAll(c => c.Type == ContainerType.Cooled).Count},v = {TotalContainers.FindAll(c => c.Type == ContainerType.Valuable).Count}, vc = {TotalContainers.FindAll(c => c.Type == ContainerType.Cooled).Count}");

            FillFirstRow();

            FillDefaultRows();

            FillValuableRows();
        }

        public void AddContainers(List<Container> containers)
        {
            TotalContainers.AddRange(containers);
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
                Console.WriteLine("valuable Cooled containers don't fit in row 1");

            Deck[0] = row;
        }

        private void FillDefaultRows()
        {
            foreach(ContainerRow containerRow in Deck.ToList())
            {
                List<Container> containers = TotalContainers.FindAll(c => c.Type == ContainerType.Default);
                Container container = containerRow.DevideContainers(containers);

                bool check = false;
                foreach(Container c in containers)
                {
                    if (c == container)
                        check = true;

                    if(!check)
                        TotalContainers.Remove(c);
                }
                
            }
            foreach (ContainerRow containerRow in Deck.ToList())
            {
                List<Container> containers = TotalContainers.FindAll(c => c.Type == ContainerType.Valuable);
                Container container = containerRow.DevideContainers(containers);

                bool check = false;
                foreach (Container c in containers)
                {
                    if (c == container)
                        check = true;

                    if(!check)
                        TotalContainers.Remove(c);
                }
            }
        }

        private void FillValuableRows()
        {
            int j = 1;
            for(int i = ShipSize.Length/2; i< ShipSize.Length && i>= 0;)
            {
                //Deck[i].GetContainerStacks();
                Console.WriteLine($"jump: {j}, index: {i}");


                if(j%2 == (ShipSize.Length/2)%2)
                {
                    i += j;
                }
                else
                {
                    i -= j;
                }
                j++;
            }
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
