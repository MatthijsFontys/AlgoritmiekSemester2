using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class LoadStrategy : ILoadStrategy {

        private Ship ship;
        private List<IShipContainer> containers;
        private List<SideAlgorihmHelper> sideHelpers;

        public void DivideContainers(List<IShipContainer> containers, Ship ship) {
            this.ship = ship;
            this.containers = containers;
            InitHelpers();
            DivideWeightBetweenSides();
            foreach (SideAlgorihmHelper helper in sideHelpers)
                helper.SetAvailableValueables();
            foreach (Side side in ship.Sides) {
                ReserveValuableSpotsForSide(side);
                ReserveCooledSpotsForSide(side);
            }
          PlaceCooled();
        }

        private void DivideWeightBetweenSides() {
            foreach (List<IShipContainer> containers in GetContainersByType()) {
                foreach (IShipContainer container in containers)
                    GetLightestSide().NotOrderedContainers.Add(container);
            }
        }

        private void ReserveValuableSpotsForSide(Side side) {
            int valuableCount = sideHelpers.First(v => v.Name == side.Name).AvailableValueables.Count;
            int xIncrement = 1;
            int x = 1;
            if (side.Name == SideName.Right) {
                x = ship.Width;
                xIncrement = -1;
            }
            int y = 1;
            for (int i = 0; i < valuableCount; i++) {
                if (x < side.StartX || x >= side.StartX + side.Width) {
                    throw new IndexOutOfRangeException("Can't divide all the valuables on this side");
                }
                side.GetStapleWithCoordinates(x, y).AddReservation(ReservationState.Valueable);
                if (y + 1 <= side.Length)
                    y++;
                else {
                    y = 1;
                    x += xIncrement;
                }

            }
        }

        private void ReserveCooledSpotsForSide(Side side) {
            for (int i = 0; i < side.Width; i++)
                side.GetStapleWithCoordinates(i + side.StartX, side.Length).AddReservation(ReservationState.Cooled);
        }

        private void PlaceCooled() {
            foreach (Side side in ship.Sides) {
                SideAlgorihmHelper helper = GetHelperFromSide(side);
                int startX = side.Length;
                int xIncrement = -1;
                if (side.Name == SideName.Right) {
                    startX++;
                    xIncrement *= -1;
                }
                List<Staple> cooledStaples = side.Staples.Where(x => x.ReservationStates.Contains(ReservationState.Cooled)).ToList();
                foreach (Staple staple in cooledStaples) {
                    if (staple.Containers.Count == 0) {
                        SortContainersByWeightDescending(helper.NotOrderedContainers);
                        IShipContainer heaviestCooled = helper.NotOrderedContainers.FirstOrDefault(c => c is CooledContainer);
                        if (heaviestCooled == null || staple.ReservationStates.Contains(ReservationState.Valueable))
                            break;
                        staple.TryAddContainer(heaviestCooled);
                        helper.NotOrderedContainers.Remove(heaviestCooled);
                    }
                    for (int i = 0; i < helper.NotOrderedContainers.Count; i++) {
                        SortContainersByWeight(helper.NotOrderedContainers);
                        IShipContainer lightestCooled = helper.NotOrderedContainers.First();
                        if (staple.TryAddContainer(helper.NotOrderedContainers[i])) {
                            helper.NotOrderedContainers.RemoveAt(i);
                            i--;
                        }
                        else
                            break;
                    }
                }

            }
        }


        private void PlaceCooledAndValuable() {
            foreach (Side side in ship.Sides) {
                SideAlgorihmHelper helper = GetHelperFromSide(side);
                int startX = side.Length;
                int xIncrement = -1;
                if (side.Name == SideName.Right) {
                    startX++;
                    xIncrement *= -1;
                }
                List<Staple> cooledAndValuableStapels = side.Staples.Where(x => x.ReservationStates.Contains(ReservationState.Cooled) && 
                 x.ReservationStates.Contains(ReservationState.Valueable)).ToList();
                foreach (Staple staple in cooledAndValuableStapels) {
                    if (staple.Containers.Count == 0) {
                        IShipContainer heaviestCooled =  GetHeaviestContainer(helper.NotOrderedContainers.Where(c => c is CooledContainer).ToList());
                        staple.TryAddContainer(heaviestCooled);
                        helper.NotOrderedContainers.Remove(heaviestCooled);
                    }
                    while (staple.Containers.Count < GetMinimumValuableHeight(staple)) {
                        int containersLeftToStaple = GetMinimumValuableHeight(staple) - staple.Containers.Count();
                        IShipContainer lightestValuable = helper.AvailableValueables.FirstOrDefault(c => c.Weight == helper.AvailableValueables.Min(x => x.Weight));
                        if (helper.NotOrderedContainers.Where(c => c is CooledContainer).Take(containersLeftToStaple).Sum(c => c.Weight) <= lightestValuable.Weight) {
                            foreach (IShipContainer container in helper.NotOrderedContainers.Where(c => c is CooledContainer).Take(containersLeftToStaple)) {
                                staple.TryAddContainer(container);
                                helper.NotOrderedContainers.Remove(container);
                            }
                        }
                        else {
                            IShipContainer lightestContainer = helper.NotOrderedContainers.OrderBy(c => c.Weight).First();
                            staple.TryAddContainer(lightestContainer);
                            helper.NotOrderedContainers.Remove(lightestContainer);
                        }
                    }
                }

            }
            /*
             min height
             highest first
             pick number of cooled lightest first until min height + lightest valueable 
            */
        }

        private int GetMinimumValuableHeight(Staple staple) {
            return (staple.X > ship.Length - staple.X) ? ship.Length - staple.X : staple.X; 
        }

        private bool TryPlaceContainer(IShipContainer container, int x, int y, SideAlgorihmHelper helper) {
            if (ship.TryAddContainer(container, x, y)) {
                helper.NotOrderedContainers.Remove(container);
                return true;
            }
            return false;
        }

        private SideAlgorihmHelper GetHelperFromSide(Side side) {
            return sideHelpers.First(x => x.Name == side.Name);
        }


        #region helpers 
        private void InitHelpers() {
            sideHelpers = new List<SideAlgorihmHelper>();
            foreach (Side side in ship.Sides) {
                sideHelpers.Add(new SideAlgorihmHelper
                {
                    Name = side.Name
                });
            }
        }
        private SideAlgorihmHelper GetLightestSide() {
            SideAlgorihmHelper lightestSide = null;
            foreach (SideAlgorihmHelper side in sideHelpers) {
                if (lightestSide == null || side.GetTotalWeight() < lightestSide.GetTotalWeight())
                    lightestSide = side;
            }
            return lightestSide;
        }

        private void SortContainersByWeight(List<IShipContainer> containers) {
            containers = containers.OrderBy(x => x.Weight).ToList();
        }
        private void SortContainersByWeightDescending(List<IShipContainer> containers) {
            containers = containers.OrderByDescending(x => x.Weight).ToList();
        }

        private void SortContainersByType() {
            containers = containers.OrderBy(x => x is ValuableContainer).
                ThenBy(x => x is CooledContainer).ToList();
        }

        private IShipContainer GetHeaviestContainer(List<IShipContainer> containers) {
            double maxWeight = containers.Max(x => x.Weight);
            return containers.First(x => x.Weight == maxWeight);
        }

        private List<List<IShipContainer>> GetContainersByType() {
            List<List<IShipContainer>> containersByType = new List<List<IShipContainer>>();
            containersByType.Add(containers.Where(x => x is ValuableContainer).ToList());
            containersByType.Add(containers.Where(x => x is CooledContainer).ToList());
            containersByType.Add(containers.Where(x => x is RegularContainer).ToList());
            return containersByType;
        }
        #endregion






    }
}
