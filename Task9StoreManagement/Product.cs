namespace Task9StoreManagement;

public class Product(string name, int code)
{
    public int Code { get; } = code;

    public string Name { get; } = name.Сapitalize();

    public override string ToString() => $"Product: {Name} | Code: {Code}";
}
