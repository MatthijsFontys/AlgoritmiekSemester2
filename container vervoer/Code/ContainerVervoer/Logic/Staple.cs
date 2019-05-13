using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Staple {
        private List<IShipContainer> containers;
        private List<ReservationState> reservationStates;
        public IReadOnlyCollection<IShipContainer> Containers {
            get { return containers.AsReadOnly(); }
        }
        public IReadOnlyCollection<ReservationState> ReservationStates {
            get { return reservationStates.AsReadOnly(); }
        }
        public double GetTotalWeight() {
            return containers.Sum(x => x.Weight);
        }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Staple(int x, int y) {
            X = x;
            Y = y;
            reservationStates = new List<ReservationState>();
        }

        public bool TryAddContainer(IShipContainer container) {
            container.Z = containers.Count + 1;
            containers.Add(container);
            if (container.Validate(this)){
                return true;
            }
            containers.Remove(container);
            return false;
        }

        public void AddReservation(ReservationState reservation) {
            reservationStates.Add(reservation);
        }

        public bool Validate() {
            foreach (IShipContainer container in containers) {
                if (container.Validate(this) == false)
                    return false;
            }
            return true;
        }
    }
}
