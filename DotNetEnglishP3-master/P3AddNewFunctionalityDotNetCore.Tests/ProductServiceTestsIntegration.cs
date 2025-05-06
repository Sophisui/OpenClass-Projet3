using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Data;
using P3AddNewFunctionalityDotNetCore.Models.Entities;

public class ProductServiceTestsIntegration
{
    private P3Referential GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<P3Referential>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Nouvelle base pour chaque test
            .Options;

        return new P3Referential(options, null);
    }

    [Fact]
    public void SaveProduct_ShouldPersistToDatabase()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var productRepository = new ProductRepository(context);
        var productService = new ProductService(null, productRepository, null, null);

        var productViewModel = new ProductViewModel
        {
            Name = "Test Product",
            Price = "15.99",
            Quantity = "10",
            Description = "Test Description",
            Details = "Test Details"
        };

        // Act
        productService.SaveProduct(productViewModel);
        var savedProduct = context.Product.FirstOrDefault(p => p.Name == "Test Product");

        // Assert
        Assert.NotNull(savedProduct);
        Assert.Equal(15.99, savedProduct.Price);
        Assert.Equal(10, savedProduct.Quantity);
    }

    [Fact]
    public void DeleteProduct_ShouldRemoveFromDatabase()
    {
        // Arrange
        using var context = GetInMemoryDbContext();
        var productRepository = new ProductRepository(context);
        var productService = new ProductService(null, productRepository, null, null);

        var product = new Product { Name = "To be deleted", Price = 20, Quantity = 5 };
        context.Product.Add(product);
        context.SaveChanges();

        // Vérification que le produit est bien en base
        // Assert.Single(context.Product);

        // Act
        productService.DeleteProductFromDatabase(product.Id);
        var deletedProduct = context.Product.FirstOrDefault(p => p.Id == product.Id);

        // Assert
        Assert.Null(deletedProduct);
    }
}

