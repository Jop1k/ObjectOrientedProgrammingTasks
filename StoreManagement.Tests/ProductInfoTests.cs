namespace Task9StoreManagement.Tests;

public class ProductInfoTests
{
    [Fact]
    public void Quantity_SetNegativeValue_ThrowsInvalidQuantityException()
    {
        var product = new Product("card", 0);
        var productInfo = new ProductInfo(product, 100, 10);

        Assert.Throws<InvalidQuantityException>(() => productInfo.Quantity = -5);
    }

    [Fact]
    public void Price_SetNegativeValue_ThrowsInvalidPriceException()
    {
        var product = new Product("book", 0);
        var productInfo = new ProductInfo(product, 100, 10);

        Assert.Throws<InvalidPriceException>(() => productInfo.Price = -5);
    }
}
