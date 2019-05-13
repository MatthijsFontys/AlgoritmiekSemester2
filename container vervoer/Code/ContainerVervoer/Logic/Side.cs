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
        public int StartX { get; private set; }


        public Side(int width, int length, SideName sideName, int startX = 0) {
            Width = width;
            Length = length;
            Name = sideName;
            StartX = startX;
            staples = new List<Staple>();
        }

        public bool TryAddContainer(IShipContainer container, int x, int y) {
            Staple stapleToFind = staples.First(s => s.X == x && s.Y == y);
            if (stapleToFind == null) {
                return CreateNewStapleIfValid(x, y).TryAddContainer(container);
            }
            else
                return stapleToFind.TryAddContainer(container);
        }

        public double GetTotalWeight() {
            return staples.Sum(x => x.GetTotalWeight());
        }

        public Staple GetStapleWithCoordinates(int x, int y) {
            Staple toReturn = staples.FirstOrDefault(s => s.X == x && s.Y == y);
            return toReturn == null ? CreateNewStapleIfValid(x, y) : toReturn;
        }
        public bool Validate() {
            foreach (Staple staple in staples) {
                if (staple.Validate() == false)
                    return false;
            }
            return true;
        }

        private Staple CreateNewStapleIfValid(int x, int y) {
            if (x >= StartX && x < StartX + Width && y > 0 && y <= Length) {
                Staple newStaple = new Staple(x, y);
                staples.Add(newStaple);
                return newStaple;
            }
            Console.WriteLine($"X:{x} Y:{y}");
            throw new ArgumentException("Invalid coordinates");
        }

    }
}
