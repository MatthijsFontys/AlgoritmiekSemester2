using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class ValuableContainer : IShipContainer {
        public int Z { get; private set; }
        public double Weight { get; private set; }
        public ValuableContainer(double weight) {
            Weight = weight;
        }
        public bool Validate(Staple staple) {
            if (staple.Containers.Max(x => x.Z) == Z && staple.GetTotalWeight() <= 120)
                return true;
            return false;
        }

        public override string ToString() {
            return "Valuable " + Math.Round(Weight, 2);
        }

        public int GetOptimizedZ(Staple staple) {
            return staple.Containers.Count() + 1;
        }

        public void SetZ(Staple staple, int z) {
            if (z > 0 && z < 30 && z <= staple.Containers.Count + 1)
                Z = z;
        }
    }
}
