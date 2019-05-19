using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class RegularContainer : IShipContainer {
        public int Z { get; private set; }
        public double Weight { get; private set; }

        public RegularContainer(double weight) {
            Weight = weight;
        }

        public override string ToString() {
            return "Regular " + Math.Round(Weight, 2);
        }
        public bool Validate(Staple staple) {
            if (staple.GetTotalWeight() > 120)
                return false;
            return true;
        }

        public int GetOptimizedZ(Staple staple) {
            if (staple.Containers.Max(c => c.Weight) == Weight)
                return 1;
            return staple.Containers.Count();
        }

        public void SetZ(Staple staple, int z) {
            if (z > 0 && z < 30 && z <= staple.Containers.Count + 1)
                Z = z;
        }
    }
}
