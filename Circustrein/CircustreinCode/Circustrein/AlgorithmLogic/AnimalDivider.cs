using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Circustrein {
    public class AnimalDivider {
        private List<IAnimal> animals;
        public Train AnimalTrain { get; private set; }
        public ReadOnlyCollection<IAnimal> Animals {
            get { return animals.AsReadOnly(); }
        }

        public AnimalDivider(Train train, List<IAnimal> animals){
            this.AnimalTrain = train;
            this.animals = animals;
        }

        public void DivideAnimals() {
            DivideCarnivores();
            AnimalTrain.SortWagonsByCarnivoreSizeDescending();
            SortAnimalsBySizeDescending();
            DivideHerbivores();
        }

        private void DivideCarnivores() {
            for (int i = 0; i < animals.Count; i++) {
                if (animals[i] is Carnivore) {
                    AnimalTrain.AddWagon(Factory.CreateWagonWithAnimal(animals[i]));
                    animals.RemoveAt(i);
                    i--; // Because the offset of the list changes when removing an element;
                }
            }
        }

        private void DivideHerbivores() {
            foreach (Wagon wagon in AnimalTrain.Wagons) {
                if (wagon.IsSmallCarnivoreWagon())
                    FillSmallCarnivoreWagon(wagon);
                else
                    FillRegularWagon(wagon);
            }

            ContinueSortingIfNotDone();
        }

        private void FillSmallCarnivoreWagon(Wagon wagon) {
            List<IAnimal> mediumHerbivores = GetThreeMediumHerbivore(animals);
            if (mediumHerbivores != null) {
                TryAddAnimalsToWagon(mediumHerbivores, wagon);
            }
            else
                FillRegularWagon(wagon);               
        }

        private void FillRegularWagon(Wagon wagon) {
            for (int i = 0; i < animals.Count; i++) {
                i = (TryAddAnimalToWagon(animals[i], wagon)) ? i -=1 : i;
            }
        }

        private List<IAnimal> GetThreeMediumHerbivore(List<IAnimal> animals) {
            List<IAnimal> toReturn = animals.Where(x => x is Herbivore && x.Size == AnimalSize.Medium).Take(3).ToList();
            return (toReturn.Count == 3) ? toReturn : null;
        }

        private void SortAnimalsBySizeDescending() {
            animals = animals.OrderByDescending(x => x.Size).ToList();
        }

        private void ContinueSortingIfNotDone() {
            if (animals.Count > 0) {
                AnimalTrain.AddWagon(Factory.CreateEmptyWagon());
                DivideHerbivores();
            }
        }

        private void RemoveAnimal(IAnimal animal) {
            animals.Remove(animal);
        }

        private bool TryAddAnimalToWagon(IAnimal animal, Wagon wagon) {
            if (wagon.TryAddAnimal(animal)) {
                animals.Remove(animal);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if all animals are added successfully else returns false
        /// </summary>
        private bool TryAddAnimalsToWagon(IEnumerable<IAnimal> animals, Wagon wagon) {
            bool toReturn = true;
            foreach (IAnimal animal in animals) {
                if (!TryAddAnimalToWagon(animal, wagon))
                    toReturn = false;
                else
                    RemoveAnimal(animal);
            }
            return toReturn;
        }
    }
}
