using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public class RegularContainer : IContainer {
        public int Z { get; set; }
        public double Weight { get; private set; }
        public bool Validate(Staple staple) {
            if (Z == 1 && staple.GetTotalWeight() - Weight > 120)
                return false;
            return true;
        }
    }
}
