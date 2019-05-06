using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public interface IContainer {
        int Z { get; }
        double Weight {get; }
        bool Validate(Staple staple);

    }
}
