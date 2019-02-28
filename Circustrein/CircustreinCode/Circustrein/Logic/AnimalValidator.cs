using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class AnimalValidator {

        public Animal Carnivore;
        public readonly int MaxCapacity;
        public int CurrentCapacity { get; private set; }

        public AnimalValidator(int maxCapacity) {
            MaxCapacity = maxCapacity;
            CurrentCapacity = 0;
            Carnivore = null;
        }

        public bool Validate(Animal animal) {
            if (DoesAnimalFit(animal)) {
                if (animal.Diet == AnimalDiet.Herbivore && (Carnivore == null || animal.Size > Carnivore.Size)) {
                    return true;
                }
                else if (animal.Diet == AnimalDiet.Carnivore && Carnivore == null) {
                    SetLargestCarnivore(animal);
                    return true;
                }
            }
            return false;
        }

        private void SetLargestCarnivore(Animal animal) {
            if (animal.Diet == AnimalDiet.Carnivore)
                Carnivore = animal;
        }

        private bool DoesAnimalFit(Animal animal) {
            return (int)animal.Size + CurrentCapacity <= MaxCapacity;
        }
    }
}
