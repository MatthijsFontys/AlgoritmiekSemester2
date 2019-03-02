using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Circustrein {
    public class AnimalDivider {
        private List<IAnimal> animals;
        public Train AnimalTrain { get; private set; } // How to name this property ?
        public ReadOnlyCollection<IAnimal> Animals {
            get { return animals.AsReadOnly(); }
        }

        public AnimalDivider(Train train, List<IAnimal> animals){
            this.AnimalTrain = train;
            this.animals = animals;
        }

        public void DivideAnimals() {
            divideCarnivores();
            AnimalTrain.SortWagonsByCarnivoreSizeDescending();
            SortAnimalsBySizeDescending();
            divideHerbivores();
        }

        private void divideCarnivores() {
            for (int i = 0; i < animals.Count; i++) {
                if (animals[i] is Carnivore) {
                    AnimalTrain.AddWagon(Builder.CreateWagonWithAnimal(animals[i]));
                    animals.RemoveAt(i);
                    i--; // Because the offset of the list changes when removing an element;
                }
            }
        }

        private void divideHerbivores() {
            foreach (Wagon wagon in AnimalTrain.Wagons) {
                if (wagon.IsSmallCarnivoreWagon())
                    fillSmallCarnivoreWagon(wagon);
                else
                    fillRegularWagon(wagon);
            }

            continueSortingIfNotDone();
        }

        private void fillSmallCarnivoreWagon(Wagon wagon) {
            List<IAnimal> mediumHerbivores = getThreeMediumHerbivore(animals);
            if (mediumHerbivores != null) {
                wagon.AddAnimals(mediumHerbivores);
                removeAnimals(mediumHerbivores);
            }
            else
                fillRegularWagon(wagon);
                
        }

        private void fillRegularWagon(Wagon wagon) {
            for (int i = 0; i < animals.Count; i++) {
                i = (tryAddAnimalToWagon(animals[i], wagon)) ? i -=1 : i;
            }
        }

        private List<IAnimal> getThreeMediumHerbivore(List<IAnimal> animals) {
            List<IAnimal> toReturn = animals.Where(x => x is Herbivore && x.Size == AnimalSize.Medium).Take(3).ToList();
            return (toReturn.Count == 3) ? toReturn : null;
        }

        private void SortAnimalsBySizeDescending() {
            animals = animals.OrderByDescending(x => x.Size).ToList();
        }

        private void continueSortingIfNotDone() {
            if (animals.Count > 0) {
                AnimalTrain.AddWagon(Builder.CreateEmptyWagon());
                divideHerbivores();
            }
        }

        private void removeAnimal(IAnimal animal) {
            animals.Remove(animal);
        }

        private void removeAnimals(List<IAnimal> animals) {
            foreach (IAnimal animal in animals) {
                this.animals.Remove(animal);
            }
        }

        private bool tryAddAnimalToWagon(IAnimal animal, Wagon wagon) {
            if (wagon.AddAnimal(animal)) {
                animals.Remove(animal);
                return true;
            }
            return false;
        }
    }
}
