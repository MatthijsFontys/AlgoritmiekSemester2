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
            return GetHeaviestContainer(containersOfType);
        }

        public static IContainer GetHeaviestContainerExcludingType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c =>  c is T == false).ToList();
            return GetHeaviestContainer(containersOfType);
        }

        public static IContainer GetLightestContainerExcludingType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c => c is T == false).ToList();
            double minWeight = (containersOfType.Count() > 0) ? containersOfType.Min(c => c.Weight) : -1;
            return GetLightestContainer(containersOfType);
        }

        public static IContainer GetLightestContainerFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            List<IContainer> containersOfType = containers.Where(c => c is T).ToList();
            return GetLightestContainer(containersOfType);
        }

        public static List<IContainer> GetContainersFromType<T>(IEnumerable<IContainer> containers) where T : IContainer {
            return containers.Where(c => c is T).ToList();
        }

        private static IContainer GetLightestContainer(IEnumerable<IContainer> containers) {
            return containers.OrderBy(c => c.Weight).FirstOrDefault();
        }

        private static IContainer GetHeaviestContainer(IEnumerable<IContainer> containers) {
            return containers.OrderByDescending(c => c.Weight).FirstOrDefault();
        }
    }
}
