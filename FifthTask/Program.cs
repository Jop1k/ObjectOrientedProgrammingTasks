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
            var message = person switch
            {
                Teacher teacher => $"{teacher}: {teacher.Explain()}",
                Student student => $"{student}: {student.Study()}",
                _ => "Unknown"
            };

            Console.WriteLine(message);
        }
    }
}
