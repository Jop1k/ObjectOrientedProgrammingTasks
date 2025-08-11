namespace Task2PersonLifecycle;

internal class Person
{
    public string Name { get; private set; }

    public Person(string name) => Name = name;

    public override string ToString() => $"Hello! My name is {Name}";

    ~Person() => Name = string.Empty;
}
