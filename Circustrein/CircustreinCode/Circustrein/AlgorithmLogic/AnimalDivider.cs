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
            train.SortWagons();
            sortAnimals();
            divideHerbivores();
        }

        private void divideCarnivores() {
            for (int i = 0; i < animals.Count; i++) {
                if (animals[i] is Carnivore) {
                    train.AddWagon(Builder.CreateWagonWithAnimal(animals[i]));
                    animals.RemoveAt(i);
                    i--; // Because the offset of the list changes when removing an element;
                }
            }
        }

        private void divideHerbivores() {
            foreach (Wagon wagon in train.Wagons) {
                if (wagon.IsSmallCarnivoreWagon())
                    fillSmallCarnivoreWagon(wagon);
                else
                    fillRegularWagon(wagon);
            }

            doneDividing();
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
                if (wagon.AddAnimal(animals[i])) {
                    removeAnimal(animals[i]);
                    i--;
                }
            }
            //foreach (IAnimal animal in animals) {
            //    wagon.AddAnimal(animal);
            //    removeAnimal(animal);
            //}
        }

        private List<IAnimal> getThreeMediumHerbivore(List<IAnimal> animals) {
            List<IAnimal> toReturn = animals.Where(x => x is Herbivore && x.Size == AnimalSize.Medium).Take(3).ToList();
            return (toReturn.Count == 3) ? toReturn : null;
        }

        private void sortAnimals() {
            animals = AnimalWagonSorter.SortAnimalsBySizeDescending(animals);
        }

        private void doneDividing() {
            //return animals.Count > 0;
            if (animals.Count > 0) {
                train.AddWagon(Builder.CreateEmptyWagon());
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
    }
}
