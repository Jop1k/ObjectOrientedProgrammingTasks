namespace ObjectOrientedProgrammingTasks;

internal static class Utils
{
    public static string[] CreateListOfNames(int amount)
    {
        var names = new string[amount];

        for (int i = 0; i < amount; i++)
        {
            names[i] = Validators.NameValidator();
        }

        return names;
    }
}
