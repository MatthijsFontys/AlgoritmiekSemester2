using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Wagon> toReturn = wagons.Where(x => x.Validator.Carnivore != null).OrderByDescending(x => x.Validator.Carnivore.Size).ToList();
            toReturn.AddRange(wagons.Where(x => x.Validator.Carnivore == null).ToList());
            return toReturn;
        }
    }
}
