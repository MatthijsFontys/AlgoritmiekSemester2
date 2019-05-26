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
                PlaceValuableForSide(side);
                PlaceCooledForSide(side);
                PlaceRegularForSide(side);
            }

            if (!ship.Validate())
                throw new Exception("Ship is not valid");
        }

        // Step 1
        private void DivideWeightBetweenSides() {
            WeightDivider wd = new WeightDivider(ship, containers);
            wd.DivideStart();
            FillMiddleIfExists();
            wd.DivideRest();

            //SortContainersByTypeThenByWeightDescending(containers);
            //foreach (IContainer container in containers)
            //    ship.GetLightestSide().AddToUnplacedContainers(container);
        }

        private void FillMiddleIfExists() {
            if (ship.Sides.Count == 3) {
                int middleStartX = Convert.ToInt32(Math.Ceiling((double)ship.Width / 2));
                Side middle = ship.Sides.First(s => s.StartX == middleStartX);
                SortContainersByMedian(containers);
                for (int i = 0; i < containers.Count; i++) {
                    if (AddContainerToLightestStaple(containers[i], middle)) {
                        containers.Remove(containers[i]);
                        i--;
                    }
                }
            }
        }

        private void SortContainersByMedian(List<IContainer> containers) {
            List<IContainer> sorted = new List<IContainer>();
            containers.OrderBy(c => c.Weight);
            for (int i = 0; i < containers.Count; i+=2) {
                sorted.Add(containers[i]);
                int indexFromEnd = containers.Count - 1 - i;
                if (i != indexFromEnd) // The middle has not been reached
                    sorted.Add(containers[indexFromEnd]);
            }
            containers = sorted;
        }

        // Step 2
        private void PlaceCooledForSide(Side side) {
            for (int n = side.Width -1 ; n >= 0; n--) {
                Stack stack = side.GetStackFromCoordinates(GetXPositionNSpotsFromEdge(n, side), side.Length);
                FillCooledStaple(side.UnplacedContainers, side, stack.X, stack.Y);
            }
        }

        //step 2.5
        private void FillCooledStaple(IEnumerable<IContainer> containers, Side side, int x, int y) {
            Stack staple = side.GetStackFromCoordinates(x, y);
            if (staple.Containers.Count == 0)
                ship.TryAddContainer(GetHeaviestContainerFromType<CooledContainer>(containers), x, y);
            while (ship.TryAddContainer(GetLightestContainerFromType<CooledContainer>(containers), x, y));
        }

        // Step 3
        private void PlaceValuableForSide(Side side) {
            int n = 0;
            int y = ship.Length;
            List<IContainer> valuableContainers = GetContainersFromType<ValuableContainer>(side.UnplacedContainers);
            foreach (IContainer container in valuableContainers) {
                int x = GetXPositionNSpotsFromEdge(n, side);
                Stack staple = side.GetStackFromCoordinates(x, y);
                FillValuableStapleToMinHeight(side.UnplacedContainers, side, x, y);
                if (y - 1 < 1) {
                    n++;
                    y = side.Length;
                }
                else
                    y--;
            }
        }

        // Step 3.5
        private void FillValuableStapleToMinHeight(IEnumerable<IContainer> containers, Side side, int x, int y) {
            Stack staple = side.GetStackFromCoordinates(x, y);
            IContainer valuableContainer = GetLightestContainerFromType<ValuableContainer>(containers);
            ship.TryAddContainer(valuableContainer, x, y);
            while (staple.Containers.Count() < GetMinimumValuableHeight(staple)) {
                if (staple.Containers.Count() == 1) {
                    if (!ship.TryAddContainer(ContainerHelper.GetHeaviestContainerExcludingType<ValuableContainer>(containers), x, y))
                            throw new InvalidOperationException("Can't make the staple high enough for the valuable");
                    continue;
                }
                if (!ship.TryAddContainer(ContainerHelper.GetLightestContainerExcludingType<ValuableContainer>(containers),x ,y))
                     throw new InvalidOperationException("Can't make the staple high enough for the valuable");
            }
        }

        // Step 4
        private void PlaceRegularForSide(Side side) {
            IEnumerable<IContainer> regularContainers = GetContainersFromType<RegularContainer>(side.UnplacedContainers);
            regularContainers = SortContainersByTypeThenByWeightDescending(regularContainers);
            foreach (IContainer container in regularContainers) {
                AddContainerToLightestStaple(container, side);
            }
            if (side.UnplacedContainers.Count > 0)
                throw new Exception("Can't place all containers on the ship");
        }

        // Step 4.5
        private bool AddContainerToLightestStaple(IContainer container, Side side) {
            side.OrderStaplesByWeight();
            foreach (Stack staple in side.Stacks) {
                if (ship.TryAddContainer(container, staple.X, staple.Y))
                    return true;
            }
            return false;
        }

        #region helpers
        /// <summary>
        /// Because the start X position is different for each side
        /// </summary>
        private int GetXPositionNSpotsFromEdge(int n, Side side) {
            if (n + 1 >= side.StartX) // left
                return n + 1;
            else if (side.StartX == Math.Floor((double)ship.Width / 2) + 1 && ship.Sides.Count() > 2)
                return side.StartX - n; // middle
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
