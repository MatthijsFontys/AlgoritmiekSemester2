using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    class WeightDivider {

        private Ship ship;

        public WeightDivider(Ship ship) {
            this.ship = ship;
        }

        public void DivideManditoryPositions(List<IContainer> containers) {
            DivideContainerType<ValuableContainer>(containers);
            AddMinimumContainers(containers);
        }

        public void DivideLeftovers(List<IContainer> containers) {
            DivideContainerType<CooledContainer>(containers);
            DivideContainerType<RegularContainer>(containers);
        }

        private void DivideContainerType<T>(List<IContainer> containersToDivide) where T : IContainer {
            List<IContainer> containers = ContainerHelper.GetContainersFromType<T>(containersToDivide);
            foreach (IContainer container in containers)
                AddToUnplacedContainers(ship.GetLightestSide(), container, containersToDivide);
        }

        private bool DoSidesHaveMinimumContainers() {
            foreach (Side side in ship.Sides) {
                if (side.UnplacedContainers.Count < GetMinimumContainersForSide(side))
                    return false;
            }
            return true;
        }

        private void AddMinimumContainers(List<IContainer> containers) {
            while (!DoSidesHaveMinimumContainers()) {
                foreach (Side side in ship.Sides) {
                    if (side.UnplacedContainers.Count < GetMinimumContainersForSide(side)) {
                        IContainer container = ContainerHelper.GetLightestContainerFromType<RegularContainer>(containers);
                        if (container == null)
                            container = ContainerHelper.GetLightestContainerFromType<CooledContainer>(containers);
                        AddToUnplacedContainers(side, container, containers);
                    }
                }
            }
        }

        private int GetMinimumContainersForSide(Side side) {
            double minimumContainers = 0;
            int valuableCount = ContainerHelper.GetContainersFromType<ValuableContainer>(side.UnplacedContainers).Count;
            double valuableRows = (double) valuableCount / side.Length;
            for (int i = 0; i < valuableRows; i++) {
                double factor = (valuableRows - i > 1) ? 1 : valuableRows - i;
                minimumContainers += side.Length * i * factor;
            }
            return Convert.ToInt32(Math.Ceiling(minimumContainers)) + valuableCount;
        }

        private void AddToUnplacedContainers(Side side, IContainer container, List<IContainer> containers) {
            side.AddToUnplacedContainers(container);
            if (!containers.Remove(container))
                throw new ArgumentException("Container is not in container list", "container");
        }
    }
}
