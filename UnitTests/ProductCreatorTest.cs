using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoritmiekOefenen;

namespace UnitTests {
    [TestClass]
    public class ProductCreatorTest
    {
        private ProductCreator productCreator;
        

        [TestInitialize]
        public void Setup() {
            productCreator = new ProductCreator();
        }

        [TestMethod]
        public void InitProducts_CreateFiveProducts_Success()
        {
            // Assign

            // Act
            List<Product> result = productCreator.InitProducts(5, 0, 10);

            // Assert
            Assert.IsTrue(result.Count == 5);
        }
    }
}
