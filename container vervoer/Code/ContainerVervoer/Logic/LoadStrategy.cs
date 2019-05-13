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

        #region helpers 
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

        private void InitHelpers() {
            sideHelpers = new List<SideAlgorihmHelper>();
            foreach (Side side in ship.Sides) {
                sideHelpers.Add(new SideAlgorihmHelper
                {
                    Name = side.Name
                });
            }
        }




    }
}
