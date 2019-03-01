using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public interface IAnimal {
        AnimalSize Size { get; }
        bool IsSafeInWagon(Wagon wagon);
        int Weight { get; }
    }
}
