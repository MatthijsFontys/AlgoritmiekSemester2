using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Horde {
        private readonly AnimalHordeType animalType;
        private readonly AnimalSize size;
        private readonly int amount;

        public Horde(AnimalHordeType animalType, AnimalSize size, int amount) {
            this.animalType = animalType;
            this.size = size;
            this.amount = amount;
        }

        public List<IAnimal> GetHorde() {
            List<IAnimal> toReturn = new List<IAnimal>();
            for (int i = 0; i < amount; i++) {
                if (animalType == AnimalHordeType.carnivore)
                    toReturn.Add(Factory.CreateCarnivore(size));
                else
                    toReturn.Add(Factory.CreateHerbivore(size));
            }
            return toReturn;
        }
    }
}
