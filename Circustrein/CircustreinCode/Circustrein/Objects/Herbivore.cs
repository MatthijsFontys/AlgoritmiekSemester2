using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Herbivore : IAnimal {
        private readonly AnimalSize size;
        public AnimalSize Size {
            get { return size; }
        }
        public int Weight {
            get { return (int)Size; }
        }

        public Herbivore(AnimalSize size) {
            this.size = size;
        }

        public bool IsSafeInWagon(Wagon wagon) {
            foreach (IAnimal animal in wagon.Animals) {
                if (animal.Weight >= Weight && animal is Carnivore)
                    return false;
            }
            return true;
        }

        public override string ToString() {
            return "H" + Weight;
        }
    }
}
