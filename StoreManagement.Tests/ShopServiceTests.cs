namespace Task9StoreManagement.Tests;

public class ShopServiceTests
{
    [Fact]
    public void CanBuyProducts_PassingCorrectValue_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product1 = new Product("Banana", 0);
        var product2 = new Product("Apple", 1);
        shop.AddProduct(product1, 0, 10);
        shop.AddProduct(product2, 0, 10);

        var result = ShopService.CanBuyProducts(shop, (0, 10), (1, 10));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void CanBuyProducts_PassingNonExistentProductCode_ProductNotFound()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = ShopService.CanBuyProducts(shop, (0, 10));

        Assert.Equal(Error.ProductNotFound, result.Error);
    }

    [Fact]
    public void CanBuyProducts_PassingBigQuantityOfProduct_InsufficientQuantity()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product1 = new Product("Banana", 0);
        var product2 = new Product("Apple", 1);
        shop.AddProduct(product1, 0, 10);
        shop.AddProduct(product2, 0, 0);

        var result = ShopService.CanBuyProducts(shop, (0, 10), (1, 10));

        Assert.Equal(Error.InsufficientQuantity, result.Error);
    }

    [Fact]
    public void CanBuyProducts_PassingNegativeQuantity_InvalidQuantity()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = ShopService.CanBuyProducts(shop, (0, -1));

        Assert.Equal(Error.InvalidQuantity, result.Error);
    }

    [Fact]
    public void CalculateTheCost_PassingCorrectValue_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product1 = new Product("Banana", 1);
        var product2 = new Product("Apple", 2);
        shop.AddProduct(product1, 10, 10);
        shop.AddProduct(product2, 20, 5);

        var result = ShopService.CalculateTheCost(shop, (1, 10), (2, 5));

        Assert.Equal(200, result.Value);
    }

    [Fact]
    public void CalculateTheCost_PassingNonExistentProductCode_ProductNotFound()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = ShopService.CalculateTheCost(shop, (0, 10));

        Assert.Equal(Error.ProductNotFound, result.Error);
    }

    [Fact]
    public void BuyProducts_PassingCorrectValue_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product1 = new Product("Banana", 0);
        var product2 = new Product("Apple", 1);
        shop.AddProduct(product1, 0, 5);
        shop.AddProduct(product2, 0, 10);

        var result = ShopService.BuyProducts(shop, (0, 5), (1, 10));

        Assert.True(result.IsSuccess);
        Assert.Equal(0, shop.Products[0].Quantity);
        Assert.Equal(0, shop.Products[1].Quantity);
    }

    [Fact]
    public void BuyProducts_PassingNonExistentProductCode_ProductNotFound()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = ShopService.BuyProducts(shop, (0, 10));

        Assert.Equal(Error.ProductNotFound, result.Error);
    }

    [Fact]
    public void ReceiveProduct_AddNewProduct_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banana", 0);

        var result = ShopService.ReceiveProduct(shop, product, 5, 100);

        Assert.True(result.IsSuccess);
        Assert.True(shop.Products.ContainsKey(0));
        Assert.Equal(5, shop.Products[0].Quantity);
        Assert.Equal(100, shop.Products[0].Price);
    }

    [Fact]
    public void ReceiveProduct_AddNewProductWithIncorrectPrice_InvalidPrice()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banana", 0);

        var result = ShopService.ReceiveProduct(shop, product, 10, -100);

        Assert.Equal(Error.InvalidPrice, result.Error);
        Assert.Empty(shop.Products);
    }

    [Fact]
    public void ReceiveProduct_AddProduct_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banana", 0);
        shop.AddProduct(product, 50, 5);

        var result = ShopService.ReceiveProduct(shop, product, 5, 100);

        Assert.True(result.IsSuccess);
        Assert.Equal(10, shop.Products[0].Quantity);
        Assert.Equal(100, shop.Products[0].Price);
    }

    [Fact]
    public void ReceiveProduct_AddProductWithIncorrectPrice_InvalidPrice()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banana", 0);
        shop.AddProduct(product, 50, 5);

        var result = ShopService.ReceiveProduct(shop, product, 10, -100);

        Assert.Equal(Error.InvalidPrice, result.Error);
        Assert.Equal(5, shop.Products[0].Quantity);
    }

    [Fact]
    public void ReceiveProduct_PassingIncorrectQuantity_InvalidQuantity()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product = new Product("Banana", 0);

        var result = ShopService.ReceiveProduct(shop, product, -1, 100);

        Assert.Equal(Error.InvalidQuantity, result.Error);
        Assert.Empty(shop.Products);
    }

    [Fact]
    public void FindMaxProductsWithinBudget_PassingIncorrectBudget_Failure()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));

        var result = ShopService.FindMaxProductsWithinBudget(shop, -1000);

        Assert.Equal(Error.InvalidPrice, result.Error);
    }

    [Fact]
    public void FindPurchasableProducts_PassingCorrectValue_Success()
    {
        var shop = new Shop("shop", 0, new Address("", "", "", ""));
        var product1 = new Product("Banana", 0);
        var product2 = new Product("Apple", 1);
        shop.AddProduct(product1, 100, 9);
        shop.AddProduct(product2, 100, 11);

        var result = ShopService.FindMaxProductsWithinBudget(shop, 1000);

        Assert.True(result.IsSuccess);
        Assert.Equal(2, result.Value!.Count);
        Assert.Equal(9, result.Value[product1]);
        Assert.Equal(10, result.Value[product2]);
    }
}
