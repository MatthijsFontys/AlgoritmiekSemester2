﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public interface ILoadStrategy {
        void DivideContainers(List<IContainer> containers, Ship ship);
    }
}
