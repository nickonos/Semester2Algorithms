using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    class Animal
    {
        public int Weight { get; set; }
        public bool IsCarnivore { get; set; }

        public Animal(int weight, bool isCarnivore)
        {
            Weight = weight;
            IsCarnivore = isCarnivore;
        }
    }
}
