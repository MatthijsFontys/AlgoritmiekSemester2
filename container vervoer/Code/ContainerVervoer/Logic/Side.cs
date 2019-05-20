using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Side {
        private List<Stack> stacks;
        private List<IContainer> unplacedContainers;
        public IReadOnlyCollection<Stack> Stacks {
            get { return stacks.AsReadOnly(); }
        }
        public IReadOnlyCollection<IContainer> UnplacedContainers {
            get { return unplacedContainers.AsReadOnly(); }
        }
        public int Width { get; private set; }
        public int Length { get; private set; }
        public int StartX { get; private set; }

        public Side(int width, int length, int startX = 0) {
            Width = width;
            Length = length;
            StartX = startX;
            stacks = new List<Stack>();
            unplacedContainers = new List<IContainer>();
            InitStaples();
        }

        public void OrderStaplesByWeight() {
            stacks = stacks
                .OrderBy(s => s.GetTotalWeight())
                .ToList();
        }

        public bool TryAddContainer(IContainer container, int x, int y) {
            Stack stapleAtXY = stacks.FirstOrDefault(s => s.X == x && s.Y == y);
            if (stapleAtXY == null)
                stapleAtXY = CreateNewStapleIfValid(x, y);
            if (stapleAtXY.TryAddContainer(container)) {
                unplacedContainers.Remove(container);
                return true;
            }
            return false;
        }

        public double GetTotalWeight() {
            return stacks
                .Sum(x => x.GetTotalWeight());
        }

        public Stack GetStapleFromCoordinates(int x, int y) {
            Stack toReturn = stacks
                .FirstOrDefault(s => s.X == x && s.Y == y);
            return toReturn == null ? CreateNewStapleIfValid(x, y) : toReturn;
        }

        public Stack GetLightestStaple() {
            return stacks
                .OrderBy(s => s.GetTotalWeight())
                .ThenBy(s => s.Containers.Count())
                .FirstOrDefault();
        }

        public bool Validate() {
            foreach (Stack staple in stacks) {
                if (staple.Validate() == false)
                    return false;
            }
            return true;
        }

        private Stack CreateNewStapleIfValid(int x, int y) {
            if (x >= StartX && x < StartX + Width && y > 0 && y <= Length) {
                Stack newStaple = new Stack(x, y);
                stacks.Add(newStaple);
                return newStaple;
            }
            Console.WriteLine($"Start X {StartX}");
            Console.WriteLine($"X:{x} Y:{y}");
            throw new ArgumentException("Invalid coordinates");
        }

        public void AddToUnplacedContainers(IContainer shipContainer) {
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
