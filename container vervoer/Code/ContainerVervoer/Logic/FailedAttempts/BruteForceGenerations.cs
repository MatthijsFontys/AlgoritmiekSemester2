using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class BruteForceGenerations : IBruteForce {
        private List<Generation> generations;

        public BruteForceGenerations() {
            generations = new List<Generation>();
        }
        public List<int> GetNumbersThatGiveSum(List<int> numbers, int target) {
            generations.Add(CreateFirstGeneration(numbers));
            for (int i = 0; i < 10; i++) {
                generations.Add(CreateGeneration(generations[generations.Count - 1], numbers));
            }
            return GetBestSequence(target, numbers);
        }

        private Generation CreateGeneration(Generation lastGeneration, List<int> numbers) {
            Generation newGeneratrion = new Generation();
            foreach (int sum in lastGeneration.Sums) {
                AddStandardNumbers(lastGeneration, numbers, sum, newGeneratrion);
            }
            return newGeneratrion;
        }

        private void AddStandardNumbers(Generation lastGeneration, List<int> numbers, int sum, Generation newGeneration)    {
            for (int i = 0; i < numbers.Count; i++) {
                int newSum = sum;
                List<int> newSequence = new List<int>();
                List<int> oldSequence = lastGeneration.GetSequenceFromSum(sum);
                CopyList(newSequence, oldSequence);
                if (!newSequence.Contains(i)) {
                    newSum += numbers[i];
                    if (!lastGeneration.HasSum(newSum)) {
                        newSequence.Add(i);
                        newGeneration.Add(newSequence, numbers);
                    }
                }
            }
        }

        private List<int> GetBestSequence(int target, List<int> numbers) {
            List<int> bestSequence = new List<int>();
            for (int i = generations.Count-1; i >= 0 ; i--) {
                foreach (List<int> sequence in generations[i].Sequences) {
                    if (Generation.CalculateSumBySequence(sequence, numbers) > Generation.CalculateSumBySequence(bestSequence, numbers) && Generation.CalculateSumBySequence(sequence, numbers) <= target)
                        CopyList(bestSequence, sequence);
                }
            }
            return bestSequence;
        }

        private void CopyList(List<int> copyTo, List<int> listToCopy) {
            copyTo.Clear();
            foreach (int item in listToCopy)
                copyTo.Add(item);
        }

        private Generation CreateFirstGeneration(List<int> numbers) {
            Generation firstGeneration = new Generation();
            for (int i = 0; i < numbers.Count; i++) {
                if (!firstGeneration.HasSum(numbers[i])) {
                    firstGeneration.Add(new List<int> { i }, numbers);
                }
            }
            return firstGeneration;
        }

    }
}
