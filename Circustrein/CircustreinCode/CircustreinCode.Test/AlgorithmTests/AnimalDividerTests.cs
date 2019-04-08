using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System.Collections.Generic;

namespace CircustreinCode.Test.AlgorithmTests {
    [TestClass]
    public class AnimalDividerTests {
        AnimalDivider divider;
        private void Setup(List<IAnimal> animals) {
            divider = new AnimalDivider(Factory.CreateTrain(), animals);
        }



        // My edge cases

        /*
        c1 h3 h3 h3 h5 h1 h1 h1 h1 h1
        goed = c1 h3 h3 h3 | h5 h1 h1 h1 h1 h1
        fout = c1 h5 h3 | h3 h3 h1 h1 h1 h1 | h1
        */
        [TestMethod]
        public void FillSmallCarnivoreWithMediumHerbivoreFirst() {

            int expected = 2;
            int actual;

            Setup(
                HordeCreator.CreateHorde(
                    new Horde('h', AnimalSize.Small, 5),
                    new Horde('h', AnimalSize.Medium, 3),
                    new Horde('h', AnimalSize.Large, 1),
                    new Horde('c', AnimalSize.Small, 1))
            );

            divider.DivideAnimals();
            actual = divider.AnimalTrain.Wagons.Count;
            Assert.AreEqual(expected, actual);
        }


        /*
         c1 h3 h3 h5 h5 h1 h1 
        goed = c1 h5 h3 | h5 h3 h1 h1
        fout = c1 h3 h3 | h5 h5 | h1 h1
        */

        [TestMethod]
        public void FillSmallCarnivoreWithBigHerbivoreFirst() {
            int expected = 2;
            int actual;

            Setup(
                HordeCreator.CreateHorde(
                    new Horde('h', AnimalSize.Small, 2),
                    new Horde('h', AnimalSize.Medium, 2),
                    new Horde('h', AnimalSize.Large, 2),
                    new Horde('c', AnimalSize.Small, 1))
            );

            divider.DivideAnimals();
            actual = divider.AnimalTrain.Wagons.Count;
            Assert.AreEqual(expected, actual);
        }

        /*
        (H1 x10) (H3 X2) H5 C3 C1
        Goed = C3 H5 | H3 H3 C1 | H1x 10
        Fout = C3 | C1 H5 H3 | H1 x 10 | H3
        */
        [TestMethod]
        public void FillMediumCarnivoreBeforeSmallCarnivore() {
            int expected = 3;
            int actual;

            Setup(
                HordeCreator.CreateHorde(
                    new Horde('h', AnimalSize.Small, 10),
                    new Horde('h', AnimalSize.Medium, 2),
                    new Horde('h', AnimalSize.Large, 1),
                    new Horde('c', AnimalSize.Small, 1),
                    new Horde('c', AnimalSize.Medium, 1))
            );

            divider.DivideAnimals();
            actual = divider.AnimalTrain.Wagons.Count;
            Assert.AreEqual(expected, actual);
        }

        // ################ Jan TestCases (slack) ######################

        // Test case 1
        [TestMethod]
        public void HerbivoresOnly2Wagons() {

            int expected = 2;
            int actual;

            Setup(
                    HordeCreator.CreateHorde(
                    new Horde('h', AnimalSize.Small, 5),
                    new Horde('h', AnimalSize.Medium, 3),
                    new Horde('h', AnimalSize.Large, 1))
                );

            divider.DivideAnimals();
            actual = divider.AnimalTrain.Wagons.Count;
            Assert.AreEqual(expected, actual);

        }

        // Test case 2
        [TestMethod]
        public void BigHerbivoresAndAllCarnivores_6Wagons() {

            int expected = 6;
            int actual;

            Setup(
                HordeCreator.CreateHorde(
                    new Horde('h', AnimalSize.Large, 3),
                    new Horde('c', AnimalSize.Small, 1),
                    new Horde('c', AnimalSize.Medium, 3),
                    new Horde('c', AnimalSize.Large, 2))
                );

            divider.DivideAnimals();
            actual = divider.AnimalTrain.Wagons.Count;
            Assert.AreEqual(expected, actual);
        }

        // Test case 3
        [TestMethod]
        public void AllHerbivoresTimes5_AllCarnivoresTimes2_8Wagons() {

            int expected = 8;
            int actual;

            Setup(
                    HordeCreator.CreateHorde(
                    new Horde('h', AnimalSize.Small, 5),
                    new Horde('h', AnimalSize.Medium, 5),
                    new Horde('h', AnimalSize.Large, 5),
                    new Horde('c', AnimalSize.Small, 2),
                    new Horde('c', AnimalSize.Medium, 2),
                    new Horde('c', AnimalSize.Large, 2))
                );

            divider.DivideAnimals();
            actual = divider.AnimalTrain.Wagons.Count;
            Assert.AreEqual(expected, actual);
        }

        // Test case 4
        [TestMethod]
        public void BigAndMediumHerbivores_2Wagons() {

            int expected = 2;
            int actual;

            Setup(
                HordeCreator.CreateHorde(
                    new Horde('h', AnimalSize.Medium, 3),
                    new Horde('h', AnimalSize.Large, 2))
            );

            divider.DivideAnimals();
            actual = divider.AnimalTrain.Wagons.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
