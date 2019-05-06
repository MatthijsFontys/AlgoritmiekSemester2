using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Staple {
        private List<IContainer> containers;
        private List<ReservationState> reservationStates;
        public IReadOnlyCollection<IContainer> Containers {
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

        public void AddContainer(IContainer container) {

        }
    }
}
