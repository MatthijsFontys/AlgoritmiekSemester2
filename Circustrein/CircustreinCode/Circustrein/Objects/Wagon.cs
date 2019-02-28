using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    class Wagon {
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
        }

        public bool AddAnimal(IAnimal animal) {
            return true;
        }

        private bool doesAnimalFit() {
            return true;
        }

        private bool doesAnimalGetEaten(List<IAnimal> hosileAnimals) {
            return true;
        }

    }
}
