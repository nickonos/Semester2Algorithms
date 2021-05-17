using ContainerVervoer;
using NUnit.Framework;

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
            Ship ship = new Ship(new IntVector2(4, 4), 1000000000);
            ship.CalculateWeightDifference();
            Assert.Pass();
        }
    }
}