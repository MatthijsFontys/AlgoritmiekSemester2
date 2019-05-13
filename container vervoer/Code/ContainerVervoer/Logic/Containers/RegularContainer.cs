using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public class RegularContainer : IShipContainer {
        public int Z { get; set; }
        public double Weight { get; private set; }

        public RegularContainer(double weight) {
            Weight = weight;
        }

        public override string ToString() {
            return "Regular " + Math.Round(Weight, 2);
        }
        public bool Validate(Staple staple) {
            if (Z == 1 && staple.GetTotalWeight() - Weight > 120)
                return false;
            return true;
        }
    }
}
