namespace Task9StoreManagement;

public class ShopService
{
    public static Result<decimal> CalculateTheCost(Shop shop, params (int code, int quantity)[] products)
    {
        var canBuyProducts = CanBuyProducts(shop, products);
        decimal costs = 0;

        if (canBuyProducts.IsSuccess)
        {
            costs = products.Sum(product => shop.Products[product.code].Price * product.quantity);
            return Result<decimal>.Success(costs);
        }

        return Result<decimal>.Failure(canBuyProducts.Error!.Value, canBuyProducts.ErrorMessage!);
    }

    public static Result CanBuyProducts(Shop shop, params (int code, int quantity)[] products)
    {
        foreach (var (code, quantity) in products)
        {
            if (quantity < 0)
            {
                return Result.Failure(Error.InvalidQuantity, "The quantity of products cannot be negative.");
            }

            if (!shop.Products.ContainsKey(code))
            {
                return Result.Failure(Error.ProductNotFound, $"Product with code {code} not found in the shop.");
            }

            if (shop.Products[code].Quantity < quantity)
            {
                return Result.Failure(Error.InsufficientQuantity, $"Not enough product with code {code} in the store");
            }
        }

        return Result.Success();
    }

    public static Result<decimal> BuyProducts(Shop shop, params (int code, int quantity)[] products)
    {
        var сalculateTheCost = CalculateTheCost(shop, products);

        if (сalculateTheCost.IsSuccess)
        {
            foreach (var (code, quantity) in products)
            {
                shop.Products[code].Quantity -= quantity;
            }

            return Result<decimal>.Success(сalculateTheCost.Value);
        }

        return Result<decimal>.Failure(сalculateTheCost.Error!.Value, сalculateTheCost.ErrorMessage!);
    }

    public static Result ReceiveProduct(Shop shop, Product product, int quantity, decimal price)
    {
        if (quantity < 0)
        {
            return Result.Failure(Error.InvalidQuantity, "The quantity of products cannot be negative.");
        }

        if (shop.Products.ContainsKey(product.Code))
        {
            var changePriceResult = shop.ChangePrice(product.Code, price);

            if (!changePriceResult.IsSuccess)
            {
                return changePriceResult;
            }

            shop.Products[product.Code].Quantity += quantity;
            return Result.Success();
        }

        var addProductResult = shop.AddProduct(product, price, quantity);
        return addProductResult.IsSuccess ? Result.Success() : addProductResult;
    }

    public static Result<Dictionary<Product, int>> FindMaxProductsWithinBudget(Shop shop, decimal budget)
    {
        if (budget < 0)
        {
            return Result<Dictionary<Product, int>>.Failure(Error.InvalidPrice, "Budget cannot be negative.");
        }

        Dictionary<Product, int> purchasableProducts = [];

        foreach (var product in shop.Products.Values)
        {
            if (product.Price <= budget)
            {
                int maxQuantity = (int)(budget / product.Price);

                purchasableProducts.Add(product.Product, Math.Min(product.Quantity, maxQuantity));
            }
        }

        return Result<Dictionary<Product, int>>.Success(purchasableProducts);
    }
}
