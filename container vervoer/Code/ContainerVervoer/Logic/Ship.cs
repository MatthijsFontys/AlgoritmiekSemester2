using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic {
    public class Ship {
        public int Width { get; private set; }
        public int Length { get; private set; }
        private List<Side> sides;
        public IReadOnlyCollection<Side> Sides{
            get{ return sides.AsReadOnly() ;}
        }
        public Ship(int width, int length) {
            Width = width;
            Length = length;
            sides = new List<Side>();
            CreateSides();
        }

        public bool Validate() {
            foreach (Side side in sides) {
                if (side.Validate() == false)
                    return false;
            }
            if (GetWeightDifferenceInPercent() > 20)
                return false;
            return true;
        }

        public double GetWeightDifferenceInPercent() {
            Side left = GetSideByName(SideName.left);
            Side right = GetSideByName(SideName.right);
            double totalWeight = sides.Sum(x => x.GetTotalWeight());
            double weightDifference = left.GetTotalWeight() - right.GetTotalWeight();
            if (weightDifference < 0)
                weightDifference *= -1;
            return weightDifference / totalWeight * 100;
        }

        public bool TryAddContainer(IShipContainer container, int x, int y) {
            if (x <= Width / 2)
                return GetSideByName(SideName.left).TryAddContainer(container, x, y);
            else
                return GetSideByName(SideName.right).TryAddContainer(container, x, y);
        }

        public Side GetSideByName(SideName sideName) {
            return sides.FirstOrDefault(x => x.Name == sideName);
        }

        public Side GetLightestSide() {
            return sides.OrderBy(s => s.UnplacedContainers.Sum(c => c.Weight)).First();
        }

        private void CreateSides() {
            int sideWidth = Width;
            if (Width % 2 != 0) {
                sideWidth -= 1;
                int startX = Convert.ToInt32(Math.Ceiling((double)Length / 2));
                sides.Add(new Side(1, Length, SideName.middle, startX));
            }
            sideWidth /= 2;
            sides.Add(new Side(sideWidth, Length, SideName.left, 1));
            sides.Add(new Side(sideWidth, Length, SideName.right, Width - sideWidth + 1));
        }
    }
}
