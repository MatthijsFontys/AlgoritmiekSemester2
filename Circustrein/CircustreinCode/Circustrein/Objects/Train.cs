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

        public Train() {
            wagons = new List<Wagon>();
        }

        public void AddWagon(Wagon wagon) {
            wagons.Add(wagon);
        }

        public void SortWagonsByCarnivoreSizeDescending() {
            List<Wagon> noCarnivoreWagons = wagons.Where(x => x.BiggestCarnivore == null).ToList();
            wagons = wagons.Where(x => x.BiggestCarnivore != null).OrderByDescending(x => x.BiggestCarnivore.Size).ToList();
            wagons.AddRange(noCarnivoreWagons);
        }
    }
}
