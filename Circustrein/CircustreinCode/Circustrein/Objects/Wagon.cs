using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Wagon {
        private List<IAnimal> animals;
        private static int count = 0;
        private readonly int wagonNumber;

        public ReadOnlyCollection<IAnimal> Animals {
            get { return animals.AsReadOnly(); }
        }
        public readonly int MaxCapacity;
        public int CurrentCapacity { get; private set; }
        public IAnimal BiggestCarnivore {
            get {
                return animals.Where(x => x is Carnivore).OrderByDescending(x => x.Size).FirstOrDefault();
            }
        }
        

        public Wagon(int maxCapacity = 10) {
            count++;
            wagonNumber = count;
            MaxCapacity = maxCapacity;
            CurrentCapacity = 0;
            animals = new List<IAnimal>();
        }

        public bool TryAddAnimal(IAnimal animal) {
            if (DoesAnimalFit(animal) && animal.IsSafeInWagon(this)) {
                animals.Add(animal);
                CurrentCapacity += animal.Weight;
                return true;
            }
            else
                return false;
        }

        public bool IsSmallCarnivoreWagon() {
            return (BiggestCarnivore != null && BiggestCarnivore.Size == AnimalSize.Small &&
                CurrentCapacity == (int)AnimalSize.Small);
        }

        private bool DoesAnimalFit(IAnimal animal) {
            return animal.Weight + CurrentCapacity <= MaxCapacity;
        }

        public override string ToString() {
            return "Wagon " + wagonNumber;
        }

    }
}