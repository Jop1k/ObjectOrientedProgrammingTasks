namespace Task1PersonCollectionToString;

internal class Person
{
    public string Name { get; }

    public Person(string name) => Name = name;

    public override string ToString() => $"Hello! My name is {Name}";
}
