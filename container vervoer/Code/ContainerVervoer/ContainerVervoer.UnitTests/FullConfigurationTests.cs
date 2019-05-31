using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerVervoer.UnitTests {

    /// <summary>
    /// This class tests the full algorithm
    /// The classes WeightDivider and LoadStrategy will be tested
    /// </summary>

    [TestClass]
    public class FullConfigurationTests {
        LoadStrategy loadStrategy;
        List<IContainer> containers;

        [TestInitialize]
        public void Setup() {
            loadStrategy = new LoadStrategy();
            containers = new List<IContainer>();
        }


        [TestMethod]
        // https://i872272.venus.fhict.nl/ContainerVisualizer/index.html?length=4&width=5&stacks=2,2,2,2/12,12,12,12/112,112,112,112/12,12,12,12/2,2,2,2
        public void FullShipWithReachableCooled() {
            Ship ship = new Ship(5, 4);
            containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateValuableContainers(30, 20),
                ContainerFactory.CreateRegularContainers(30, 16)
                );
            loadStrategy.DivideContainers(containers, ship);

            Assert.IsTrue(ship.Validate());
        }

        [TestMethod]
        // https://i872272.venus.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=1111111,111111/1111111,111111
        public void FillUpWeightEntireBoat() {
            Ship ship = new Ship(2, 2);
            containers = ContainerFactory.ConcatContainerTypes(
                ContainerFactory.CreateRegularContainers(30, 16),
                ContainerFactory.CreateRegularContainers(20, 4),
                ContainerFactory.CreateRegularContainers(8, 2),
                ContainerFactory.CreateRegularContainers(6, 2),
                ContainerFactory.CreateRegularContainers(4, 2)
                );
            loadStrategy.DivideContainers(containers, ship);

            Assert.IsTrue(ship.Validate());
        }

        [TestMethod]
        // https://i872272.venus.fhict.nl/ContainerVisualizer/index.html?length=4&width=5&stacks=2,2,2,2/,,,12/,,,33333333/,,,/2,2,2,2
        public void AllContainerTypes() {
            Ship ship = new Ship(5, 4);
            containers = ContainerFactory.ConcatContainerTypes(
             ContainerFactory.CreateValuableContainers(4, 9),
             ContainerFactory.CreateCooledContainers(4, 4, 8),
             ContainerFactory.CreateRegularContainers(4, 1)
             );
            loadStrategy.DivideContainers(containers, ship);
            Assert.IsTrue(ship.Validate());
        }

    }
}
