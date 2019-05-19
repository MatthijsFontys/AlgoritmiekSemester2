using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Side {
        private List<Staple> staples;
        private List<IShipContainer> unplacedContainers;
        public IReadOnlyCollection<Staple> Staples {
            get { return staples.AsReadOnly(); }
        }
        public IReadOnlyCollection<IShipContainer> UnplacedContainers {
            get { return unplacedContainers.AsReadOnly(); }
        }
        public int Width { get; private set; }
        public int Length { get; private set; }
        public int StartX { get; private set; }

        public Side(int width, int length, int startX = 0) {
            Width = width;
            Length = length;
            StartX = startX;
            staples = new List<Staple>();
            unplacedContainers = new List<IShipContainer>();
            InitStaples();
        }

        public void OrderStaplesByWeight() {
            staples = staples.OrderBy(s => s.GetTotalWeight()).ToList();
        }

        public bool TryAddContainer(IShipContainer container, int x, int y) {
            Staple stapleAtXY = staples.FirstOrDefault(s => s.X == x && s.Y == y);
            if (stapleAtXY == null)
                stapleAtXY = CreateNewStapleIfValid(x, y);
            if (stapleAtXY.TryAddContainer(container)) {
                unplacedContainers.Remove(container);
                return true;
            }
            return false;
        }

        public double GetTotalWeight() {
            return staples.Sum(x => x.GetTotalWeight());
        }

        public Staple GetStapleFromCoordinates(int x, int y) {
            Staple toReturn = staples.FirstOrDefault(s => s.X == x && s.Y == y);
            return toReturn == null ? CreateNewStapleIfValid(x, y) : toReturn;
        }

        public Staple GetLightestStaple() {
            return staples.OrderBy(s => s.GetTotalWeight())
                .ThenBy(s => s.Containers.Count()).FirstOrDefault();
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
            Console.WriteLine($"Start X {StartX}");
            Console.WriteLine($"X:{x} Y:{y}");
            throw new ArgumentException("Invalid coordinates");
        }

        public void AddToUnplacedContainers(IShipContainer shipContainer) {
            unplacedContainers.Add(shipContainer);
        }

        private void InitStaples() {
            for (int y = 1; y <= Length; y++) {
                for (int x = StartX; x < StartX + Width; x++)
                    CreateNewStapleIfValid(x, y);
            }
        }
    }
}
