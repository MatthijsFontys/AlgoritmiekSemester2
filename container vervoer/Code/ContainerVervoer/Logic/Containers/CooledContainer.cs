using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public class CooledContainer : IShipContainer{
        private int manditoryYPosition;
        public CooledContainer(int manditoryYPosition, double weight) {
            this.manditoryYPosition = manditoryYPosition;
            Weight = weight;
        }
        public int Z { get;  set; }
        public double Weight { get; private set; }
        public bool Validate(Staple staple) {
            if (Z == 1 && staple.GetTotalWeight() - Weight > 120 || staple.Y != manditoryYPosition)
                return false;
            return true;
        }

        public override string ToString() {
            return "Cooled " + Math.Round(Weight, 2);  
        }
    }
}
