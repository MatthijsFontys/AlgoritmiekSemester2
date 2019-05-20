using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class LoadStrategy : ILoadStrategy {

        private Ship ship;
        private List<IContainer> containers;

        public void DivideContainers(List<IContainer> containers, Ship ship) {
            this.ship = ship;
            this.containers = containers;
            DivideWeightBetweenSides();
            foreach (Side side in ship.Sides) {
                PlaceCooledForSide(side);
                PlaceValuableForSide(side);
                PlaceRegualarForSide(side);
            }

            if (!ship.Validate())
                throw new Exception("Ship is not valid");
        }

        // Step 1
        private void DivideWeightBetweenSides() {
            SortContainersByTypeThenByWeightDescending(containers);
            foreach (IContainer container in containers)
                ship.GetLightestSide().AddToUnplacedContainers(container);
        }

        // Step 2
        private void PlaceCooledForSide(Side side) {
            for (int n = side.Width -1 ; n >= 0; n--) {
                Stack staple = side.GetStapleFromCoordinates(GetXPosNSpotsFromEdge(n, side), side.Length);
                FillCooledStaple(side.UnplacedContainers, side, staple.X, staple.Y);
            }
        }

        //step 2.5
        private void FillCooledStaple(IEnumerable<IContainer> containers, Side side, int x, int y) {
            Stack staple = side.GetStapleFromCoordinates(x, y);
            if (staple.Containers.Count == 0)
                ship.TryAddContainer(GetHeaviestContainerFromType<CooledContainer>(containers), x, y);
            while (ship.TryAddContainer(GetLightestContainerFromType<CooledContainer>(containers), x, y));
        }

        // Step 3
        private void PlaceValuableForSide(Side side) {
            int n = 0;
            int y = 1;
            List<IContainer> valuableContainers = GetContainersFromType<ValuableContainer>(side.UnplacedContainers);
            foreach (IContainer container in valuableContainers) {
                int x = GetXPosNSpotsFromEdge(n, side);
                Stack staple = side.GetStapleFromCoordinates(x, y);
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
        private void FillValuableStapleToMinHeight(IEnumerable<IContainer> containers, Side side, int x, int y) {
            Stack staple = side.GetStapleFromCoordinates(x, y);
            IContainer valuableContainer = GetLightestContainerFromType<ValuableContainer>(containers);
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
            IEnumerable<IContainer> regularContainers = GetContainersFromType<RegularContainer>(side.UnplacedContainers);
            regularContainers = SortContainersByTypeThenByWeightDescending(regularContainers);
            foreach (IContainer container in regularContainers) {
                AddContainerToLightestStaple(container, side);
            }
            if (side.UnplacedContainers.Count > 0)
                throw new Exception("Can't place all containers on the ship");
        }

        // Step 4.5
        private void AddContainerToLightestStaple(IContainer container, Side side) {
            side.OrderStaplesByWeight();
            foreach (Stack staple in side.Stacks) {
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

        private int GetMinimumValuableHeight(Stack staple) {
            if (staple.X > ship.Width / 2)
                return ship.Width - staple.X + 1; // closer to right edge
            else
                return staple.X; // closer to left edge
        }

        private IEnumerable<IContainer> SortContainersByTypeThenByWeightDescending(IEnumerable<IContainer> containers) {
           return containers.OrderBy(x => x is ValuableContainer)
                .ThenBy(x => x is CooledContainer)
                .ThenByDescending(c => c.Weight).ToList();
        }
        #endregion

        #region generic
        private IContainer GetHeaviestContainerFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c => c is T).ToList();
            double maxWeight = (containersOfType.Count() > 0) ? containersOfType.Max(c => c.Weight) : -1;
                return containersOfType.FirstOrDefault(x => x.Weight == maxWeight);
        }

        private IContainer GetLightestContainerFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c => c is T).ToList();
            double minWeight = (containersOfType.Count() > 0) ? containersOfType.Min(c => c.Weight) : -1;
            return containersOfType.FirstOrDefault(x => x.Weight == minWeight);
        }

        private List<IContainer> GetContainersFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            return containers.Where(c => c is T).ToList();
        }
        #endregion

    }
}
