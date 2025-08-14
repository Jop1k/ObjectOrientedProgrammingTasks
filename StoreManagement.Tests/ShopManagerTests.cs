namespace Task9StoreManagement.Tests;

public class ShopManagerTests
{
    [Fact]
    public void FindShopWithLowestPriceForCart_TwoShopsWithSameOrderPrice_Success()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateShop("shop2", 2, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.CreateProduct("Apple", 2);
        shopManager.DeliverProducts(shopManager.Shops[1], (1, 10, 90), (2, 10, 100));
        shopManager.DeliverProducts(shopManager.Shops[2], (1, 10, 100), (2, 10, 90));

        var result = shopManager.FindShopWithLowestPriceForCart((1, 10), (2, 10));

        Assert.True(result.IsSuccess);
        Assert.Equal(2, result.Value!.Count);
        Assert.Equal("shop1", result.Value[0].Name);
        Assert.Equal("shop2", result.Value[1].Name);
    }

    [Fact]
    public void FindShopWithLowestPriceForCart_OneShopWithLowPrice_Success()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateShop("shop2", 2, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.CreateProduct("Apple", 2);
        shopManager.DeliverProducts(shopManager.Shops[1], (1, 10, 100), (2, 10, 100));
        shopManager.DeliverProducts(shopManager.Shops[2], (1, 10, 100), (2, 10, 90));

        var result = shopManager.FindShopWithLowestPriceForCart((1, 10), (2, 10));

        Assert.True(result.IsSuccess);
        Assert.Single(result.Value!);
        Assert.Equal("shop2", result.Value![0].Name);
    }

    [Fact]
    public void FindShopWithLowestPriceForCart_PassingBigQuantityOfProduct_ShopsNotFound()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateShop("shop2", 2, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.CreateProduct("Apple", 2);
        shopManager.DeliverProducts(shopManager.Shops[1], (1, 11, 100), (2, 10, 90));
        shopManager.DeliverProducts(shopManager.Shops[2], (1, 10, 100), (2, 11, 100));

        var result = shopManager.FindShopWithLowestPriceForCart((1, 11), (2, 11));

        Assert.Equal(Error.ShopsNotFound, result.Error);
        Assert.Null(result.Value!);
    }

    [Fact]
    public void FindShopWithLowestPriceForProduct_TwoShopsWithSameOrderPrice_Success()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateShop("shop2", 2, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.DeliverProducts(shopManager.Shops[1], (1, 10, 100));
        shopManager.DeliverProducts(shopManager.Shops[2], (1, 10, 100));

        var result = shopManager.FindShopWithLowestPriceForProduct(1);

        Assert.True(result.IsSuccess);
        Assert.Equal(2, result.Value!.Count);
        Assert.Equal("shop1", result.Value[0].Name);
        Assert.Equal("shop2", result.Value[1].Name);
    }

    [Fact]
    public void FindShopWithLowestPriceForProduct_OneShopWithLowPrice_Success()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateShop("shop2", 2, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.DeliverProducts(shopManager.Shops[1], (1, 10, 100));
        shopManager.DeliverProducts(shopManager.Shops[2], (1, 10, 90));

        var result = shopManager.FindShopWithLowestPriceForProduct(1);

        Assert.True(result.IsSuccess);
        Assert.Single(result.Value!);
        Assert.Equal("shop2", result.Value![0].Name);
    }

    [Fact]
    public void FindShopWithLowestPriceForProduct_PassingNonExistentProductCode_ShopsNotFound()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateShop("shop2", 2, new Address("", "", "", ""));

        var result = shopManager.FindShopWithLowestPriceForProduct(2);

        Assert.Equal(Error.ShopsNotFound, result.Error);
        Assert.Null(result.Value!);
    }

    [Fact]
    public void DeliverProducts_PassingCorrectValue_Success()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.CreateProduct("Apple", 2);

        var result = shopManager.DeliverProducts(shopManager.Shops[1], (1, 10, 100), (2, 20, 200));

        Assert.True(result.IsSuccess);
        Assert.Equal(10, shopManager.Shops[1].Products[1].Quantity);
        Assert.Equal(100, shopManager.Shops[1].Products[1].Price);
        Assert.Equal(20, shopManager.Shops[1].Products[2].Quantity);
        Assert.Equal(200, shopManager.Shops[1].Products[2].Price);
    }

    [Fact]
    public void DeliverProducts_PassingNonExistentProductCode_ProductNotFound()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.CreateProduct("Apple", 2);

        var result = shopManager.DeliverProducts(shopManager.Shops[1], (1, 10, 100), (404, 20, 200));

        Assert.Equal(Error.ProductNotFound, result.Error);
        Assert.Empty(shopManager.Shops[1].Products);
    }

    [Fact]
    public void DeliverProducts_PassingIncorrectQuantity_InvalidQuantity()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));
        shopManager.CreateProduct("Banana", 1);
        shopManager.CreateProduct("Apple", 2);

        var result = shopManager.DeliverProducts(shopManager.Shops[1], (1, 10, 100), (2, -1, 200));

        Assert.Equal(Error.InvalidQuantity, result.Error);
        Assert.Empty(shopManager.Shops[1].Products);
    }

    [Fact]
    public void CreateShop_PassingNonExistentProductCode_Success()
    {
        var shopManager = new ShopsManager();

        var result = shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));

        Assert.True(result.IsSuccess);
        Assert.Single(shopManager.Shops);
    }

    [Fact]
    public void CreateShop_PassingExistentProductCode_ShopAlreadyExists()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("shop1", 1, new Address("", "", "", ""));

        var result = shopManager.CreateShop("shop2", 1, new Address("", "", "", ""));

        Assert.Equal(Error.ShopAlreadyExists, result.Error);
        Assert.Single(shopManager.Shops);
    }

    [Fact]
    public void CreateProduct_PassingNonExistentProductCode_Success()
    {
        var shopManager = new ShopsManager();

        var result = shopManager.CreateProduct("product1", 1);

        Assert.True(result.IsSuccess);
        Assert.Single(shopManager.Products);
    }

    [Fact]
    public void CreateProduct_PassingExistentProductCode_ProductAlreadyExists()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateProduct("product1", 1);

        var result = shopManager.CreateProduct("product2", 1);

        Assert.Equal(Error.ProductAlreadyExists, result.Error);
        Assert.Single(shopManager.Products);
    }

}
