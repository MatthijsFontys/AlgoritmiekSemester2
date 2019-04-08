using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public static class Factory {

        // Objects 
        public static Train CreateTrain() {
            return new Train();
        }

        public static Wagon CreateEmptyWagon(int maxCapacity = -1) {
            return (maxCapacity > 0) ? new Wagon(maxCapacity) : new Wagon();
        }

        public static Wagon CreateWagonWithAnimal(IAnimal animal, int maxCapacity = -1) {
            Wagon wagon =  (maxCapacity > 0) ? new Wagon(maxCapacity) : new Wagon();
            wagon.AddAnimal(animal);
            return wagon;
        }

        public static IAnimal CreateHerbivore(AnimalSize size) {
            return new Herbivore(size);
        }

        public static IAnimal CreateCarnivore(AnimalSize size) {
            return new Carnivore(size);
        }

        // Algorithm classes
        public static AnimalDivider CreateAnimalDivider(Train train, List<IAnimal> animals) {
            return new AnimalDivider(train, animals);
        }

    }
}
