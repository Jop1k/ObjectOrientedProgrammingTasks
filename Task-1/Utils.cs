namespace ObjectOrientedProgrammingTasks;

internal static class Utils
{
    public static string[] CreateListOfNames(int amount)
    {
        var names = new string[amount];

        for (int i = 0; i < amount; i++)
        {
            names[i] = NameValidator.Validation();
        }

        return names;
    }

    public static void PrintEnumerable<T>(IEnumerable<T> list, string text)
    {
        foreach (var value in list)
        {
            Console.WriteLine($"{text} {value}");
        }
    }
}
