using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class ValuableContainer : IContainer {
        public int Z { get; private set; }
        public double Weight { get; private set; }

        public ValuableContainer(double weight) {
            Weight = weight;
        }

        public bool Validate(Stack staple) {
            if (!staple.Containers.Contains(this))
                throw new ArgumentException("Staple needs to contain the target container", "staple");
            return staple.Containers.Max(x => x.Z) == Z &&
                    staple.Containers.Count(c => c is ValuableContainer) == 1;
        }

        public override string ToString() {
            return "Valuable " + Math.Round(Weight, 2);
        }

        public int GetOptimizedZ(Stack staple) {
            return staple.Containers.Count() + 1;
        }

        public void SetZ(Stack staple, int z) {
            if (z > 0 && z < 30 && z <= staple.Containers.Count + 1)
                Z = z;
        }
    }
}
