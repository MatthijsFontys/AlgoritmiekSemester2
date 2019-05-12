using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Generation {
        private List<int> sums;
        private List<List<int>> sequences;
        public IReadOnlyCollection<int> Sums { get { return sums.AsReadOnly(); } }
        public IReadOnlyCollection<List<int>> Sequences{ get { return sequences.AsReadOnly(); } }

        public Generation() {
            sums = new List<int>();
            sequences = new List<List<int>>();
        }

        public void Add(List<int> sequence, List<int>numbers) {
            sums.Add(CalculateSumBySequence(sequence, numbers));
            sequences.Add(sequence);
        }

        public static int CalculateSumBySequence(List<int> sequence, List<int> numbers) {
            int sum = 0;
            foreach (int index in sequence) {
                sum += numbers[index];
            }
            return sum;
        }

        public static List<int> GetNumbersBySequence(List<int> sequence, List<int> numbers) {
            List<int> toReturn = new List<int>();
            foreach (int index in sequence) {
                toReturn.Add(numbers[index]);
            }
            return toReturn;
        }

        public bool HasSum(int number) {
            return sums.Contains(number);
        }

        public List<int> GetSequenceFromSum(int sum) {
            int sumIndex = sums.IndexOf(sum);
            return sequences[sumIndex];
        }

        public bool IsIndexInSequence(int index, int sum) {
            int sumIndex = sums.IndexOf(sum);
            return sequences[sumIndex].Contains(index);
        }
    }
}
