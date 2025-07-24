namespace FifthTask;

internal class Person
{
    public string Name { get; }

    public Person(string name) => Name = name;

    public override string ToString() => Name;
}
