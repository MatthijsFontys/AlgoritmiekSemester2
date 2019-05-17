using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Staple {
        private List<IShipContainer> containers;
        public IReadOnlyCollection<IShipContainer> Containers {
            get { return containers.AsReadOnly(); }
        }

        public double GetTotalWeight() {
            if (containers.Any(x => x.Z == 1)) {
                double weight = containers.Sum(x => x.Weight);
                return weight - containers.FirstOrDefault(x => x.Z == 1).Weight;
            }
            return 0;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public Staple(int x, int y) {
            X = x;
            Y = y;
            containers = new List<IShipContainer>();
        }

        public bool TryAddContainer(IShipContainer container) {
            if (container == null)
                return false;
            container.Z = containers.Count + 1;
            containers.Add(container);
            if (container.Validate(this)){
                return true;
            }
            containers.Remove(container);
            return false;
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
