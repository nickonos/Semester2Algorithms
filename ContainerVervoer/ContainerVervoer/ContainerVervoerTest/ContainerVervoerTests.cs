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
        public void TestShipEven()
        {
            Ship ship = new Ship(new IntVector2(4, 4), 1000000000);
            List<Container> containers = CreateContainers();
            ship.AddContainers(containers);
            ship.Sort();
            CheckShip(ship, new IntVector2(4, 4));

            Assert.Pass();
        }

        [Test]
        public void TestShipOdd()
        {
            Ship ship = new Ship(new IntVector2(5, 5), 1000000000);
            List<Container> containers = CreateContainers();
            ship.AddContainers(containers);
            ship.Sort();
            CheckShip(ship, new IntVector2(5, 5));

            Assert.Pass();
        }
        [Test]
        public void TestContainerStackWeightWontExceed()
        {
            ContainerStack containerStack = new ContainerStack();
            containerStack.AddContainer(new Container(ContainerType.Default, 30000));
            containerStack.AddContainer(new Container(ContainerType.Default, 30000));
            containerStack.AddContainer(new Container(ContainerType.Default, 30000));
            containerStack.AddContainer(new Container(ContainerType.Default, 30000));
            containerStack.AddContainer(new Container(ContainerType.Default, 30000));

            Assert.IsFalse(containerStack.AddContainer(new Container(ContainerType.Default, 30000)));
        }

        [Test]
        public void TestContainerStackWontContainerOnTopOfValuable()
        {
            ContainerStack containerStack = new ContainerStack();
            containerStack.AddContainer(new Container(ContainerType.Valuable, 30000));
            if (containerStack.AddContainer(new Container(ContainerType.Default, 30000)))
                Assert.Fail("Container is allowed ontop of valuable container");

            containerStack = new ContainerStack();
            containerStack.AddContainer(new Container(ContainerType.ValuableCooled, 30000));
            if (containerStack.AddContainer(new Container(ContainerType.Default, 30000)))
                Assert.Fail("Container is allowed ontop of valuableCooled container");

            Assert.Pass();
        }

        [Test]
        public void TestCalculateWeightOnTop()
        {
            ContainerStack containerStack = new ContainerStack();
            containerStack.AddContainer(new Container(ContainerType.Default, 30000));
            containerStack.AddContainer(new Container(ContainerType.Default, 20000));
            containerStack.AddContainer(new Container(ContainerType.Default, 25000));
            containerStack.AddContainer(new Container(ContainerType.Default, 10000));

            Assert.AreEqual(containerStack.CalculateWeightOnTop(), 55000);
        }

        [Test]
        public void TestCalculateWeight()
        {
            ContainerStack containerStack = new ContainerStack();
            containerStack.AddContainer(new Container(ContainerType.Default, 30000));
            containerStack.AddContainer(new Container(ContainerType.Default, 20000));
            containerStack.AddContainer(new Container(ContainerType.Default, 25000));
            containerStack.AddContainer(new Container(ContainerType.Default, 10000));

            Assert.AreEqual(containerStack.CalculateWeight(), 85000);
        }

        private void CheckShip(Ship ship, IntVector2 shipSize)
        {
            double WeightLeft = 0;
            double WeightRight = 0;

            IReadOnlyList<ContainerRow> containerRows = ship.GetContainerRows();
            foreach (ContainerRow containerRow in containerRows)
            {
                IReadOnlyList<ContainerStack> containerStacks = containerRow.GetContainerStacks();
                int i = 0;

                foreach (ContainerStack containerStack in containerStacks)
                {
                    CheckContainerStack(containerStack);
                    BalanceContainerStack(containerStack, i, shipSize.X, ref WeightLeft, ref WeightRight);
                    i++;
                }
            }
            double balance = (WeightRight / (WeightRight + WeightLeft) * 100) - (WeightLeft / (WeightLeft + WeightRight) * 100);
            if (balance > 20 || balance < -20)
                Assert.Fail($"Ship not in balance value:{balance}");

            CheckIfValuableAccessable(containerRows, shipSize);
        }

        private void CheckIfValuableAccessable(IReadOnlyList<ContainerRow> containerRows, IntVector2 shipSize)
        {
            List<IntVector2> valuables = GetAllValuableContainersPositions(containerRows);

            foreach(IntVector2 valuable in valuables)
            {
                IReadOnlyList<ContainerStack> Checkrow = containerRows[valuable.X].GetContainerStacks();
                int height = Checkrow[valuable.Y].GetHeight();
                bool succes = true;
                if (valuable.X == 0 || valuable.X == shipSize.Y - 1)
                    return;

                for (int i = valuable.Y; i < shipSize.X; i++)
                {
                    IReadOnlyList<ContainerStack> stacks = containerRows[i].GetContainerStacks();
                    if (stacks[i].GetContainers().Count >= height)
                        succes = false;
                }
                if (succes)
                    return;

                for (int i = valuable.Y; i > 0; i--)
                {
                    IReadOnlyList<ContainerStack> stacks = containerRows[i].GetContainerStacks();
                    if (stacks[i].GetContainers().Count >= height)
                        Assert.Fail("Valuable Container not Accessable");
                }
            }
        }

        private List<IntVector2> GetAllValuableContainersPositions(IReadOnlyList<ContainerRow> containerRows)
        {
            List<IntVector2> containerPositions = new List<IntVector2>();
            int i = 0;
            foreach(ContainerRow containerRow in containerRows)
            {
                int j = 0;
                foreach(ContainerStack containerStack in containerRow.GetContainerStacks())
                {
                    IReadOnlyList<Container> containers = containerStack.GetContainers();
                    if (containers.Count != 0 && containers[containers.Count - 1].Type == ContainerType.Valuable)
                        containerPositions.Add(new IntVector2(j, i));
                }
            }

            return containerPositions;
        }

        private void BalanceContainerStack(ContainerStack containerStack, int i, int width,ref double WeightLeft, ref double WeightRight)
        {
            if (width % 2 == 0)
            {
                if (i < width / 2)
                    WeightLeft += CalculateContainerStackWeight(containerStack);
                else
                    WeightRight += CalculateContainerStackWeight(containerStack);
            }
            else
            {
                if (i == width / 2)
                {
                }
                else if (i < width / 2)
                    WeightLeft += CalculateContainerStackWeight(containerStack);
                else
                    WeightRight += CalculateContainerStackWeight(containerStack);
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