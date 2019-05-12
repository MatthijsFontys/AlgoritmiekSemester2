using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class BruteForceTimeTest  : IBruteForce{


        public List<int> GetNumbersThatGiveSum(List<int> numbers, int target) {
            List<int> sequence = new List<int>();
            List<int> bestSequence = new List<int>();
            int best = 0;
            int currentSum = 0;

            for (int i = 0; i < numbers.Count; i++) {
                currentSum = 0;
                sequence.Clear();

                for (int j = 0; j < numbers.Count; j++) {
                    if (currentSum + numbers[j] <= target) {
                        currentSum += numbers[j];
                        sequence.Add(numbers[j]);
                        if (currentSum > best) {
                            best = currentSum;
                            SetBestSequence(sequence, bestSequence);
                        }
                    }
                }

            }
            return sequence;
        }


        private void SetBestSequence(List<int> sequence, List<int> bestSequence) {
            bestSequence.Clear();
            foreach (int number in sequence)
                bestSequence.Add(number);
            sequence.Clear();
        }

    }
}
