using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public static class HordeCreator {
        public static List<IAnimal> CreateHorde(params Horde[] hordes) {
            List<IAnimal> toReturn = new List<IAnimal>();
            foreach (Horde horde in hordes) {
                toReturn.AddRange(horde.GetHorde());
                Console.WriteLine("Test");
            }
            return toReturn;
        }
    }
}
