namespace Task5Inheritance;

internal class Teacher : Person
{
    public Teacher(string name) : base(name) { }

    public string Explain() => "Explain";
}
