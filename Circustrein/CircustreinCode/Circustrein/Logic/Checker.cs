using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Checker {

        public bool CanFillSmallCarnivore() {
            return true;
        }

        public bool CanFillMediumCarnivore() {
            return true;
        }

        public bool AvailableCarnivoreWagon(Sorter sorter, Train train) {
            List<Wagon> sortedWagons = sorter.SortWagonsByAnimalDiet(train.AvailableWagons);
        }
    }
}
