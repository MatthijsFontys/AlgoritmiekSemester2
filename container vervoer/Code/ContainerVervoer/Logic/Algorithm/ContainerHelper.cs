using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public static class ContainerHelper {

        public static IEnumerable<IContainer> SortContainersByTypeThenByWeightDescending(IEnumerable<IContainer> containers) {
            return containers.OrderBy(x => x is ValuableContainer)
                 .ThenBy(x => x is CooledContainer)
                 .ThenByDescending(c => c.Weight).ToList();
        }

        public static  IContainer GetHeaviestContainerFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c => c is T).ToList();
            double maxWeight = (containersOfType.Count() > 0) ? containersOfType.Max(c => c.Weight) : -1;
            return containersOfType.FirstOrDefault(x => x.Weight == maxWeight);
        }

        public static IContainer GetHeaviestContainerExcludingType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c =>  c is T == false).ToList();
            double maxWeight = (containersOfType.Count() > 0) ? containersOfType.Max(c => c.Weight) : -1;
            return containersOfType.FirstOrDefault(x => x.Weight == maxWeight);
        }

        public static IContainer GetLightestContainerExcludingType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c => c is T == false).ToList();
            double minWeight = (containersOfType.Count() > 0) ? containersOfType.Min(c => c.Weight) : -1;
            return containersOfType.FirstOrDefault(x => x.Weight == minWeight);
        }

        public static IContainer GetLightestContainerFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c => c is T).ToList();
            double minWeight = (containersOfType.Count() > 0) ? containersOfType.Min(c => c.Weight) : -1;
            return containersOfType.FirstOrDefault(x => x.Weight == minWeight);
        }

        public static List<IContainer> GetContainersFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            return containers.Where(c => c is T).ToList();
        }
    }
}
