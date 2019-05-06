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
        public bool Max { get; internal set; }

        public Staple(int x, int y) {
            X = x;
            Y = y;
        }

        public bool TryAddContainer(IContainer container) {
            container.Z = containers.Count + 1;
            containers.Add(container);
            if (container.Validate(this)){
                return true;
            }
            containers.Remove(container);
            return false;
        }

        public bool Validate() {
            foreach (IContainer container in containers) {
                if (container.Validate(this) == false)
                    return false;
            }
            return true;
        }
    }
}
