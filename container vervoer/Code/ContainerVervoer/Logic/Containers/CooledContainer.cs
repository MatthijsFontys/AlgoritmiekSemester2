using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class CooledContainer : IContainer{
        private int manditoryYPosition;
        public CooledContainer(int manditoryYPosition, double weight) {
            this.manditoryYPosition = manditoryYPosition;
            Weight = weight;
        }
        public int Z { get;  private set; }
        public double Weight { get; private set; }

        public bool Validate(Stack staple) {
            if (!staple.Containers.Contains(this))
                throw new ArgumentException("Staple needs to contain the target container", "staple");
            return staple.Y == manditoryYPosition;
        }

        public override string ToString() {
            return "Cooled " + Math.Round(Weight, 2);  
        }

        public int GetOptimizedZ(Stack staple) {
            if (staple.Containers.Max(c => c.Weight) == Weight)
                return 1;
            return staple.Containers.Count();
        }

        public void SetZ(Stack staple, int z) {
            if (z > 0 && z < 30 && z <= staple.Containers.Count + 1) {
                if (staple.Containers.Contains(this))
                    Z = z;
                else throw new ArgumentException("The container needs to be in the staple", "staple");
            }
            else
                throw new ArgumentException("Invalid Z position", "z");
        }
    }
}
