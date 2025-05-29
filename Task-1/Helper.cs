namespace FirstTask;

internal static class Helper
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
}
