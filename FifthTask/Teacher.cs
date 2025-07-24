namespace FifthTask;

internal class Teacher : Person
{
    public Teacher(string name) : base(name) { }

    public void Explain() => Console.WriteLine("Explain");
}
