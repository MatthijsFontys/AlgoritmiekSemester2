using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein {
    public class Animal
    {
        public readonly AnimalSize Size;
        public readonly AnimalDiet Diet;

        public Animal(AnimalSize size, AnimalDiet diet)
        {
            Size = size;
            Diet = diet;
        }

        public override string ToString()
        {
            return Size + " " + Diet;
        }
    }
}
