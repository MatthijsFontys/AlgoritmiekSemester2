using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Circustrein {
    public class Sorter {

        public Sorter(){
        }

        public List<Animal> SortAnimalsBySize(List<Animal> animals) {
            return animals.OrderBy((x) => x.Size).ToList();
        }

        public List<Animal> SortAnimalsByDiet(List<Animal> animals) {
            return animals.OrderByDescending(x => x.Diet).ToList();
        }

        public List<Wagon> SortWagonsByAnimalDiet(List<Wagon> wagons) {
            return wagons.OrderByDescending(x => x).ToList();
        }
    }
}
