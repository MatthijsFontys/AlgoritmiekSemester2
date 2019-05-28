using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class ContainerFactory {
        public static List<IContainer> CreateValuableContainers(double weight, int amount = 1) {
            List<IContainer> toReturn = new List<IContainer>();
            for (int i = 0; i < amount; i++)
                toReturn.Add(new ValuableContainer(weight));
            return toReturn;
        }

        public static List<IContainer> CreateRegularContainers(double weight, int amount = 1) {
            List<IContainer> toReturn = new List<IContainer>();
            for (int i = 0; i < amount; i++)
                toReturn.Add(new RegularContainer(weight));
            return toReturn;
        }

        public static List<IContainer> CreateCooledContainers(double weight, int manditoryY , int amount = 1){
            List<IContainer> toReturn = new List<IContainer>();
            for (int i = 0; i < amount; i++)
                toReturn.Add(new CooledContainer(manditoryY, weight));
            return toReturn;
        }

        public static List<IContainer> CreateCooledContainers(double weight, Ship ship, int amount = 1) {
            return CreateCooledContainers(weight, ship.Length, amount);
        }

        public static List<IContainer> ConcatContainerTypes(params IEnumerable<IContainer>[] lists) {
            int finalCapacity = 0;
            foreach (IEnumerable<IContainer> list in lists)
                finalCapacity += list.Count();

            List<IContainer> toReturn = new List<IContainer>(finalCapacity);

            foreach (IEnumerable<IContainer> list in lists)
                toReturn.AddRange(list);

            return toReturn;
        }


    }
}
