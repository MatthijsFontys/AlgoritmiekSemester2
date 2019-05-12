using System;
using System.Collections.Generic;
using System.Text;

namespace Logic {
    public interface IBruteForce {
        List<int> GetNumbersThatGiveSum(List<int> numbers, int target);
    }
}
