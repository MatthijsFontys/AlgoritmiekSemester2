using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System.Collections.Generic;

namespace CircustreinCode.Test {
    [TestClass]
    public class SorterTests {

        Sorter sorter;

        [TestInitialize]
        public void Setup() {
            sorter = new Sorter();
        }


        [TestMethod]
        public void SortAnimalsBySize_Unsorted_DifferentDiet() {
            List<Animal> actual = new List<Animal> {
                new Animal(AnimalSize.Small, AnimalDiet.Carnivore),
                new Animal(AnimalSize.Medium, AnimalDiet.Herbivore),
                new Animal(AnimalSize.Large, AnimalDiet.Herbivore),
                new Animal(AnimalSize.Small, AnimalDiet.Herbivore)
            };

            actual = sorter.SortAnimalsBySize(actual);

            int size = 0;

            foreach (Animal animal in actual) {
                Console.WriteLine(animal.Size);
                int animalSize = (int)animal.Size;
                Assert.IsTrue(animalSize >= size);
                size = animalSize;
            }
        }

        [TestMethod]
        public void SortWagonsByAnimalDiet_Unsorted_DifferentDiet() {
            List<Wagon> wagons = new List<Wagon> {
                new Wagon(),
                new Wagon(),
                new Wagon()
            };

            wagons[1].AddAnimal(new Animal(AnimalSize.Large, AnimalDiet.Carnivore));
            wagons[2].AddAnimal(new Animal(AnimalSize.Small, AnimalDiet.Carnivore));

            wagons = sorter.SortWagonsByAnimalDiet(wagons);


            
        }
    }
}
