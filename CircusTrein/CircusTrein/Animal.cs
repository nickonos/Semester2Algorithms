using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    public class Animal
    {
        public AnimalWeight Weight { get; private set; }
        public AnimalType Type { get; private set; }

        public Animal(AnimalWeight weight, AnimalType type)
        {
            Weight = weight;
            Type = type;
        }
    }
}
