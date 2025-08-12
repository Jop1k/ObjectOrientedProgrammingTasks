global using ResultPattern;

namespace Task9StoreManagement.Tests;

public class ShopTests
{
    [Fact]
    public void AddProduct_CreateProduct_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);

        var result = shop.AddProduct(product, 100, 10);

        Assert.True(result.IsSuccess);
        Assert.Equal(product, shop.Products[0].Product);
        Assert.Equal(100, shop.Products[0].Price);
        Assert.Equal(10, shop.Products[0].Quantity);
    }

    [Fact]
    public void AddProduct_CreateAnExistingProduct_Failure()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.AddProduct(product, 0, 0);

        Assert.Equal(Error.ProductAlreadyExists, result.Error);
    }

    [Fact]
    public void AddProduct_CreatingProductWithInvalidQuantity_Failure()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);

        var result = shop.AddProduct(product, 0, -1);

        Assert.Equal(Error.InvalidQuantity, result.Error);
    }

    [Fact]
    public void AddProduct_CreatingProductWithInvalidPrice_Failure()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);

        var result = shop.AddProduct(product, -1, 0);

        Assert.Equal(Error.InvalidPrice, result.Error);
    }

    [Fact]
    public void RemoveProduct_DeleteExistingProduct_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.RemoveProduct(product.Code);

        Assert.True(result.IsSuccess);
        Assert.Empty(shop.Products);
    }

    [Fact]
    public void RemoveProduct_PassingNonExistentProductCode_Failure()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = shop.RemoveProduct(0);

        Assert.Equal(Error.ProductNotFound, result.Error);
    }

    [Fact]
    public void ChangePrice_TransferringCorrectPrice_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.ChangePrice(0, 100);

        Assert.True(result.IsSuccess);
        Assert.Equal(100, shop.Products[0].Price);
    }

    [Fact]
    public void ChangePrice_PassingNonExistentProductCode_Failure()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = shop.ChangePrice(0, 100);

        Assert.Equal(Error.ProductNotFound, result.Error);
    }

    [Fact]
    public void ChangePrice_PassingInvalidPrice_Failure()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banan", 0);
        shop.AddProduct(product, 0, 0);

        var result = shop.ChangePrice(0, -1);

        Assert.Equal(Error.InvalidPrice, result.Error);
    }
}
