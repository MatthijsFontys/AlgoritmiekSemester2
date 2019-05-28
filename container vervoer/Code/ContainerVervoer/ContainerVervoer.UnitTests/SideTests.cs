using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.UnitTests {
    [TestClass]
    public class SideTests {
        [TestMethod]
        public void InitStacks_Success() {
            Ship ship = new Ship(7, 10);
            List<Side> sides = ship.Sides.ToList();
            int expectedStacksLeftAndRight = 3 * 10;
            int expectedStacksMiddle = 1 * 10;

            int actualStacksMiddle = sides.First(s => s.StartX == 4).Stacks.Count();
            int actualStacksLeft = sides.First(s => s.StartX == 1).Stacks.Count();
            int actualStacksRight = sides.First(s => s.StartX == 5).Stacks.Count();
            Assert.AreEqual(expectedStacksLeftAndRight, actualStacksLeft);
            Assert.AreEqual(expectedStacksLeftAndRight, actualStacksRight);
            Assert.AreEqual(expectedStacksMiddle, actualStacksMiddle);
        }

        [TestMethod]
        public void OrderStacksByWeight_Success() {
            Ship ship = new Ship(4, 5);
            Side left = ship.Sides.First(s => s.StartX == 1);
            ILoadStrategy strategy = new LoadStrategy();
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateValuableContainers(30, 6),
                ContainerFactory.CreateValuableContainers(10, 5),
                ContainerFactory.CreateRegularContainers(20, 15),
                ContainerFactory.CreateCooledContainers(4, 10)
            );

            left.OrderStacksByWeight();

            for (int i = 1; i < left.Stacks.Count; i++)
                Assert.IsTrue(left.Stacks.ToList()[i].GetTotalWeight() >= left.Stacks.ToList()[i - 1].GetTotalWeight());
        }

        [TestMethod]
        public void TryAddContainer_SideFull_ShouldNotAdd() {
            Ship ship = new Ship(2, 2);
            Side side = new Side(1, 2, 1);
            List<IContainer> containers = ContainerFactory.CreateRegularContainers(20, 7);
            foreach (IContainer container in containers) {
                side.TryAddContainer(container, 1, 1);
                side.TryAddContainer(container, 1, 2);
            }
            IContainer failContainer = ContainerFactory.CreateRegularContainers(4).First();
            Assert.IsFalse(side.TryAddContainer(failContainer, 1, 1));
            Assert.IsFalse(side.TryAddContainer(failContainer, 1, 2));
        }

        [TestMethod]
        public void TryAddContainer_FullWithValuables_ShouldNotAdd() {
            Ship ship = new Ship(2, 2);
            Side side = new Side(1, 2, 1);
            List<IContainer> containers = ContainerFactory.CreateValuableContainers(4, 2);
            foreach (IContainer container in containers) {
                side.TryAddContainer(container, 1, 1);
                side.TryAddContainer(container, 1, 2);
            }
            IContainer failContainer = ContainerFactory.CreateValuableContainers(4).First();
            Assert.IsFalse(side.TryAddContainer(failContainer, 1, 1));
            Assert.IsFalse(side.TryAddContainer(failContainer, 1, 2));
        }

        [TestMethod]
        public void TryAddContainer_FullWithCooled_ShouldNotAdd() {
            Ship ship = new Ship(2, 2);
            Side side = new Side(1, 2, 1);
            List<IContainer> containers = ContainerFactory.CreateCooledContainers(20, ship, 7);
            foreach (IContainer container in containers) {
                side.TryAddContainer(container, 1, 2);
            }
            IContainer failContainer = ContainerFactory.CreateCooledContainers(4, ship).First();
            Assert.IsFalse(side.TryAddContainer(failContainer, 1, 2));
            Assert.IsFalse(side.TryAddContainer(failContainer, 1, 1));
        }

        [TestMethod]
        public void TryAddContainer_AllContainerTypes_Success() {
            Side side = new Side(2, 4, 1);
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateValuableContainers(10, 1),
                ContainerFactory.CreateRegularContainers(20, 3),
                ContainerFactory.CreateCooledContainers(4, 4, 3)
            );
            int expectedContainerCount = containers.Count;
            int actualContainerCount = 0;
            foreach (IContainer container in containers) {
                side.TryAddContainer(container, 1, 4);
            }
            side.Stacks.ToList().ForEach(s => actualContainerCount += s.Containers.Count());

            Assert.AreEqual(expectedContainerCount, actualContainerCount);
        }

        [TestMethod]
        public void GetTotalWeight_EmptySide_Success() {
            Side side = new Side(4, 4, 1);
            double actualWeight = side.GetTotalWeight();
            Assert.AreEqual(0, actualWeight);
        }

        [TestMethod]
        public void GetTotalWeight_OneContainer_Success() {
            IContainer container = ContainerFactory.CreateValuableContainers(20).First();
            double expectedWeight = container.Weight;
            Side side = new Side(4, 4, 1);
            side.TryAddContainer(container, 1, 1);
            double actualWeight = side.GetTotalWeight();
            Assert.AreEqual(expectedWeight, actualWeight);
        }

        [TestMethod]
        public void GetStackFromCoordinates_InvalidCoordinates_ThrowsError() {
            Side side = new Side(4, 4, 1);
            Assert.ThrowsException<ArgumentException>(() => side.GetStackFromCoordinates(5, 10));
        }

        [TestMethod]
        public void GetStackFromCoordinates_ValidCoordinates_Success() {
            Side side = new Side(4, 4, 1);
            for (int x = 1; x <= side.Width; x++) {
                for (int y = 1; y <= side.Length; y++) {
                    Stack stack = side.GetStackFromCoordinates(x, y);
                    Assert.IsNotNull(stack);
                }
            }
        }
    }
}