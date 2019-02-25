using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoritmiekOefenen;

namespace UnitTests {
    [TestClass]
    public class OrderTest
    {
        private Order order;

        [TestInitialize]
        public void Setup()
        {
            order = new Order();
        }

        [TestMethod]
        public void SortByPrice_simpleInts_Succes()
        {
            // Assign
            List<Product> expected = new List<Product>
            {
                new Product("a", 1),
                new Product("a", 4),
                new Product("a", 7),
                new Product("a", 8),
                new Product("a", 12)
            };

            List<Product> actual = new List<Product>
            {
                new Product("a", 12),
                new Product("a", 7),
                new Product("a", 4),
                new Product("a", 1),
                new Product("a", 8)
            };

            // Act
            order.SortProductsByPrice(actual);

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.IsTrue(expected[i].Price == actual[i].Price);
            }
        }

        [TestMethod]
        public void SortByPrice_ReversedList_Succes()
        {
            List<Product> expected = new List<Product>
            {
                new Product("a", 1),
                new Product("a", 4),
                new Product("a", 7),
                new Product("a", 8),
                new Product("a", 12)
            };

            List<Product> actual =
                new List<Product>
                {
                    new Product("a", 12),
                    new Product("a", 8),
                    new Product("a", 7),
                    new Product("a", 4),
                    new Product("a", 1)
                };
            order.SortProductsByPrice(actual);

            for (int i = 0; i < expected.Count; i++) {
                Assert.IsTrue(expected[i].Price == actual[i].Price);
            }
        }

        [TestMethod]
        public void GiveAveragePrice_simpleNumbers_Succes()
        {
            double expected = 10;

            List<Product> actual = new List<Product>
            {
                new Product("a", 5),
                new Product("a", 10),
                new Product("a", 15)
            };

            Assert.AreEqual(expected, order.GiveAveragePrice(actual));
        }

        [TestMethod]
        public void GiveAveragePrice_allDoubles_ResultRoundedDoubleLower_Succes() {
            double expected = 3.33;

            List<Product> actual = new List<Product>
            {
                new Product("a", 2.5),
                new Product("a", 4.1),
                new Product("a", 3.4)
            };

            Assert.AreEqual(expected, order.GiveAveragePrice(actual));
        }

        [TestMethod]
        public void GiveAveragePrice_allDoubles_ResultRoundedDoubleHigher_Succes() {
            double expected = 3.67;

            List<Product> actual = new List<Product>
            {
                new Product("a", 2.5),
                new Product("a", 4.1),
                new Product("a", 4.4)
            };

            Assert.AreEqual(expected, order.GiveAveragePrice(actual));
        }

        [TestMethod]
        public void GiveAveragePrice_allDoublesResultDouble_Succes() {
            double expected = 5.3;

            List<Product> actual = new List<Product>
            {
                new Product("a", 6.5),
                new Product("a", 4.1),
                new Product("a", 5.3)
            };

            Assert.AreEqual(expected, order.GiveAveragePrice(actual));
        }

        [TestMethod]
        public void GiveMaximumPrice_simpleNumbers_Succes()
        {
            double expected = 5;
            List<Product> actual = new List<Product>
            {
                new Product("a", 3),
                new Product("a", 5),
                new Product("a", 2),
                new Product("a", 4),
                new Product("a", 4)
            };

            Assert.AreEqual(expected, order.GiveMaximumPrice(actual));
        }

    }
}
