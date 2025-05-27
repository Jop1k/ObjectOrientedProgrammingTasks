namespace ObjectOrientedProgrammingTasks;

class Program
{
    static void Main()
    {
        int amount = NumberValidator.Validation("Введите количество создаваемых вами Person: ");

        var persons = Utils.CreateListOfNames(amount).Select(name => new Person(name));

        Utils.PrintEnumerable(persons, "Привет! Меня зовут");
    }
}