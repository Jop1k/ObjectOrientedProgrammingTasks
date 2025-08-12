global using ResultPattern;

namespace Task9StoreManagement.Tests;

public class ShopTests
{
    [Fact]
    public void AddProduct_CreateProduct()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);

        var result = shop.AddProduct(product, 0, 0);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void AddProduct_CreateAnExistingProduct()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.AddProduct(product, 0, 0);

        Assert.Equal(Error.ProductAlreadyExists, result.Error);
    }

    [Fact]
    public void AddProduct_CreatingProductWithInvalidQuantity()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);

        var result = shop.AddProduct(product, 0, -1);

        Assert.Equal(Error.InvalidQuantity, result.Error);
    }

    [Fact]
    public void AddProduct_CreatingProductWithInvalidPrice()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);

        var result = shop.AddProduct(product, -1, 0);

        Assert.Equal(Error.InvalidPrice, result.Error);
    }

    [Fact]
    public void RemoveProduct_DeleteExistingProduct()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.RemoveProduct(product.Code);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void RemoveProduct_PassingNonExistentProductCode()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = shop.RemoveProduct(0);

        Assert.Equal(Error.ProductNotFound, result.Error);
    }

    [Fact]
    public void ChangePrice_TransferringCorrectPrice()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.ChangePrice(0, 100);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void ChangePrice_PassingNonExistentProductCode()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = shop.ChangePrice(0, 100);

        Assert.Equal(Error.ProductNotFound, result.Error);
    }

    [Fact]
    public void ChangePrice_PassingInvalidPrice()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.ChangePrice(0, -1);

        Assert.Equal(Error.InvalidPrice, result.Error);
    }
}
