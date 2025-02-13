﻿using System.Reflection;
using Xunit;
using System.Resources;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models;
using Moq;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using Microsoft.Extensions.Localization;
using System.Linq;

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

        public void MissingName()
        {
            // Arrange
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = string.Empty;
            productViewModel.Quantity = "30";
            productViewModel.Price = "12";

            Mock<ICart> cartMoq = new Mock<ICart>();
            Mock<IProductRepository> productMoq = new Mock<IProductRepository>();
            Mock<IOrderRepository> orderMoq = new Mock<IOrderRepository>();
            Mock<IStringLocalizer<ProductService>> localiserMoq = new Mock<IStringLocalizer<ProductService>>();
            ProductService productService = new ProductService(cartMoq.Object, productMoq.Object, orderMoq.Object, localiserMoq.Object);

            // Act
            var result = productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Equal(result.FirstOrDefault(), "MissingName");
        }

        [Fact]
        public void MissingQuantity()
        {
            // Arrange
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = "Name";
            productViewModel.Quantity = string.Empty;
            productViewModel.Price = "12";

            Mock<ICart> cartMoq = new Mock<ICart>();
            Mock<IProductRepository> productMoq = new Mock<IProductRepository>();
            Mock<IOrderRepository> orderMoq = new Mock<IOrderRepository>();
            Mock<IStringLocalizer<ProductService>> localiserMoq = new Mock<IStringLocalizer<ProductService>>();
            ProductService productService = new ProductService(cartMoq.Object, productMoq.Object, orderMoq.Object, localiserMoq.Object);

            // Act
            var result = productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Equal(result.FirstOrDefault(), "MissingQuantity");
        }

        public void QuantityNotGreaterThanZero()
        {
            // Arrange
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = "Name";
            productViewModel.Quantity = "0";
            productViewModel.Price = "12";

            Mock<ICart> cartMoq = new Mock<ICart>();
            Mock<IProductRepository> productMoq = new Mock<IProductRepository>();
            Mock<IOrderRepository> orderMoq = new Mock<IOrderRepository>();
            Mock<IStringLocalizer<ProductService>> localiserMoq = new Mock<IStringLocalizer<ProductService>>();
            ProductService productService = new ProductService(cartMoq.Object, productMoq.Object, orderMoq.Object, localiserMoq.Object);

            // Act
            var result = productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Equal(result.FirstOrDefault(), "QuantityNotGreaterThanZero");
        }

        public void QuantityNotAnInteger()
        {
            // Arrange
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = "Name";
            productViewModel.Quantity = "ABCD";
            productViewModel.Price = "12";

            Mock<ICart> cartMoq = new Mock<ICart>();
            Mock<IProductRepository> productMoq = new Mock<IProductRepository>();
            Mock<IOrderRepository> orderMoq = new Mock<IOrderRepository>();
            Mock<IStringLocalizer<ProductService>> localiserMoq = new Mock<IStringLocalizer<ProductService>>();
            ProductService productService = new ProductService(cartMoq.Object, productMoq.Object, orderMoq.Object, localiserMoq.Object);

            // Act
            var result = productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Equal(result.FirstOrDefault(), "QuantityNotAnInteger");
        }

        public void MissingPrice()
        {
            // Arrange
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = "Name";
            productViewModel.Quantity = "30";
            productViewModel.Price = string.Empty;

            Mock<ICart> cartMoq = new Mock<ICart>();
            Mock<IProductRepository> productMoq = new Mock<IProductRepository>();
            Mock<IOrderRepository> orderMoq = new Mock<IOrderRepository>();
            Mock<IStringLocalizer<ProductService>> localiserMoq = new Mock<IStringLocalizer<ProductService>>();
            ProductService productService = new ProductService(cartMoq.Object, productMoq.Object, orderMoq.Object, localiserMoq.Object);

            // Act
            var result = productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Equal(result.FirstOrDefault(), "MissingPrice");
        }

        public void PriceNotGreaterThanZero()
        {
            // Arrange
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = "Name";
            productViewModel.Quantity = "30";
            productViewModel.Price = "0";

            Mock<ICart> cartMoq = new Mock<ICart>();
            Mock<IProductRepository> productMoq = new Mock<IProductRepository>();
            Mock<IOrderRepository> orderMoq = new Mock<IOrderRepository>();
            Mock<IStringLocalizer<ProductService>> localiserMoq = new Mock<IStringLocalizer<ProductService>>();
            ProductService productService = new ProductService(cartMoq.Object, productMoq.Object, orderMoq.Object, localiserMoq.Object);

            // Act
            var result = productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Equal(result.FirstOrDefault(), "PriceNotGreaterThanZero");
        }

        public void PriceNotANumber()
        {
            // Arrange
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Name = "Name";
            productViewModel.Quantity = "30";
            productViewModel.Price = "ABCD";

            Mock<ICart> cartMoq = new Mock<ICart>();
            Mock<IProductRepository> productMoq = new Mock<IProductRepository>();
            Mock<IOrderRepository> orderMoq = new Mock<IOrderRepository>();
            Mock<IStringLocalizer<ProductService>> localiserMoq = new Mock<IStringLocalizer<ProductService>>();
            ProductService productService = new ProductService(cartMoq.Object, productMoq.Object, orderMoq.Object, localiserMoq.Object);

            // Act
            var result = productService.CheckProductModelErrors(productViewModel);

            // Assert
            Assert.Equal(result.FirstOrDefault(), "PriceNotANumber");
        }



        // TODO write test methods to ensure a correct coverage of all possibilities
    }
}