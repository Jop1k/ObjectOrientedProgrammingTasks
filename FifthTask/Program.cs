using Helper;

namespace FifthTask;

internal class Program
{
    static void Main()
    {
        var names = Enumerable.Range(0, 3)
            .Select(_ => ConsoleHelper.TryReadValidName())
            .ToArray();

        Person[] persons = [new Teacher(names[0]), new Student(names[1]), new Student(names[2])];

        foreach (var person in persons)
        {
            if (person is Teacher teacher)
            {
                teacher.Explain();
            }
            else if (person is Student student)
            {
                student.Study();
            }
        }
    }
}
