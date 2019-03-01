using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Wagon {
        private List<IAnimal> animals;

        public ReadOnlyCollection<IAnimal> Animals {
            get { return animals.AsReadOnly(); }
        }
        public readonly int MaxCapacity;
        public int CurrentCapacity { get; private set; }
        public IAnimal BiggestCarnivore;
        

        public Wagon(int maxCapacity = 10) {
            MaxCapacity = maxCapacity;
            BiggestCarnivore = null;
            CurrentCapacity = 0;
            animals = new List<IAnimal>();
        }

        public bool AddAnimal(IAnimal animal) {
            if (doesAnimalFit(animal) && animal.IsSafeInWagon(this)) {
                animals.Add(animal);
                setBiggestCarnivore(animal);
                CurrentCapacity += animal.Weight;
                return true;
            }
            else
                return false;
        }

        public bool IsSmallCarnivoreWagon() {
            return (BiggestCarnivore.Size == AnimalSize.Small &&
                CurrentCapacity == (int)AnimalSize.Small);
        }

        private bool doesAnimalFit(IAnimal animal) {
            return animal.Weight + CurrentCapacity <= MaxCapacity;
        }

        private void setBiggestCarnivore(IAnimal animal) {
            if (animal is Carnivore) {
                BiggestCarnivore = animal;
            }
        }

    }
}
