using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class AnimalDivider {
        private List<IAnimal> animals;
        public Train train { get; private set; } // How to name this property ?
        public ReadOnlyCollection<IAnimal> Animals {
            get { return animals.AsReadOnly(); }
        }

        public AnimalDivider(Train train, List<IAnimal> animals){
            this.train = train;
            this.animals = animals;
        }

        public void DivideAnimals() {
            divideCarnivores();
            divideHerbivores();
        }

        private void divideCarnivores() {
            foreach (IAnimal animal in animals) {
                if (animal is Carnivore) {
                    train.AddWagon(Builder.CreateWagonWithAnimal(animal));
                    animals.Remove(animal);
                }
            }
        }

        private void divideHerbivores() {
            foreach (Wagon wagon in train.Wagons) {
                if(wagon.IsSmallCarnivoreWagon())
                    fillSmallCarnivoreWagon(wagon);
            }
        }

        private void fillSmallCarnivoreWagon(Wagon wagon) {
        }

        //private bool doneDividing() {
        //    return animals.Count > 0;
        //}
    }
}
