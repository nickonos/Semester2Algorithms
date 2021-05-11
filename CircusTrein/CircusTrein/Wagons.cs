using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    public class Wagon
    {
        private List<Animal> animals = new List<Animal>();
        private int MaxWeight { get; set; } = 10;
        private int CurrentWeight { get { return animals.Sum(e => (int)e.Weight); } }
        
        public Wagon(Animal animal)
        {
            animals.Add(animal);
        }

        private bool CheckIfAnimalFits(Animal animal)
        {
            if (GetCarnivoreWeight() > 0 && animal.Type == AnimalType.Carnivore)
                return false;

            if (GetCarnivoreWeight() >= (int)animal.Weight)
                return false;

            if (CurrentWeight + (int)animal.Weight > MaxWeight)
                return false;

            return true;
        }

        public bool TryAddAnimal(Animal animal)
        {
            if (!CheckIfAnimalFits(animal))
                return false;

            animals.Add(animal);
            return true;
        }

        public IReadOnlyList<Animal> GetAnimals()
        {
            return animals.AsReadOnly();
        }

        public int GetCarnivoreWeight()
        {
            Animal a = animals.Find(e => e.Type == AnimalType.Carnivore);
            if (a == null)
                return 0;

            return (int)a.Weight;
        }
    }

}
