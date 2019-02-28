using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    interface IAnimal {
        AnimalSize Size { get; }
        List<IAnimal> GetHostileAnimals();
    }
}
