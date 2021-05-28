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
            IReadOnlyList<ContainerRow> containerRows = ship.GetContainerRows();
            Assert.Pass();
        }

        [Test]
        public void TestShipOdd()
        {
            Ship ship = new Ship(new IntVector2(5, 5), 1000000000);
            Assert.Pass();
        }

        static List<Container> CreateContainers()
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