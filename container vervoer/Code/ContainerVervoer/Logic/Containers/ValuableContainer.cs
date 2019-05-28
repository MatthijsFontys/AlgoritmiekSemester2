using System;
using System.Linq;

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

        public int GetOptimizedZ(Stack stack) {
            return stack.Containers.Count();
        }

        public void SetZ(Stack stack, int z) {
            if(! stack.Containers.Contains(this))
                throw new ArgumentException("The container needs to be in the stack", "staple");
            if (z == stack.Containers.Count)
                Z = z;
        }
    }
}
