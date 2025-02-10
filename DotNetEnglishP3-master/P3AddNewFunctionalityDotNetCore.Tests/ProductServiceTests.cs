using System.Reflection;
using Xunit;
using System.Resources;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary>
        /// 

        private readonly ResourceManager resourceManager;

        public ProductServiceTests()
        {
            // Charger le ResourceManager à partir du fichier de ressources
            resourceManager = new ResourceManager("P3AddNewFunctionalityDotNetCore.Resources",
                Assembly.GetExecutingAssembly());
        }

        [Fact]
        public void MissingStock_ShouldReturnExpectedValue()
        {
            // Arrange
            string expectedValue = resourceManager.GetString("MissingStock");

            // Act
            string actualValue = resourceCulture.MissingStock;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PriceNotANumber_ShouldReturnExpectedValue()
        {
            // Arrange
            string expectedValue = resourceManager.GetString("PriceNotANumber");

            // Act
            string actualValue = resourceCulture.PriceNotANumber;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void PriceNotGreaterThanZero_ShouldReturnExpectedValue()
        {
            // Arrange
            string expectedValue = resourceManager.GetString("PriceNotGreaterThanZero");

            // Act
            string actualValue = resourceCulture.PriceNotGreaterThanZero;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void StockNotAnInteger_ShouldReturnExpectedValue()
        {
            // Arrange
            string expectedValue = resourceManager.GetString("StockNotAnInteger");

            // Act
            string actualValue = resourceCulture.StockNotAnInteger;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void StockNotGreaterThanZero_ShouldReturnExpectedValue()
        {
            // Arrange
            string expectedValue = resourceManager.GetString("StockNotGreaterThanZero");

            // Act
            string actualValue = resourceCulture.StockNotGreaterThanZero;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        // TODO write test methods to ensure a correct coverage of all possibilities
    }
}