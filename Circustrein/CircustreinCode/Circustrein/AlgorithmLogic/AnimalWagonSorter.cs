using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq; // Importing the sorting methods for list

namespace Circustrein {
    public static class AnimalWagonSorter {

        public static List<Wagon> SortWagonsByCarnivoreSizeDescending(List<Wagon> wagons) {
            List<Wagon> noCarnivoreWagons = wagons.Where(x => x.BiggestCarnivore == null).ToList();
            List<Wagon> carnivoreWagons = wagons.Where(x => x.BiggestCarnivore != null).OrderByDescending(x => x.BiggestCarnivore.Size).ToList();
            carnivoreWagons.AddRange(noCarnivoreWagons);
            return carnivoreWagons;

        }
        public static List<IAnimal> SortAnimalsBySizeDescending(List<IAnimal> animals) {
            return animals.OrderByDescending(x => x.Size).ToList();
        }
        
    }
}
