namespace Task9StoreManagement;

public class ShopsManager
{
    private readonly Dictionary<int, Product> _products = [];

    private readonly Dictionary<int, Shop> _shops = [];

    public IReadOnlyDictionary<int, Product> Products => _products.AsReadOnly();

    public IReadOnlyDictionary<int, Shop> Shops => _shops.AsReadOnly();

    public Result<List<Shop>> FindShopWithLowestPriceForCart(params (int productCode, int quantity)[] products)
    {
        List<Shop> shops = [];
        decimal lowestPrice = decimal.MaxValue;

        foreach (var shop in Shops.Values)
        {
            var calculateResult = ShopService.CalculateTheCost(shop, products);

            if (calculateResult.IsSuccess)
            {
                var cost = calculateResult.Value;

                if (lowestPrice > cost)
                {
                    lowestPrice = cost;
                    shops.Clear();
                    shops.Add(shop);
                }
                else if (lowestPrice == cost)
                {
                    shops.Add(shop);
                }
            }
        }

        return shops.Count == 0 ? Result<List<Shop>>.Failure(Error.ShopsNotFound, "There are no shops that sell these products.") : Result<List<Shop>>.Success(shops);
    }

    public Result<List<Shop>> FindShopWithLowestPriceForProduct(int productCode)
    {
        List<Shop> shops = [];
        decimal lowestPrice = decimal.MaxValue;

        foreach (var shop in Shops.Values)
        {
            if (shop.Products.ContainsKey(productCode))
            {
                decimal productPrice = shop.Products[productCode].Price;

                if (lowestPrice > productPrice && shop.Products[productCode].Quantity > 0)
                {
                    lowestPrice = productPrice;
                    shops.Clear();
                    shops.Add(shop);
                }
                else if (lowestPrice == productPrice && shop.Products[productCode].Quantity > 0)
                {
                    shops.Add(shop);
                }
            }
        }

        return shops.Count == 0 ? Result<List<Shop>>.Failure(Error.ShopsNotFound, "No shops found with this product.") : Result<List<Shop>>.Success(shops);
    }

    public Result DeliverProducts(Shop shop, params (int productCode, int quantity, decimal price)[] receivedProducts)
    {
        var tempShop = new Shop("temporary shop", 0, new Address("", "", "", ""));

        foreach (var (productCode, quantity, price) in receivedProducts)
        {
            if (!_products.ContainsKey(productCode))
            {
                return Result.Failure(Error.ProductNotFound, $"There is no product with code {productCode}.");
            }

            var receivePorductResult = ShopService.ReceiveProduct(tempShop, _products[productCode], quantity, price);
            if (!receivePorductResult.IsSuccess)
            {
                return receivePorductResult;
            }
        }

        foreach (var (productCode, quantity, price) in receivedProducts)
        {
            ShopService.ReceiveProduct(shop, _products[productCode], quantity, price);
        }

        return Result.Success();
    }
 
    public Result CreateShop(string name, int code, Address address)
    {
        if (_shops.ContainsKey(code))
        {
            return Result.Failure(Error.ShopAlreadyExists, $"Shop with code {code} already exists.");
        }

        _shops.Add(code, new Shop(name, code, address));
        return Result.Success();
    }

    public Result CreateProduct(string name, int code)
    {
        if (_products.ContainsKey(code))
        {
            return Result.Failure(Error.ProductAlreadyExists, $"Product with code {code} already exists.");
        }

        _products.Add(code, new Product(name, code));
        return Result.Success();
    }
}
