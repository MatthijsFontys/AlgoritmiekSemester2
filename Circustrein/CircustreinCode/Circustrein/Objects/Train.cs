using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Train {
        private List<Wagon> wagons;
        public ReadOnlyCollection<Wagon> Wagons {
            get { return wagons.AsReadOnly(); }
        }
        public int WagonCount {
            get { return wagons.Count; }
        }

        public Train() {
            wagons = new List<Wagon>();
        }

        public void AddWagon(Wagon wagon) {
            wagons.Add(wagon);
        }

        public void SortWagons() {
            wagons = AnimalWagonSorter.SortWagonsByCarnivoreSizeDescending(wagons);
        }




    }
}
