using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    class Wagon
    {
        public List<Animal> animals = new List<Animal>();
        public int MaxWeight { get; set; } = 10;
        public int CurrentWeight { get; set; } = 0;
        public int CarinvoreWeight { get; set; } = 0;
        public Wagon(Animal animal)
        {
            animals.Add(animal);
            CurrentWeight += animal.Weight;

            if (animal.IsCarnivore)
                CarinvoreWeight = animal.Weight;
        }

        public bool CheckWeight(int a)
        {

        }
    }

}
