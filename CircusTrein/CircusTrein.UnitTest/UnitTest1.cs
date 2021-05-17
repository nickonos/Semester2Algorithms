using NUnit.Framework;
using CircusTrein;
using System.Collections.Generic;

namespace CircusTrein.UnitTest
{
    public class Tests
    {
        Train train = new Train();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfFillTrainMakesLeastAmountofWagons()
        {
            train.AddAnimal(1, AnimalWeight.Large, AnimalType.Carnivore);
            train.AddAnimal(1, AnimalWeight.Medium, AnimalType.Carnivore);
            train.AddAnimal(1, AnimalWeight.Small, AnimalType.Carnivore);
            train.AddAnimal(1, AnimalWeight.Large, AnimalType.Herbivore);
            train.AddAnimal(1, AnimalWeight.Medium, AnimalType.Herbivore);
            train.AddAnimal(1, AnimalWeight.Small, AnimalType.Herbivore);

            List<Wagon> wagons = train.FillTrain();

            Assert.IsTrue(wagons.Count == 4);
        }

        [Test]
        public void TestIfFillTrainMakesValidWagons()
        {
            train.AddAnimal(10, AnimalWeight.Large, AnimalType.Carnivore);
            train.AddAnimal(10, AnimalWeight.Medium, AnimalType.Carnivore);
            train.AddAnimal(10, AnimalWeight.Small, AnimalType.Carnivore);
            train.AddAnimal(10, AnimalWeight.Large, AnimalType.Herbivore);
            train.AddAnimal(10, AnimalWeight.Medium, AnimalType.Herbivore);
            train.AddAnimal(10, AnimalWeight.Small, AnimalType.Herbivore);

            List<Wagon> wagons = train.FillTrain();

            foreach (Wagon wagon in wagons)
            {
                int i = 0;
                int CarinvoreCount = 0;
                foreach (Animal animal in wagon.GetAnimals())
                {
                    i += (int)animal.Weight;
                    if (animal.Type == AnimalType.Carnivore)
                        CarinvoreCount++;

                }
                if (i > 10)
                    Assert.Fail();

                if (CarinvoreCount > 1)
                    Assert.Fail();
            }
        }

        [Test]
        public void TestAnimalWontAddIfCarvicoreIsLarge()
        {
            Wagon wagon = new Wagon(new Animal(AnimalWeight.Large, AnimalType.Carnivore));
            Assert.IsFalse(wagon.TryAddAnimal(new Animal(AnimalWeight.Large, AnimalType.Herbivore)));
        }

        [Test]
        public void TestAnimalWontAddIfWeightIsMax()
        {
            Wagon wagon = new Wagon(new Animal(AnimalWeight.Large, AnimalType.Herbivore));
            wagon.TryAddAnimal(new Animal(AnimalWeight.Large, AnimalType.Herbivore));
            Assert.IsFalse(wagon.TryAddAnimal(new Animal(AnimalWeight.Small, AnimalType.Herbivore)));
        }

        [Test]
        public void CheckIfCarnivoreIsAddedToWagon()
        {
            Wagon wagon = new Wagon(new Animal(AnimalWeight.Large, AnimalType.Carnivore));
            Assert.IsTrue(wagon.GetCarnivoreWeight() == 5);
        }
    }
}