using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Side {
        private List<Staple> staples;
        public readonly SideName Name;
        public IReadOnlyCollection<Staple> Staples {
            get { return staples.AsReadOnly(); }
        }
        public int Width { get; private set; } 
        public int Length { get; private set; }


        public Side(int width, int length, SideName sideName) {
            Width = width;
            Length = length;
            Name = sideName;
        }

        public void AddContainer(IContainer container, int x, int y) {

        }

        public double GetTotalWeight() {
            return staples.Sum(x => x.GetTotalWeight());
        }
        public bool Validate() {
            return false;
        }
    }
}
}