using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Carnivore : IAnimal {
        private readonly AnimalSize size;
        public AnimalSize Size {
            get { return size; }
        }

        public Carnivore(AnimalSize size) {
            this.size = size;
        }

        public bool IsSafeInWagon(Wagon wagon) {
            foreach (IAnimal animal in wagon.Animals) {
                if (animal is Carnivore)
                    return false;
            }
            return true;
        }
    }
}
