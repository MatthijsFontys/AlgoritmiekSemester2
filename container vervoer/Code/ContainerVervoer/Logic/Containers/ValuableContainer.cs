using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class ValuableContainer : IShipContainer {
        public int Z { get; set; }
        public double Weight { get; private set; }
        public ValuableContainer(double weight) {
            Weight = weight;
        }
        public bool Validate(Staple staple) {
            if (staple.Containers.Max(x => x.Z) == Z)
                return true;
            return false;
        }

        public override string ToString() {
            return "Valuable " + Math.Round(Weight, 2);
        }
    }
}
