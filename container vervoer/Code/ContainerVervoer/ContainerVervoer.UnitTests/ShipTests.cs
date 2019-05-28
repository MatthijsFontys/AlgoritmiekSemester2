using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.UnitTests {
    [TestClass]
    public class ShipTests {

        [TestMethod]
        public void CreateSides_EvenWidth_Create2Sides_Success() {
            int expectedSides = 2;
            Ship ship = new Ship(4, 6);
            int actualSides = ship.Sides.Count();

            Assert.AreEqual(actualSides, expectedSides);
        }

        [TestMethod]
        public void CreateSides_OddWidth_Create3Sides_Success() {
            int expectedSides = 3;
            Ship ship = new Ship(5, 7);
            int actualSides = ship.Sides.Count();

            Assert.AreEqual(actualSides, expectedSides);
        }

        [TestMethod]
        public void GetLightestSide_LightestMiddle_ReturnLeft_Success() {
            double expectedWeight = 29.5;
            Ship ship = new Ship(3, 1);

            List<Side> sides = ship.Sides.ToList();
            sides.Where(s => s.StartX == 1).First().AddToUnplacedContainers(ContainerFactory.CreateRegularContainers(29.5).First());
            sides.Where(s => s.StartX == 3).First().AddToUnplacedContainers(ContainerFactory.CreateRegularContainers(30).First());
            double actualWeight = ship.GetLightestSide().UnplacedContainers.Sum(s => s.Weight);

            Assert.AreEqual(expectedWeight, actualWeight);
        }

        [TestMethod]
        public void GetLightestSide_NoMiddle_ReturnRight_Success() {
            double expectedWeight = 30;
            Ship ship = new Ship(4, 1);

            List<Side> sides = ship.Sides.ToList();
            foreach (IContainer container in ContainerFactory.CreateRegularContainers(4.4, 10))
                sides.Where(s => s.StartX == 1).First().AddToUnplacedContainers(container);
            sides.Where(s => s.StartX == 3).First().AddToUnplacedContainers(ContainerFactory.CreateRegularContainers(30).First());
            double actualWeight = ship.GetLightestSide().UnplacedContainers.Sum(s => s.Weight);

            Assert.AreEqual(expectedWeight, actualWeight);
        }

        [TestMethod]
        public void TryAddContainer_InvalidXCoordinate_ThrowError() {
            Ship ship = new Ship(5, 10);
            IContainer container = ContainerFactory.CreateRegularContainers(30).First();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ship.TryAddContainer(container, 6, 5));
        }

        [TestMethod]
        public void TryAddContainer_InvalidYCoordinate_ThrowError() {
            Ship ship = new Ship(5, 6);
            IContainer container = ContainerFactory.CreateRegularContainers(30).First();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ship.TryAddContainer(container, 5, 11));
        }

        [TestMethod]
        public void TryAddContainer_StackIsFullStack_DontAdd() {
            bool expectedResult = false;
            int actualContainerCount = 0;

            Ship ship = new Ship(2, 1);
            int expectedContainerCount = 5;
            List<IContainer> containers = ContainerFactory.CreateRegularContainers(30, 5);
            foreach (IContainer container in containers)
                ship.TryAddContainer(container, 1,  1);

            bool actualResult = ship.TryAddContainer(new RegularContainer(4), 1, 1);

            foreach (Side side in ship.Sides)
                side.Stacks.ToList().
                    ForEach(s => actualContainerCount += s.Containers.Count());

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedContainerCount, actualContainerCount);
        }

        [TestMethod]
        public void TryAddContainer_StackNotFull_Success() {
            bool expectedResult = true;
            int actualContainerCount = 0;

            Ship ship = new Ship(2, 1);
            int expectedContainerCount = 5;
            List<IContainer> containers = ContainerFactory.CreateRegularContainers(30, 4);
            foreach (IContainer container in containers)
                ship.TryAddContainer(container, 1, 1);

            bool actualResult = ship.TryAddContainer(new RegularContainer(4), 1, 1);

            foreach (Side side in ship.Sides) {
                side.Stacks.ToList().
                    ForEach(s => actualContainerCount += s.Containers.Count());
            }

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedContainerCount, actualContainerCount);
        }

        [TestMethod]
        public void GetWeightDifferenceInPercent_EmptyShip_Success() {
            double expected = 0;
            Ship ship = new Ship(4, 4);
            double actual = ship.GetWeightDifferenceInPercent();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWeightDifferenceInPercent_OddLengthShip_Success() {
            double expected = (double)(50 - 30) / (50 + 20 + 30) * 100;
            Ship ship = new Ship(3, 1);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(50).First(), 1, 1);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(20).First(), 2, 1);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(30).First(), 3, 1);
            double actual = ship.GetWeightDifferenceInPercent();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWeightDifferenceInPercent_EvenLength_DoubleResult_Success() {
            double expected = 33 + (double)1 / 3;
            Ship ship = new Ship(4, 4);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(3 + (double)1 / 3).First(), 1, 1);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(6 + (double)2 / 3).First(), 4, 4);
            double actual = ship.GetWeightDifferenceInPercent();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_SidesNotBalanced_ThrowsError() {
            Ship ship = new Ship(4, 4);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(2.1).First(), 1, 1);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(8).First(), 4, 4);
            
            Assert.ThrowsException<Exception>( () => ship.Validate());
        }

        [TestMethod]
        public void Validate_SidesAreBalanced_Success() {
            Ship ship = new Ship(4, 4);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(29).First(), 1, 1);
            ship.TryAddContainer(ContainerFactory.CreateRegularContainers(20).First(), 4, 4);
            Assert.IsTrue(ship.Validate());
        }

    }
}
