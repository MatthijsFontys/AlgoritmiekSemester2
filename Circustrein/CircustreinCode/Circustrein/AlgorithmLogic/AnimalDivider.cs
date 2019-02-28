using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein.AlgorithmLogic {
    class AnimalDivider {
        private List<IAnimal> animals;
        public Train train { get; private set; } // How to name this property ?
        public ReadOnlyCollection<IAnimal> Animals {
            get { return animals.AsReadOnly(); }
        }

        public AnimalDivider(Train train, List<IAnimal> animals){
            this.train = train;
            this.animals = animals;
        }

        public int DivideAnimals() {
            return 0;
        }

        private IAnimal getLargestAnimal() {
            return new Carnivore();
        }

        private void divideCarnivores() { }

        private void divideHerbivores() { }

        private void fillSmallCarnivoreWagon() { }
    }
}
