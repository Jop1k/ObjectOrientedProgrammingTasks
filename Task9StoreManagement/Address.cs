namespace Task9StoreManagement;

public class Address(string county, string city, string street, string building)
{
    public string Country { get; } = county;

    public string City { get; } = city;

    public string Street { get; } = street;

    public string Building { get; } = building;

    public override string ToString() => $"Address: country {Country}, city {City}, street {Street}, building {Building}";
}
