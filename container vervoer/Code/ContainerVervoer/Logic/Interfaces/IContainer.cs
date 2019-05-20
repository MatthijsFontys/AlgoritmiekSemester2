using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public interface IContainer {
        int Z { get; }
        double Weight {get; }
        bool Validate(Stack staple);
        int GetOptimizedZ(Stack staple);
        void SetZ(Stack staple, int z);
    }
}
