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
        public Form1() {
            InitializeComponent();
        }

        // Eventhandlers
        private void BtnAddAnimals_Click(object sender, EventArgs e)
        {
            AnimalSize size = getAnimalSizeFromDropdown();
            AnimalDiet diet = getAnimalDietFromDropdown();
            int animalCount = (int)NumAmount.Value;
            for (int i = 0; i < animalCount; i++)
                LbAnimals.Items.Add(Factory.CreateAnimal(size, diet));
        }


        private AnimalSize getAnimalSizeFromDropdown()
        {
            switch (CbSize.Text.ToLower())
            {
                case "small":
                    return AnimalSize.Small;
                case "medium":
                    return AnimalSize.Medium;
                case "large":
                    return AnimalSize.Large;
                default:
                    return AnimalSize.Small;
            }
        }

        private AnimalDiet getAnimalDietFromDropdown() {
            switch (CbDiet.Text.ToLower()) {
                case "carnivore":
                    return AnimalDiet.Carnivore;
                case "herbivore":
                    return AnimalDiet.Herbivore;
                default:
                    return AnimalDiet.Herbivore;
            }
        }

        private void BtnDivideAnimals_Click(object sender, EventArgs e) {
        }
    }
}
