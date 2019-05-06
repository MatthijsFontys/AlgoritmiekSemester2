using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    interface ILoadStrategy {
        void DivideContainers(IQueryable<IContainer> containers);

    }
}
