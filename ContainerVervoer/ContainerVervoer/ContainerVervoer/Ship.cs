using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ContainerVervoer
{
    public class Ship
    {
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
            for(int i= 0; i< ShipSize.Y; i++)
            {
                Deck.Add(new ContainerRow(ShipSize.X));
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

            FillDefaultRows();

            FillValuableRows();
        }

        public void AddContainers(List<Container> containers)
        {
            TotalContainers.AddRange(containers);
        }


        private void FillFirstRow()
        {
            ContainerRow row = new ContainerRow(ShipSize.X);

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
        }

        private void FillValuableRows()
        {
            List<Container> containers = TotalContainers.FindAll(c => c.Type == ContainerType.Valuable);
            foreach(Container container in containers)
            {
                AddValuableContainer(container);
                TotalContainers.Remove(container);
            }
        }

        private void AddValuableContainer(Container container) 
        {
            int j = 1;
            for (int i = ShipSize.Y / 2; i < ShipSize.Y && i >= 0; j++)
            {
                List<int> test = Deck[i].GetValidContainerPositions(container);

                if (TryAddValuable(test, i, container))
                    return;

                if (j % 2 == (ShipSize.Y / 2) % 2)
                    i += j;
                else
                    i -= j;
            }
        }

        private bool TryAddValuable(List<int> rowPositions , int deckPosition , Container container)
        {
            foreach (int pos in rowPositions)
            {
                if (CheckIfAccessable(new IntVector2(deckPosition, pos)))
                {
                    Deck[deckPosition].AddContainer(pos, container);
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfAccessable(IntVector2 position)
        {
            IReadOnlyList<ContainerStack> Checkrow = Deck[position.X].GetContainerStacks();
            int height = Checkrow[position.Y].GetHeight();
            bool succes = true;
            if (position.X == 0 || position.X == ShipSize.Y - 1)
                return true;

            for(int i = position.Y; i< ShipSize.X; i++)
            {
                IReadOnlyList<ContainerStack> stacks = Deck[i].GetContainerStacks();
                if (stacks[i].GetContainers().Count > height)
                    succes = false;
            }
            if (succes)
                return true;

            for (int i = position.Y; i > 0; i--)
            {
                IReadOnlyList<ContainerStack> stacks = Deck[i].GetContainerStacks();
                if (stacks[i].GetContainers().Count > height)
                    succes = false;
            }
            return succes;
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

                    if(ShipSize.X%2 == 0)
                    {
                        if ( i < ShipSize.X / 2)
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
                        if (i == ShipSize.X - 1 / 2) 
                        {
                        }
                        else if (i < ShipSize.X - 1 / 2)
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
