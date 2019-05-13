using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    class SideAlgorihmHelper {
        public List<IShipContainer> AvailableValueables{ get; set; }
        public List<IShipContainer> NotOrderedContainers { get; set; }
        public SideName Name { get; set; }

        public SideAlgorihmHelper() {
            AvailableValueables = new List<IShipContainer>();
            NotOrderedContainers = new List<IShipContainer>();
        }

        public double GetTotalWeight() {
            return NotOrderedContainers.Sum(x => x.Weight);
        }

        public void SetAvailableValueables() {
            AvailableValueables = NotOrderedContainers.Where(x => x is ValuableContainer).ToList();
        }
    }
}
