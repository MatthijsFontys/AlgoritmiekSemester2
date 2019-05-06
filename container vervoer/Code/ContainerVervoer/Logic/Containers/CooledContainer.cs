using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public class CooledContainer : IContainer{
        public int Z { get;  set; }
        public double Weight { get; private set; }
        public bool Validate(Staple staple, int highestY) {
            if (Z == 1 && staple.GetTotalWeight() - Weight > 120 || staple.Y != highestY)
                return false;
            return true;
        }
    }
}
