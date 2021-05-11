using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircusTrein
{
    public partial class Form1 : Form
    {
        Train train = new Train();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            train.ClearTrain();

            train.AddAnimal((int)SmallHerbivore.Value, AnimalWeight.Small ,AnimalType.Herbivore);
            train.AddAnimal((int)MediumHerbivore.Value, AnimalWeight.Medium, AnimalType.Herbivore);
            train.AddAnimal((int)BigHerbivore.Value, AnimalWeight.Large, AnimalType.Herbivore);
            train.AddAnimal((int)SmallCarnivore.Value, AnimalWeight.Small, AnimalType.Carnivore);
            train.AddAnimal((int)MediumCarnivore.Value, AnimalWeight.Medium, AnimalType.Carnivore);
            train.AddAnimal((int)BigCarnivore.Value, AnimalWeight.Large, AnimalType.Carnivore);

            List<Wagon> wagons = train.FillTrain();

            foreach(Wagon wagon in wagons)
            {
                string outp = "";
                foreach(Animal animal in wagon.GetAnimals())
                {
                    outp += $"{animal.Weight} {animal.Type}, ";
                }
                listBox1.Items.Add(outp);
            }
        }

        private void MediumHerbivore_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
