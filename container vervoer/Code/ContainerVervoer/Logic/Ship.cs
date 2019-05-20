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
            if (GetWeightDifferenceInPercent() > 20)
                throw new Exception("Side weight could not be balanced");
                //return false;
            foreach (Side side in sides) {
                if (side.Validate() == false)
                    return false;
            }
            return true;
        }

        public double GetWeightDifferenceInPercent() {
            double totalWeight = sides.Sum(x => x.GetTotalWeight());
            double weightDifference = sides[0].GetTotalWeight() - sides[1].GetTotalWeight();
            if (weightDifference < 0)
                weightDifference *= -1;
            if (weightDifference == 0)
                return 0;
            return weightDifference / totalWeight * 100;
        }

        public bool TryAddContainer(IContainer container, int x, int y) {
            if (container == null)
                return false;
            return GetSideByCoordinates(x, y).TryAddContainer(container, x, y);
        }

        public Side GetLightestSide() {
            return sides.OrderBy(s => s.UnplacedContainers.Sum(c => c.Weight)).First();
        }


        private Side GetSideByCoordinates(int x, int y) {
            return sides.FirstOrDefault(s => s.StartX <= x && x <= s.StartX + s.Width - 1);
        }

        private void CreateSides() {
            int sideWidth = Width;
            if (Width % 2 != 0) {
                sideWidth -= 1;
                int startX = Convert.ToInt32(Math.Ceiling((double)Length / 2));
                sides.Add(new Side(1, Length, startX));
            }
            sideWidth /= 2;
            sides.Add(new Side(sideWidth, Length, 1));
            sides.Add(new Side(sideWidth, Length, Width - sideWidth + 1));
        }
    }
}
