using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Horde {
        private readonly char animalType;
        private readonly AnimalSize size;
        private readonly int amount;

        public Horde(char animalType, AnimalSize size, int amount) {
            this.animalType = animalType;
            this.size = size;
            this.amount = amount;
        }

        public List<IAnimal> GetHorde() {
            List<IAnimal> toReturn = new List<IAnimal>();
            for (int i = 0; i < amount; i++) {
                if (animalType.ToString().ToLower() == "c")
                    toReturn.Add(Factory.CreateCarnivore(size));
                else
                    toReturn.Add(Factory.CreateHerbivore(size));
            }
            return toReturn;
        }
    }
}
