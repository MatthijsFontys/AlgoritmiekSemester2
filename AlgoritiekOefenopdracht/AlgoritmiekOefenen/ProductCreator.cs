using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmiekOefenen {
     public class ProductCreator {
        private Random random = new Random();

        public List<Product> InitProducts(int amount, double minPrice, double maxPrice) {
            List<Product> toReturn = new List<Product>();
            for (int i = 0; i < amount; i++) {
                Product p = new Product(InitProductName(), Math.Round(random.NextDouble() * (maxPrice - minPrice) + minPrice , 2));
                toReturn.Add(p);
            }
            return toReturn;
        }

        private string InitProductName() {
            List<string> names = new List<string>{"B-Daman",
                "Digital pet",
                "Evel Knievel Action Figure",
                "G.I. Joe",
                "Gumby",
                "He-Man",
                "Jumping Jack",
                "Kenner Star Wars action figures",
                "Lara",
                "Little People",
                "Monster in My Pocket",
                "Playmobil",
                "Power Rangers",
                "The Smurfs merchandising",
                "Stretch Armstrong",
                "Teenage Mutant Ninja Turtles",
                "Toy soldier",
                "Transformers",
                "Weebles"};
            return names[random.Next(names.Count)];
        }
    }
}
