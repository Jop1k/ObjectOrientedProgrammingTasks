namespace ObjectOrientedProgrammingTasks;

internal static class Creator
{
    public static string[] CreateListOfNames(int count)
    {
        var names = new string[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите {i + 1} имя: ");
            names[i] = Validators.NameValidator();
        }

        return names;
    }
}
