namespace ObjectOrientedProgrammingTasks;

internal class Person
{
    public string Name { get; init; }

    public Person (string name) => Name = name;

    public override string ToString() => Name;
}
