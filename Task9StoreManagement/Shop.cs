namespace Task9StoreManagement;

public class Shop(string name, int code, Address address)
{
    private readonly Dictionary<int, ProductInfo> _products = [];

    public IReadOnlyDictionary<int, ProductInfo> Products => _products.AsReadOnly();

    public int Code { get; } = code;

    public string Name { get; } = name;

    public Address Address { get; } = address;

    public Result AddProduct(Product product, decimal price, int quantity)
    {
        if (_products.ContainsKey(product.Code))
        {
            return Result.Failure(Error.ProductAlreadyExists, $"Product with code {product.Code} already exists in the shop.");
        }

        try
        {
            _products.Add(product.Code, new ProductInfo(product, price, quantity));
            return Result.Success();
        }
        catch (InvalidQuantityException ex)
        {
            return Result.Failure(Error.InvalidQuantity, ex.Message);
        }
        catch (InvalidPriceException ex)
        {
            return Result.Failure(Error.InvalidPrice, ex.Message);
        }
    }

    public Result RemoveProduct(int productCode)
    {
        if (!_products.ContainsKey(productCode))
        {
            return Result.Failure(Error.ProductNotFound, $"Product with code {productCode} not found in the shop.");
        }

        _products.Remove(productCode);
        return Result.Success();
    }

    public Result ChangePrice(int productCode, decimal newPrice)
    {
        if (!_products.ContainsKey(productCode))
        {
            return Result.Failure(Error.ProductNotFound, $"Product with code {productCode} not found in the shop.");
        }

        try
        {
            _products[productCode].Price = newPrice;
            return Result.Success();
        }
        catch (InvalidPriceException ex)
        {
            return Result.Failure(Error.InvalidPrice, ex.Message);
        }
    }

    public override string ToString() => $"Shop: {Name} | Code: {Code} | {Address}";
}
