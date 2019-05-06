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

        public bool TryAddContainer(IContainer container, int x, int y, int highestY) {
            Staple stapleToFind = staples.First(s => s.X == x && s.Y == y);
            if (stapleToFind == null) {
                Staple newStaple = new Staple(x, y);
                staples.Add(newStaple);
                return  newStaple.TryAddContainer(container, highestY);
            }
            else
                 return stapleToFind.TryAddContainer(container, highestY);
        }

        public double GetTotalWeight() {
            return staples.Sum(x => x.GetTotalWeight());
        }
        public bool Validate(int highestY) {
            foreach (Staple staple in staples) {
                if (staple.Validate(highestY) == false)
                    return false;
            }
            return true;
        }
    }
}
}