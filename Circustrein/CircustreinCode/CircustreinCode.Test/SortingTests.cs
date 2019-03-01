using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System.Collections.Generic;

namespace CircustreinCode.Test {
    [TestClass]
    public class SortingTests {

        // Sorting animals
        [TestMethod]
        public void SortAnimalsBySizeDescending_HerbivoreAndCarnivore_NoDuplicates_Succes() {
            List<IAnimal> animals = new List<IAnimal> {
                Builder.CreateCarnivore(AnimalSize.Medium),
                Builder.CreateHerbivore(AnimalSize.Large),
                Builder.CreateCarnivore(AnimalSize.Small)
            };

            animals = AnimalWagonSorter.SortAnimalsBySizeDescending(animals);
            int previousSize = 1000;

            foreach (IAnimal animal in animals) {
                Assert.IsTrue((int)animal.Size <= previousSize);
                previousSize = (int)animal.Size;
            }
        }

        // Sorting wagons
        [TestMethod]
        public void SortWagonsByCarnivoreSizeDescending_HerbivoreAndCarnivore_Succes() {
            List<Wagon> wagons = new List<Wagon> {
                Builder.CreateEmptyWagon(),
                Builder.CreateEmptyWagon(),
                Builder.CreateEmptyWagon()
            };

            wagons[0].AddAnimal(Builder.CreateHerbivore(AnimalSize.Large));
            wagons[1].AddAnimal(Builder.CreateCarnivore(AnimalSize.Small));
            wagons[2].AddAnimal(Builder.CreateCarnivore(AnimalSize.Large));

            wagons = AnimalWagonSorter.SortWagonsByCarnivoreSizeDescending(wagons);

            Assert.IsTrue(wagons[0].Animals[0].Size == AnimalSize.Large &&
                wagons[0].Animals[0] is Carnivore);
            Assert.IsTrue(wagons[1].Animals[0] is Carnivore);
            Assert.IsTrue(wagons[2].Animals[0] is Herbivore);
        }
    }
}
