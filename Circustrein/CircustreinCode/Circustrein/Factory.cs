using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public static class Factory {
        public static Animal CreateAnimal(AnimalSize size, AnimalDiet diet) {
            return new Animal(size, diet);
        }

        public static AnimalValidator CreateAnimalValidator(int maxCapacity) {
            return new AnimalValidator(maxCapacity);
        }

        public static Wagon CreateWagon(int maxCapacity) {
            return new Wagon(CreateAnimalValidator(maxCapacity), maxCapacity);
        }

        public static void AddWagon(Train train, int maxCapacity) {
            train.AddWagon(CreateWagon(maxCapacity));
        }
    }
}
