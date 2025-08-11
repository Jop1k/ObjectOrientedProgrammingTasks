using Task9StoreManagement;

namespace StoreManagement.Tests;

public class StoreManagement
{
    [Fact]
    public void CalculateTheCost_CalculateThePriceOfGoods_CorrectPrice()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("5opka", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("арбуз", 0);
        shopManager.CreateProduct("банан", 1);
        shopManager.CreateProduct("дынька", 2);
        shopManager.DeliverProducts(shopManager.Shops[0], [(0, 100, 500), (1, 100, 100), (2, 100, 600)]);

        decimal cost = ShopService.CalculateTheCost(shopManager.Shops[0], [(0, 4), (1, 12), (2, 3)]).Value;

        Assert.Equal(5000, cost);
    }

    [Fact]
    public void CanBuyProducts_SendingAnInvalidProductCode_False()
    {
        Assert.False(ShopService.CanBuyProducts(new Shop("5opka", 0, new Address("", "", "", "")), (0, 456)).IsSuccess);
    }

    [Fact]
    public void CanBuyProducts_CheckingThePossibilityOfPurchasing_True()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("5opka", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("арбуз", 0);
        shopManager.CreateProduct("банан", 1);
        shopManager.CreateProduct("дынька", 2);
        shopManager.DeliverProducts(shopManager.Shops[0], [(0, 100, 500), (1, 100, 100), (2, 100, 600)]);

        bool result = ShopService.CanBuyProducts(shopManager.Shops[0], [(0, 100), (1, 100), (2, 100)]).IsSuccess;

        Assert.True(result);
    }

    [Fact]
    public void CanBuyProducts_CheckingThePossibilityOfPurchasing_False()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("5opka", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("арбуз", 0);
        shopManager.CreateProduct("банан", 1);
        shopManager.CreateProduct("дынька", 2);
        shopManager.DeliverProducts(shopManager.Shops[0], [(0, 100, 500), (1, 100, 100), (2, 100, 600)]);

        bool result = ShopService.CanBuyProducts(shopManager.Shops[0], [(0, 101), (1, 101), (2, 101)]).IsSuccess;

        Assert.False(result);
    }

    [Fact]
    public void BuyProducts_BuyExistingProducts_CorrectResult()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("5opka", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("арбуз", 0);
        shopManager.CreateProduct("банан", 1);
        shopManager.CreateProduct("дынька", 2);
        shopManager.DeliverProducts(shopManager.Shops[0], [(0, 100, 500), (1, 100, 100), (2, 100, 600)]);

        var buyProductResult = ShopService.BuyProducts(shopManager.Shops[0], [(0, 10), (1, 10), (2, 10)]);
        (bool, decimal) result = (buyProductResult.IsSuccess, buyProductResult.Value);

        Assert.Equal((true, 12000), result);
    }

    [Fact]
    public void BuyProducts_BuyNonExistentProducts_CorrectResult()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("5opka", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("арбуз", 0);
        shopManager.CreateProduct("банан", 1);
        shopManager.CreateProduct("дынька", 2);
        shopManager.DeliverProducts(shopManager.Shops[0], [(0, 100, 500), (1, 100, 100), (2, 100, 600)]);

        var buyProductResult = ShopService.BuyProducts(shopManager.Shops[0], [(0, 101), (1, 101), (2, 101)]);
        (bool, decimal) result = (buyProductResult.IsSuccess, buyProductResult.Value);

        Assert.Equal((false, 0), result);
    }

    [Fact]
    public void BuyProducts_BuyProduct_NewAmountOfProduct()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("5opka", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("арбуз", 0);
        shopManager.DeliverProducts(shopManager.Shops[0], (0, 10, 500));

        ShopService.BuyProducts(shopManager.Shops[0], (0, 5));

        Assert.Equal(5, shopManager.Shops[0].Products[0].Quantity);
    }

    [Fact]
    public void ReceiveProducts_DeliverNonExistingInShopProduct_CorrectProductInfo()
    {
        var shop = new Shop("50PKA", 0, new Address("", "", "", ""));
        var product = new Product("Тумблер", 0);

        ShopService.ReceiveProduct(shop, product, 10, 100);

        Assert.Equal((product, 10, 100), (shop.Products[0].Product, shop.Products[0].Quantity, shop.Products[0].Price));
    }

    [Fact]
    public void ReceiveProducts_DeliverExistingInShopProduct_CorrectProductInfo()
    {
        var shop = new Shop("50PKA", 0, new Address("", "", "", ""));
        var product = new Product("Тумблер", 0);
        ShopService.ReceiveProduct(shop, product, 5, 100);

        ShopService.ReceiveProduct(shop, product, 5, 100);

        Assert.Equal((product, 10, 100), (shop.Products[0].Product, shop.Products[0].Quantity, shop.Products[0].Price));
    }

    [Fact]
    public void FindPurchasableProducts_SearchForPossibleProductsToBuy_CorrectProductList()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("50PKA", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("Тумблер", 0);
        shopManager.CreateProduct("Шоколадка", 1);
        shopManager.CreateProduct("Шокочервячки", 2);
        shopManager.CreateProduct("Вафля", 3);
        shopManager.DeliverProducts(shopManager.Shops[0], [(0, 10, 100), (1, 100, 80), (2, 5, 220), (3, 0, 10)]);
        Dictionary<Product, int> productList = [];
        productList.Add(shopManager.Products[0], 10);
        productList.Add(shopManager.Products[1], 12);
        productList.Add(shopManager.Products[2], 4);
        productList.Add(shopManager.Products[3], 0);

        var result = ShopService.FindPurchasableProducts(shopManager.Shops[0], 1000);

        Assert.Equal(productList, result.Value);
    }

    [Fact]
    public void ChangePrice_ChangeProductPrice_CorrectNewPrice()
    {
        var shop = new Shop("50PKA", 0, new Address("", "", "", ""));
        var product = new Product("Ананас", 0);
        ShopService.ReceiveProduct(shop, product, 10, 200);

        shop.ChangePrice(product.Code, 300);

        Assert.Equal(300, shop.Products[0].Price);
    }

    [Fact]
    public void DeliverProduct_DeliverProductToTheShop_CorrectProductInfo()
    {
        var shopManager = new ShopsManager();
        shopManager.CreateShop("50PKA", 0, new Address("", "", "", ""));
        shopManager.CreateProduct("Зубастик", 0);

        shopManager.DeliverProducts(shopManager.Shops[0], (0, 10, 100));

        Assert.Equal((shopManager.Products[0], 10, 100),
            (shopManager.Shops[0].Products[0].Product, shopManager.Shops[0].Products[0].Quantity, shopManager.Shops[0].Products[0].Price));
    }
}
