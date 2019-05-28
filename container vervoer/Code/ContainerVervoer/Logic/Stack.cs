using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Stack {
        private List<IContainer> containers;
        public int X { get; private set; }
        public int Y { get; private set; }
        public IReadOnlyCollection<IContainer> Containers {
            get { return containers.AsReadOnly(); }
        }

        public double GetTotalWeight() {
            if (containers.Count > 0)
                return containers.Sum(x => x.Weight);
            return 0;
        }

        public Stack(int x, int y) {
            X = x;
            Y = y;
            containers = new List<IContainer>();
        }

        public bool TryAddContainer(IContainer container) {
            if (container == null)
                return false;
            containers.Add(container);
            OptimizeStackOrder();
            if (Validate()) {
                return true;
            }
            containers.Remove(container);
            UpdateContainersZPosition();
            return false;
        }

        public bool Validate() {
            if (! IsWeightValid())
                return false;
            foreach (IContainer container in containers) {
                if (container.Validate(this) == false)
                    return false;
            }
            return true;    
        }

        private void UpdateContainersZPosition() {
            for (int i = 0; i < containers.Count; i++)
                containers[i].SetZ(this, i + 1);
        }

        private void OptimizeStackOrder() {
            containers = containers.OrderBy(c => c.GetOptimizedZ(this)).ToList();
            UpdateContainersZPosition();
        }

        private bool IsWeightValid() {
            if (containers.Count == 0)
                return true;
            return GetTotalWeight() - containers.First(c => c.Z == 1).Weight <= 120;
        }
    }
}
