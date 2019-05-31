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

        private void DivideWeightBetweenSides() {
            WeightDivider wd = new WeightDivider(ship);
            wd.DivideManditoryPositions(containers);
            FillMiddleIfExists();
            wd.DivideLeftovers(containers);
        }

        private void PrepareContainersForMiddle() {
            List<IContainer> cooledContainers = SortContainersByMedian(ContainerHelper.GetContainersFromType<CooledContainer>(containers));
            List<IContainer> regularContainers = SortContainersByMedian(ContainerHelper.GetContainersFromType<RegularContainer>(containers));
            cooledContainers.AddRange(regularContainers);
            containers = cooledContainers;
        }

        private void FillMiddleIfExists() {
            if (ship.Sides.Count == 3) {
                int middleStartX = Convert.ToInt32(Math.Ceiling((double)ship.Width / 2));
                Side middle = ship.Sides.First(s => s.StartX == middleStartX);
                PrepareContainersForMiddle();
                for (int i = 0; i < containers.Count; i++) {
                    if (TryAddContainerToLightestStaple(containers[i], middle)) {
                        containers.Remove(containers[i]);
                        i--;
                    }
                }
            }
        }

        private List<IContainer> SortContainersByMedian(List<IContainer> containers) {
            List<IContainer> sorted = new List<IContainer>();
            double loopAmount = Math.Ceiling((double)containers.Count / 2);
            containers = containers.OrderBy(c => c.Weight).ToList();
            for (int i = 0; i < loopAmount; i ++) {
                sorted.Add(containers[i]);
                int indexFromEnd = containers.Count - 1 - i;
                if (i == indexFromEnd)
                    break;
                sorted.Add(containers[indexFromEnd]);
            }
            return sorted;
        }

        private void PlaceCooledForSide(Side side) {
            for (int n = side.Width -1 ; n >= 0; n--) {
                Stack stack = side.GetStackFromCoordinates(GetXPositionNSpotsFromEdge(n, side), side.Length);
                FillCooledStaple(side.UnplacedContainers, side, stack.X, stack.Y);
            }
        }

        private void FillCooledStaple(IEnumerable<IContainer> containers, Side side, int x, int y) {
            Stack staple = side.GetStackFromCoordinates(x, y);
            if (staple.Containers.Count == 0)
                ship.TryAddContainer(ContainerHelper.GetHeaviestContainerFromType<CooledContainer>(containers), x, y);
            while (ship.TryAddContainer(ContainerHelper.GetLightestContainerFromType<CooledContainer>(containers), x, y));
        }

        private void PlaceValuableForSide(Side side) {
            int n = 0;
            int y = ship.Length;
            List<IContainer> valuableContainers = ContainerHelper.GetContainersFromType<ValuableContainer>(side.UnplacedContainers);
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

        private void FillValuableStapleToMinHeight(IEnumerable<IContainer> containers, Side side, int x, int y) {
            Stack staple = side.GetStackFromCoordinates(x, y);
            IContainer valuableContainer = ContainerHelper.GetLightestContainerFromType<ValuableContainer>(containers);
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

        private void PlaceRegularForSide(Side side) {
            IEnumerable<IContainer> regularContainers = ContainerHelper.GetContainersFromType<RegularContainer>(side.UnplacedContainers);
            regularContainers = ContainerHelper.SortContainersByTypeThenByWeightDescending(regularContainers);
            foreach (IContainer container in regularContainers) {
                TryAddContainerToLightestStaple(container, side);
            }
            if (side.UnplacedContainers.Count > 0)
                throw new Exception("Can't place all containers on the ship");
        }

        private bool TryAddContainerToLightestStaple(IContainer container, Side side) {
            side.OrderStacksByWeight();
            foreach (Stack stack in side.Stacks) {
                if (ship.TryAddContainer(container, stack.X, stack.Y))
                    return true;
            }
            return false;
        }

        #region helpers
        //Todo set these in side class

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
        #endregion


    }
}
