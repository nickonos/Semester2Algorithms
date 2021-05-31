using ContainerVervoer;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ContainerVervoerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCalculateWeightDifference()
        {
            Ship ship = new Ship(new IntVector2(3, 4), 1000000000);
            Assert.Pass();
        }

        [Test]
        public void TestShipEven()
        {
            Ship ship = new Ship(new IntVector2(4, 4), 1000000000);
            List<Container> containers = CreateContainers();
            ship.AddContainers(containers);
            ship.Sort();
            CheckShip(ship);
            
            Assert.Pass();
        }

        [Test]
        public void TestShipOdd()
        {
            Ship ship = new Ship(new IntVector2(5, 5), 1000000000);
            List<Container> containers = CreateContainers();
            ship.AddContainers(containers);
            ship.Sort();
            CheckShip(ship);

            Assert.Pass();
        }

        private void CheckShip(Ship ship)
        {
            IReadOnlyList<ContainerRow> containerRows = ship.GetContainerRows();
            foreach (ContainerRow containerRow in containerRows)
            {
                IReadOnlyList<ContainerStack> containerStacks = containerRow.GetContainerStacks();
                int i = 0;
                
                foreach (ContainerStack containerStack in containerStacks)
                {
                    CheckContainerStack(containerStack);
                }
            }
        }

        private int CalculateContainerStackWeight(ContainerStack containerStack)
        {
            IReadOnlyList<Container> containers = containerStack.GetContainers();
            int weight = 0;
            foreach (Container container in containers)
                weight += container.Weight;

            return weight;
        }

        private void CheckContainerStack(ContainerStack containerStack)
        {

            IReadOnlyList<Container> containers = containerStack.GetContainers();
            int weight = 0;
            int i = 0;
            bool valuable = false;
            foreach (Container container in containers)
            {
                if (i != 0)
                    weight += container.Weight;

                if (valuable)
                    Assert.Fail("Container on top of valuable container");

                if (container.Type == ContainerType.Valuable || container.Type == ContainerType.ValuableCooled)
                    valuable = true;
            }
            if (weight > 120000)
                Assert.Fail("Weight > 120000");
        }

        private List<Container> CreateContainers()
        {
            List<Container> containers = new List<Container>();
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                containers.Add(new Container(ContainerType.Default, rand.Next(4, 30) * 1000));
            }

            for (int i = 0; i < 3; i++)
            {
                containers.Add(new Container(ContainerType.ValuableCooled, rand.Next(4, 30) * 1000));
            }
            for (int i = 0; i < 6; i++)
            {
                containers.Add(new Container(ContainerType.Cooled, rand.Next(4, 30) * 1000));
            }
            for (int i = 0; i < 5; i++)
            {
                containers.Add(new Container(ContainerType.Valuable, rand.Next(4, 30) * 1000));
            }
            return containers;
        }
    }
}