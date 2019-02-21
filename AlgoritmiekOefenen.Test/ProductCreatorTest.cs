using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoritmiekOefenen;

namespace AlgoritmiekOefenen.Test {
    [TestClass]
    public class ProductCreatorTest
    {
        private ProductCreator productCreator;

        [TestInitialize]
        public void Setup()
        {
            productCreator = new ProductCreator();
        }

        [TestMethod]
        public void InitProducts_CreateFiveProducts_Correct() {
            // Assign

            // Act
            List<Product> result = productCreator.InitProducts();
            // Assert
        }
    }
}
