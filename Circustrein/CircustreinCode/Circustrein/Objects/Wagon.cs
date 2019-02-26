using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Wagon {
        private AnimalValidator animalValidator;
        private List<Animal> animals;
        public static int Count { get; private set; }

        public ReadOnlyCollection<Animal> Animals {
            get { return animals.AsReadOnly(); }
        }

        public Wagon(AnimalValidator animalValidator, int maxCapacity) {
            Count++;
        }

        public bool AddAnimal(Animal animal) {
            if (animalValidator.Validate(animal))
            {
                AddAnimal(animal);
                return true;
            }
            else
                return false;
        }

        public override string ToString() {
            return "Wagon " + Count;
        }
    }
}