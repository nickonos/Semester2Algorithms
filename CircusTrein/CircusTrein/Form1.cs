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
            train.FullWagons.Clear();
            train.Wagons.Clear();
            train.UnusedAnimals.Clear();

            train.AddAnimal((int)SmallHerbivore.Value,1,false);
            train.AddAnimal((int)MediumHerbivore.Value, 3, false);
            train.AddAnimal((int)BigHerbivore.Value, 5, false);
            train.AddAnimal((int)SmallCarnivore.Value, 1, true);
            train.AddAnimal((int)MediumCarnivore.Value, 3, true);
            train.AddAnimal((int)BigCarnivore.Value, 5, true);

            train.FillTrain();

            foreach(Wagon wagon in train.FullWagons.ToList())
            {
                string outp = "";
                foreach(Animal animal in wagon.animals.ToList())
                {
                    outp += $"{animal.Weight} {animal.IsCarnivore}, ";
                }
                listBox1.Items.Add(outp);
            }
        }

        private void MediumHerbivore_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
