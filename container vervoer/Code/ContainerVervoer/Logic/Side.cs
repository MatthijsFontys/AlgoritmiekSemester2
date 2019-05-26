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
            InitStacks();
        }

        public void OrderStaplesByWeight() {
            stacks = stacks
                .OrderBy(s => s.GetTotalWeight())
                .ToList();
        }

        public bool TryAddContainer(IContainer container, int x, int y) {
            Stack stapleAtXY = stacks.FirstOrDefault(s => s.X == x && s.Y == y);
            if (stapleAtXY == null)
                stapleAtXY = CreateNewStackIfValid(x, y);
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

        public Stack GetStackFromCoordinates(int x, int y) {
            Stack toReturn = stacks
                .FirstOrDefault(s => s.X == x && s.Y == y);
            return toReturn == null ? CreateNewStackIfValid(x, y) : toReturn;
        }

        public void AddToUnplacedContainers(IContainer shipContainer) {
            unplacedContainers.Add(shipContainer);
        }

        public bool Validate() {
            foreach (Stack staple in stacks) {
                if (staple.Validate() == false)
                    return false;
            }
            return true;
        }

        private Stack CreateNewStackIfValid(int x, int y) {
            if (x >= StartX && x < StartX + Width && y > 0 && y <= Length) {
                Stack newStaple = new Stack(x, y);
                stacks.Add(newStaple);
                return newStaple;
            }
            throw new ArgumentException("Invalid coordinates");
        }

        private void InitStacks() {
            for (int y = 1; y <= Length; y++) {
                for (int x = StartX; x < StartX + Width; x++)
                    CreateNewStackIfValid(x, y);
            }
        }
    }
}
