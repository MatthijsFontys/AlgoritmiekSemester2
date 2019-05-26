using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    class WeightDivider {

        private Ship ship;
        private List<IContainer> containers;

        public WeightDivider(Ship ship, List<IContainer> containers) {
            this.ship = ship;
            this.containers = containers;
        }

        public void DivideStart() {
            DivideContainerType<ValuableContainer>();
            AddMinimumContainers();
            DivideContainerType<CooledContainer>();
        }

        public void DivideRest() {
            DivideContainerType<RegularContainer>();
        }


        private void DivideContainerType<T>() where T : IContainer {
            List<IContainer> containers = ContainerHelper.GetContainersFromType<T>(this.containers);
            foreach (IContainer container in containers)
                AddToUnplacedContainers(ship.GetLightestSide(), container);
        }


        private bool DoSidesHaveMinimumContainers() {
            foreach (Side side in ship.Sides) {
                if (side.UnplacedContainers.Count < GetMinimumContainersForSide(side))
                    return false;
            }
            return true;
        }

        private void AddMinimumContainers() {
            while (!DoSidesHaveMinimumContainers()) {
                foreach (Side side in ship.Sides) {
                    if (side.UnplacedContainers.Count < GetMinimumContainersForSide(side)) {
                        IContainer container = ContainerHelper.GetLightestContainerFromType<RegularContainer>(containers);
                        if (container == null)
                            container = ContainerHelper.GetLightestContainerFromType<CooledContainer>(containers);
                        AddToUnplacedContainers(side, container);
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


        private void AddToUnplacedContainers(Side side, IContainer container) {
            side.AddToUnplacedContainers(container);
            if (!containers.Remove(container))
                throw new ArgumentException("Container is not in container list", "container");
        }
    }
}
