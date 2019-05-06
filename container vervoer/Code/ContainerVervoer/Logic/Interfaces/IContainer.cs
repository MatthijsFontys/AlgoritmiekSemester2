using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public interface IContainer {
        int Z { get; set; }
        double Weight {get; }
        bool Validate(Staple staple, int highestY);

    }
}
