using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    class Train
    {
        public List<Animal> UnusedAnimals = new List<Animal>();
        public List<Wagon> FullWagons = new List<Wagon>();
        public List<Wagon> Wagons = new List<Wagon>();

        public void FillTrain()
        {
            foreach(Animal animal in UnusedAnimals.ToList())
            {
                if (animal.IsCarnivore)
                {
                    Wagons.Add(new Wagon(animal));
                    UnusedAnimals.Remove(animal);
                }
            }

            foreach(Wagon wagon in Wagons.ToList())
            {
                if(wagon.CarinvoreWeight == 5)
                {
                    FullWagons.Add(wagon);
                    Wagons.Remove(wagon);
                }
                else
                {
                    foreach(Animal animal in UnusedAnimals.ToList())
                    {
                        if (wagon.CarinvoreWeight < animal.Weight && wagon.CurrentWeight + animal.Weight <= wagon.MaxWeight)
                        {
                            wagon.animals.Add(animal);
                            wagon.CurrentWeight += animal.Weight;
                            UnusedAnimals.Remove(animal);
                        }
                    }
                    FullWagons.Add(wagon);
                    Wagons.Remove(wagon);
                }
            }
            //AddLastAnimals();
            foreach (Animal animal in UnusedAnimals.ToList())
            {
                if (Wagons.Count != 0)
                {
                    foreach (Wagon wagon in Wagons.ToList())
                    {
                        if (wagon.CurrentWeight + animal.Weight <= wagon.MaxWeight)
                        {
                            wagon.animals.Add(animal);
                            wagon.CurrentWeight += animal.Weight;
                            UnusedAnimals.Remove(animal);
                        }
                        else
                        {
                            FullWagons.Add(wagon);
                            Wagons.Remove(wagon);
                        }
                    }
                }
                else
                {
                    Wagons.Add(new Wagon(animal));
                    UnusedAnimals.Remove(animal);
                }
            }
            foreach (Wagon wagon in Wagons.ToList())
            {
                FullWagons.Add(wagon);
                Wagons.Remove(wagon);
            }
        }

        public void AddAnimal(int amount, int weight, bool IsCarnivore)
        {
            for (int i = 0; i < amount; i++)
            {
                UnusedAnimals.Add(new Animal(weight, IsCarnivore));
            }
        }

        //public void AddLastAnimals()
        //{
        //    if(UnusedAnimals.Count != 0)
        //    {
        //        if (Wagon)
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
    }
}
