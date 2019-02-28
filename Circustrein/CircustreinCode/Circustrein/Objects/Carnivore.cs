using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein. {
    public class Carnivore : IAnimal {
        public AnimalSize Size => throw new NotImplementedException();

        public List<IAnimal> GetHostileAnimals() {
            throw new NotImplementedException();
        }
    }
}
