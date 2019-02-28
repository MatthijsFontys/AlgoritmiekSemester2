using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    class Train {
        private List<Wagon> wagons;
        public ReadOnlyCollection<Wagon> Wagons {
            get { return wagons.AsReadOnly(); }
        }

        public void AddWagon(Wagon wagon) {
            wagons.Add(wagon);
        }


    }
}
