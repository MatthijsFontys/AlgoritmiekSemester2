using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class LoadStrategy : ILoadStrategy {

        private Ship ship;
        private List<IShipContainer> containers;

        public void DivideContainers(List<IShipContainer> containers, Ship ship) {
            this.ship = ship;
            this.containers = containers;
            DivideWeightBetweenSides();
            foreach (Side side in ship.Sides) {
                PlaceCooledForSide(side);
                PlaceValuableForSide(side);
                PlaceRegualarForSide(side);
            }
        }

        // Step 1
        private void DivideWeightBetweenSides() {
            SortContainersByTypeThenByWeightDescending(containers);
            foreach (IShipContainer container in containers)
                ship.GetLightestSide().AddToUnplacedContainers(container);
        }

        // Step 2
        private void PlaceCooledForSide(Side side) {
            for (int n = side.Width -1 ; n >= 0; n--) {
                Staple staple = side.GetStapleFromCoordinates(GetXPosNSpotsFromEdge(n, side), side.Length);
                FillCooledStaple(side.UnplacedContainers, side, staple.X, staple.Y);
            }
        }

        //step 2.5
        private void FillCooledStaple(IEnumerable<IShipContainer> containers, Side side, int x, int y) {
            Staple staple = side.GetStapleFromCoordinates(x, y);
            if (staple.Containers.Count == 0)
                ship.TryAddContainer(GetHeaviestContainerFromType<CooledContainer>(containers), x, y);
            while (ship.TryAddContainer(GetLightestContainerFromType<CooledContainer>(containers), x, y));
        }

        // Step 3
        private void PlaceValuableForSide(Side side) {
            int n = 0;
            int y = 1;
            List<IShipContainer> valuableContainers = GetContainersFromType<ValuableContainer>(side.UnplacedContainers);
            foreach (IShipContainer container in valuableContainers) {
                int x = GetXPosNSpotsFromEdge(n, side);
                Staple staple = side.GetStapleFromCoordinates(x, y);
                FillValuableStapleToMinHeight(side.UnplacedContainers, side, x, y);
                if (y + 1 > ship.Length) {
                    n++;
                    y = 1;
                }
                else
                    y++;
            }
        }

        // Step 3.5
        private void FillValuableStapleToMinHeight(IEnumerable<IShipContainer> containers, Side side, int x, int y) {
            Staple staple = side.GetStapleFromCoordinates(x, y);
            IShipContainer valuableContainer = GetLightestContainerFromType<ValuableContainer>(containers);
            ship.TryAddContainer(valuableContainer, x, y);
            while (staple.Containers.Count() < GetMinimumValuableHeight(staple)) {
                if (staple.Containers.Count() == 1) {
                    ship.TryAddContainer(GetHeaviestContainerFromType<RegularContainer>(containers), x, y);
                    continue;
                }
                if (!ship.TryAddContainer(GetLightestContainerFromType<RegularContainer>(containers),x ,y))
                     throw new InvalidOperationException("Can't make the staple high enough for the valuable");
            }
        }

        // Step 4
        private void PlaceRegualarForSide(Side side) {
            IEnumerable<IShipContainer> regularContainers = GetContainersFromType<RegularContainer>(side.UnplacedContainers);
            regularContainers = SortContainersByTypeThenByWeightDescending(regularContainers);
            foreach (IShipContainer container in regularContainers) {
                AddContainerToLightestStaple(container, side);
            }
            if (side.UnplacedContainers.Count > 0)
                throw new Exception("Can't place all containers on the ship");
        }

        // Step 4.5
        private void AddContainerToLightestStaple(IShipContainer container, Side side) {
            side.OrderStaplesByWeight();
            foreach (Staple staple in side.Staples) {
                if (ship.TryAddContainer(container, staple.X, staple.Y))
                    break;
            }
        }

        #region helpers
        /// <summary>
        /// Because the start X position is different for each side
        /// </summary>
        /// <param name="n">Number of spots from the edge</param>
        private int GetXPosNSpotsFromEdge(int n, Side side) {
            if (n + 1 >= side.StartX) // left
                return n + 1;
            else
                return ship.Width - n; // right
        }

        private int GetMinimumValuableHeight(Staple staple) {
            if (staple.X > ship.Width / 2)
                return ship.Width - staple.X + 1; // closer to right edge
            else
                return staple.X; // closer to left edge
        }

        private IEnumerable<IShipContainer> SortContainersByTypeThenByWeightDescending(IEnumerable<IShipContainer> containers) {
           return containers.OrderBy(x => x is ValuableContainer)
                .ThenBy(x => x is CooledContainer)
                .ThenByDescending(c => c.Weight).ToList();
        }
        #endregion

        #region generic
        private IShipContainer GetHeaviestContainerFromType<T>(IEnumerable<IShipContainer> containers) where T : IShipContainer {
            List<IShipContainer> containersOfType = containers.Where(c => c is T).ToList();
            double maxWeight = (containersOfType.Count() > 0) ? containersOfType.Max(c => c.Weight) : -1;
                return containersOfType.FirstOrDefault(x => x.Weight == maxWeight);
        }

        private IShipContainer GetLightestContainerFromType<T>(IEnumerable<IShipContainer> containers) where T : IShipContainer {
            List<IShipContainer> containersOfType = containers.Where(c => c is T).ToList();
            double minWeight = (containersOfType.Count() > 0) ? containersOfType.Min(c => c.Weight) : -1;
            return containersOfType.FirstOrDefault(x => x.Weight == minWeight);
        }

        private List<IShipContainer> GetContainersFromType<T>(IEnumerable<IShipContainer> containers) where T : IShipContainer {
            return containers.Where(c => c is T).ToList();
        }
        #endregion

    }
}
