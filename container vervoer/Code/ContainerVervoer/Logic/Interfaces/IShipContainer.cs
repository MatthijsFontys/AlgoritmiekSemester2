using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public interface IShipContainer {
        int Z { get; set; }
        double Weight {get; }
        bool Validate(Staple staple);

    }
}
