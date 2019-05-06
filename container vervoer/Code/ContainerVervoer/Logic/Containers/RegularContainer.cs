using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public class RegularContainer : IContainer {
        public int Z { get; private set; }
        public double Weight { get; private set; }
        public bool Validate(Staple staple) {
            throw new NotImplementedException();
        }
    }
}
