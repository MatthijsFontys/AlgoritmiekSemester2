using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circustrein.Logic;

namespace Circustrein {
    public class Algorithm
    {
        private Checker checker;
        private Getter getter;
        private Sorter sorter;

        public Algorithm()
        {
            checker = new Checker();
            getter = new Getter();
            sorter = new Sorter();
        }

        public int Run()
        {
            return 0;
        }
    }
}
