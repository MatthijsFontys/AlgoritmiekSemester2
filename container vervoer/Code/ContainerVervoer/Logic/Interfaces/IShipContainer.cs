using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public interface IShipContainer {
        int Z { get; }
        double Weight {get; }
        bool Validate(Staple staple);
        int GetOptimizedZ(Staple staple);
        void SetZ(Staple staple, int z);
    }
}
