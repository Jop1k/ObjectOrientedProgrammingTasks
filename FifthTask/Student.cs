namespace FifthTask;

internal class Student : Person
{
    public Student(string name) : base(name) { }

    public void Study() => Console.WriteLine("Study");
}
