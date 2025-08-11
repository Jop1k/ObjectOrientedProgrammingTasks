namespace Task8AbstractAnimal;

internal abstract class Animal
{
    public required string Name { get; init; }

    public abstract void Eat();
}
