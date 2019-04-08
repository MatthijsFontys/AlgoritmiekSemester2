using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circustrein {
    public partial class Form1 : Form {

        List<IAnimal> animalsToDivide;
        private AnimalDivider divider;

        public Form1() {
            InitializeComponent();
            Setup();
        }

        private void Setup() {
            animalsToDivide = new List<IAnimal>();
            CbSize.Items.Add(AnimalSize.Small);
            CbSize.Items.Add(AnimalSize.Medium);
            CbSize.Items.Add(AnimalSize.Large);
        }

        // Eventhandlers
        private void BtnAddAnimals_Click(object sender, EventArgs e){
            AnimalSize size = (AnimalSize)CbSize.SelectedItem;
            
            for (int i = 0; i < NumAmount.Value; i++) {
                if (CbDiet.SelectedItem.ToString().ToLower() == "carnivore")
                    animalsToDivide.Add(Factory.CreateCarnivore(size));
                else
                    animalsToDivide.Add(Factory.CreateHerbivore(size));

                LbAnimals.Items.Add(animalsToDivide[animalsToDivide.Count - 1]);
            }

        }

        private void BtnDivideAnimals_Click(object sender, EventArgs e) {
            divider = new AnimalDivider(Factory.CreateTrain(), animalsToDivide);
            divider.DivideAnimals();
            LblWagonCount.Text = divider.AnimalTrain.Wagons.Count.ToString();
            fillListBoxWagons();
        }

        private void fillListBoxWagons() {
            foreach (Wagon wagon in divider.AnimalTrain.Wagons) {
                LbWagons.Items.Add(wagon);
            }
        }

        private void LbWagons_SelectedIndexChanged(object sender, EventArgs e) {
            LbAnimals.Items.Clear();
            Wagon wagon = LbWagons.SelectedItem as Wagon;
            foreach (IAnimal animal in wagon.Animals) {
                LbAnimals.Items.Add(animal);
            }
        }
    }
}
