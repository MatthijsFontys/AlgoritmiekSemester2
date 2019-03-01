using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System.Collections.Generic;

namespace CircustreinCode.Test.AlgorithmTests {
    [TestClass]
    public class AnimalDividerTests {
        AnimalDivider divider;
        private void Setup(List<IAnimal> animals) {
            divider = new AnimalDivider(Builder.CreateTrain(), animals);
        }

        [TestMethod]
         public void DivideAnimalsCarnivoresOnly_Succes() {

            int expected = 3;
            int actual;

            Setup(
                new List<IAnimal>
                {
                    Builder.CreateCarnivore(AnimalSize.Large),
                    Builder.CreateCarnivore(AnimalSize.Medium),
                    Builder.CreateCarnivore(AnimalSize.Small),
                });

            divider.DivideAnimals();
            actual = divider.train.WagonCount;
            Assert.AreEqual(expected, actual);       
        }

        [TestMethod]
        public void DivideAnimalsCarnivoreAndHerbivore_Succes() {

            int expected = 3;
            int actual;

            Setup(
                new List<IAnimal>
                {
                    Builder.CreateCarnivore(AnimalSize.Large),
                    Builder.CreateCarnivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateCarnivore(AnimalSize.Small),
                });

            divider.DivideAnimals();
            actual = divider.train.WagonCount;
            Assert.AreEqual(expected, actual);

        }

        // My edge cases
        [TestMethod]
        public void EdgeCase1() {

            int expected = 2;
            int actual;

            Setup(
                new List<IAnimal>
                {
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateCarnivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small)
                });

            divider.DivideAnimals();
            actual = divider.train.WagonCount;
            Assert.AreEqual(expected, actual);
        }

        // JanTestCases
        [TestMethod]
        public void Jan1() {

            int expected = 2;
            int actual;

            Setup(
                new List<IAnimal>
                {
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Large),
                });

            divider.DivideAnimals();
            actual = divider.train.WagonCount;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Jan2() {

            int expected = 6;
            int actual;

            Setup(
                new List<IAnimal>
                {
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateCarnivore(AnimalSize.Small),
                    Builder.CreateCarnivore(AnimalSize.Medium),
                    Builder.CreateCarnivore(AnimalSize.Medium),
                    Builder.CreateCarnivore(AnimalSize.Medium),
                    Builder.CreateCarnivore(AnimalSize.Large),
                    Builder.CreateCarnivore(AnimalSize.Large),
                });

            divider.DivideAnimals();
            actual = divider.train.WagonCount;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Jan3() {

            int expected = 8;
            int actual;

            Setup(
                new List<IAnimal>
                {
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Large),

                    Builder.CreateHerbivore(AnimalSize.Small),
                    Builder.CreateHerbivore(AnimalSize.Small),

                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),

                    Builder.CreateCarnivore(AnimalSize.Large),
                    Builder.CreateCarnivore(AnimalSize.Large),
                });

            divider.DivideAnimals();
            actual = divider.train.WagonCount;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Jan4() {

            int expected = 2;
            int actual;

            Setup(
                new List<IAnimal>
                {
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Medium),
                    Builder.CreateHerbivore(AnimalSize.Large),
                    Builder.CreateHerbivore(AnimalSize.Large),
                });

            divider.DivideAnimals();
            actual = divider.train.WagonCount;
            Assert.AreEqual(expected, actual);
        }
    }
}
