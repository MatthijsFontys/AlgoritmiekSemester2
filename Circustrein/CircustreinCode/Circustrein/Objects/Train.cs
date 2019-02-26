using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Train
    {
        private List<Wagon> availableWagons;
        private List<Wagon> sortedWagons;

        public ReadOnlyCollection<Wagon> AvailableWagons
        {
            get { return availableWagons.AsReadOnly(); }
        }
        public ReadOnlyCollection<Wagon> SortedWagons{
            get { return sortedWagons.AsReadOnly(); }
        }

        public void AddWagon(Wagon wagon)
        {
            availableWagons.Add(wagon);
        }
    }
}
