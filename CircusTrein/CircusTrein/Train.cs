using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    public class Train
    {
        private List<Animal> UnusedAnimals = new List<Animal>();
        private List<Wagon> Wagons = new List<Wagon>();

        public void AddAnimal(int amount, AnimalWeight weight, AnimalType type)
        {
            for (int i = 0; i < amount; i++)
            {
                UnusedAnimals.Add(new Animal(weight, type));
            }
        }

        public void ClearTrain()
        {
            UnusedAnimals.Clear();
            Wagons.Clear();
        }

        public List<Wagon> FillTrain()
        {
            CreateWagonsForCarnivore();

            AddAnimalsToWagons();

            return Wagons;
        }

        private void AddAnimalsToWagons()
        {
            foreach (Animal animal in UnusedAnimals.ToList())
            {
                if (Wagons.Count > 0)
                {
                    if (!AddAnimalIfFits(animal))
                    {
                        Wagons.Add(new Wagon(animal));
                        UnusedAnimals.Remove(animal);
                    }
                }
                else
                {
                    Wagons.Add(new Wagon(animal));
                    UnusedAnimals.Remove(animal);
                }
            }
            
        }

        private bool AddAnimalIfFits(Animal animal)
        {
            foreach (Wagon wagon in Wagons.ToList())
            {
                if (wagon.TryAddAnimal(animal))
                {
                    UnusedAnimals.Remove(animal);
                    return true;
                }       
            }
            return false;

        }

        private void CreateWagonsForCarnivore()
        {
            foreach (Animal animal in UnusedAnimals.ToList())
            {
                if (animal.Type == AnimalType.Carnivore)
                {
                    Wagons.Add(new Wagon(animal));
                    UnusedAnimals.Remove(animal);
                }
            }
        }
    }
}
