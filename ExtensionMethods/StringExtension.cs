namespace ExtensionMethods;

public static class StringExtension
{
    public static string Сapitalize(this string str) => str.Length > 0 ? char.ToUpper(str[0]) + str[1..].ToLower() : "";
}
