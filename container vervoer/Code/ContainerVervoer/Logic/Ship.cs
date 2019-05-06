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
            CreateSides();
        }



        public bool Validate() {
            return false;
        }

        public double GetWeightDifferenceInPercent() {
            Side left = GetSide(SideName.Left);
            Side right = GetSide(SideName.Right);
            double totalWeight = sides.Sum(x => x.GetTotalWeight());
            double weightDifference = left.GetTotalWeight() - right.GetTotalWeight();
            if (weightDifference < 0)
                weightDifference *= -1;
            return weightDifference / totalWeight * 100;
        }

        public void AddContainer(IContainer container, int x, int y) {
            if (x <= Width / 2)
                GetSide(SideName.Left).AddContainer(container, x, y);
            else
                GetSide(SideName.Right).AddContainer(container, x, y);
        }

        private Side GetSide(SideName sideName) {
            return sides.FirstOrDefault(x => x.Name == sideName);
        }

        private void CreateSides() {
            int sideWidth = Width;
            if (Width % 2 != 0) {
                sideWidth -= 1;
                sides.Add(new Side(1, Length, SideName.Middle));
            }
            sideWidth /= 2;
            sides.Add(new Side(sideWidth, Length, SideName.Left));
            sides.Add(new Side(sideWidth, Length, SideName.Right))
        }
    }
}
