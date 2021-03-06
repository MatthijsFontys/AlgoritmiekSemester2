﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class RegularContainer : IContainer {
        public int Z { get; private set; }
        public double Weight { get; private set; }

        public RegularContainer(double weight) {
            Weight = weight;
        }

        public override string ToString() {
            return "Regular " + Math.Round(Weight, 2);
        }

        public bool Validate(Stack stack) {
            if (!stack.Containers.Contains(this))
                throw new ArgumentException("Stack needs to contain the target container", "stack");
            return true;
        }

        public int GetOptimizedZ(Stack stack) {
            if (stack.Containers.Max(c => c.Weight) == Weight)
                return 1;
            return stack.Containers.Count() - 1;
        }

        public void SetZ(Stack stack, int z) {
            if (!stack.Containers.Contains(this))
                throw new ArgumentException("The container needs to be in the stack", "stack");
            if (z > 0 && z < 30 && z <= stack.Containers.Count) {
                Z = z;
            }
        }
    }
}
