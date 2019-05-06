using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public class CooledContainer : IContainer{
        private int manditoryYPosition;
        public CooledContainer(int manditoryYPosition) {
            this.manditoryYPosition = manditoryYPosition;
        }
        public int Z { get;  set; }
        public double Weight { get; private set; }
        public bool Validate(Staple staple) {
            if (Z == 1 && staple.GetTotalWeight() - Weight > 120 || staple.Y != manditoryYPosition)
                return false;
            return true;
        }
    }
}
