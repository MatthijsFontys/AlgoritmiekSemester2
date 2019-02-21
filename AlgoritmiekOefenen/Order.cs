﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlgoritmiekOefenen {
    public class Order {
        private ProductCreator productCreator;
        private List<Product> _products;
        public Order() {
            // Creating the products
            productCreator = new ProductCreator();
            _products = productCreator.InitProducts(10, 0, 10);

            // Sorting products
            SortProductsByPrice(_products);
        }

        public double GiveMaximumPrice(List<Product> products)
        {
            double maxRecord = -1;
            foreach (Product product in products)
            {
                if (product.Price > maxRecord)
                    maxRecord = product.Price;
            }

            return maxRecord;
        }

        public double GiveAveragePrice(List<Product> products)
        {
            double total = 0;
            foreach (Product product in products)
            {
                total += product.Price;
            }

            return total / products.Count;
        }

        public List<Product> GetAllProducts(List<Product> products, double minimumPrice) {
            List<Product> toReturn = new List<Product>();
            foreach (Product product in products)
            {
                if(product.Price > minimumPrice)
                    toReturn.Add(product);
            }
            return toReturn;
        }

        /// <summary>
        /// Uses bubble sort to sort a list of products by price from low to high
        /// </summary>
        public void SortProductsByPrice(List<Product> products)
        {
            // Bubble sort
            bool isSorted = false;
            while(! isSorted)
            {
                isSorted = true;
                // Bubble sort 1 iteration
                for (int i = 0; i < products.Count - 1; i++)
                {
                    if (products[i].Price > products[i + 1].Price)
                    {
                        SwapInList(products, i);
                        isSorted = false;
                    }
                }
            }

        }

        /// <summary>
        /// Swaps 2 consecutively indexes in a list
        /// </summary>
        /// <param name="index">The starting index</param>
        private void SwapInList(List<Product> list, int index)
        {
            Product temp;
            temp = list[index + 1];
            list[index + 1] = list[index];
            list[index] = temp;
        }


        private void LogList(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.Write(product.Price + " ");
            }
            Console.Write("\n");
        }
    }
}
