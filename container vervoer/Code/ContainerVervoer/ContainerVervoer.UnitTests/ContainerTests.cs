using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.UnitTests {
    [TestClass]
    public class ContainerTests {

        [TestMethod]
        public void SetZ_WrongStack_ThrowsException() {
            Stack stack = new Stack(1, 1);
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateCooledContainers(30, 1),
                ContainerFactory.CreateValuableContainers(30),
                ContainerFactory.CreateRegularContainers(30)
                );

            foreach (IContainer container in containers) {
                try {
                    container.SetZ(stack, 1);
                    Assert.Fail();
                }

                catch(ArgumentException ex) {
                    Assert.IsTrue(true);
                }
            }
        }

        [TestMethod]
        public void SetZ_TooHighZ_Fails() {
            Stack stack = new Stack(1, 1);
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateCooledContainers(29, 1, 1),
                ContainerFactory.CreateRegularContainers(30, 1));
            foreach (IContainer container in containers) {
                stack.TryAddContainer(container);
            }

            int expectedZCooled = containers[0].Z;
            int expectedZRegular = containers[1].Z;

            containers[0].SetZ(stack, 5);
            containers[1].SetZ(stack, 31);

            int actualZCooled = containers[0].Z;
            int actualZRegular = containers[1].Z;

            Assert.AreEqual(expectedZCooled, actualZCooled);
            Assert.AreEqual(expectedZRegular, actualZRegular);
        }

        [TestMethod]
        public void ToStringOverride_FullInteger_Success() {
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateCooledContainers(4, 1, 1),
                ContainerFactory.CreateRegularContainers(30, 1),
                ContainerFactory.CreateValuableContainers(20, 1));

            Assert.AreEqual("Cooled 4", containers[0].ToString(), false, System.Globalization.CultureInfo.CurrentCulture);
            Assert.AreEqual("Regular 30", containers[1].ToString(), false, System.Globalization.CultureInfo.CurrentCulture);
            Assert.AreEqual("Valuable 20", containers[2].ToString(), false, System.Globalization.CultureInfo.CurrentCulture);
        }

        [TestMethod]
        public void ToStringOverride_Double_Success() {
            List<IContainer> containers = ContainerFactory.ConcatContainerTypes(
            ContainerFactory.CreateCooledContainers(4.141592, 1, 1),
            ContainerFactory.CreateRegularContainers(30.1, 1),
            ContainerFactory.CreateValuableContainers(20.36, 1));

            Assert.AreEqual("Cooled 4,14", containers[0].ToString(), false, System.Globalization.CultureInfo.CurrentCulture);
            Assert.AreEqual("Regular 30,1", containers[1].ToString(), false, System.Globalization.CultureInfo.CurrentCulture);
            Assert.AreEqual("Valuable 20,36", containers[2].ToString(), false, System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
