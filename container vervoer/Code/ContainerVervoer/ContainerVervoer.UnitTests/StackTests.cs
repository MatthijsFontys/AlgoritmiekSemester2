using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.UnitTests {
    [TestClass]
    public class StackTests {

        [TestMethod]
        public void TryAddContainer_FullStack_ShouldNotAdd() {
            Stack stack = new Stack(1, 1);
            List<IContainer> containers = ContainerFactory.CreateRegularContainers(20, 7);
            foreach (IContainer container in containers)
                stack.TryAddContainer(container);

            IContainer failContainer = ContainerFactory.CreateRegularContainers(4).First();
            Assert.IsFalse(stack.TryAddContainer(failContainer));
        }

        [TestMethod]
        public void TryAddContainer_FullValuableStack_ShouldNotAddValuable() {
            Stack stack = new Stack(1, 1);
            List<IContainer> containers = ContainerFactory.CreateValuableContainers(4, 2);
            stack.TryAddContainer(containers[0]);
            Assert.IsFalse(stack.TryAddContainer(containers[1]));
        }

        [TestMethod]
        public void TryAddContainer_FullWrongYForCooled_ShouldNotAddCooled() {
            Stack stack = new Stack(1, 1);
            IContainer container = ContainerFactory.CreateCooledContainers(4, 2, 1).First();
            Assert.IsFalse(stack.TryAddContainer(container));
        }

        [TestMethod]
        public void TryAddContainer_AddAllContainerTypes_Success() {
            Stack stack = new Stack(1, 1);
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateCooledContainers(30, 1, 1),
                ContainerFactory.CreateValuableContainers(30, 1),
                ContainerFactory.CreateRegularContainers(30, 1));
            int expectedContainerCount = containers.Count;
            foreach (IContainer container in containers) {
                stack.TryAddContainer(container);
            }
            int actualContainerCount = stack.Containers.Count();
            Assert.AreEqual(expectedContainerCount, actualContainerCount);
        }

        [TestMethod]
        public void OptimizeStackOrder_Success() {
            Stack stack = new Stack(1, 1);
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateCooledContainers(29, 1, 1),
                ContainerFactory.CreateValuableContainers(30, 1), // Valuable on top == index 1
                ContainerFactory.CreateRegularContainers(30, 1), // Heaviest first == index 2
                ContainerFactory.CreateRegularContainers(15, 1));
            foreach (IContainer container in containers) {
                stack.TryAddContainer(container);
            }
            Assert.IsTrue(stack.Containers.ToList()[0] == containers[2]);
            Assert.IsTrue(stack.Containers.ToList()[3] == containers[1]);
        }
    }
}
