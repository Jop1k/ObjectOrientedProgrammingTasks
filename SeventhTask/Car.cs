namespace SeventhTask;

internal class Car : IVehiculo
{
    public int Benzine { get; private set; }

    public Car(int startBenzine = 0)
    {
        Benzine = startBenzine;
    }

    public void Drive()
    {
        if (Benzine > 0)
        {
            Console.WriteLine("Driving");
        }
    }

    public bool Refuel(int amountOfBenzine)
    {
        Benzine += amountOfBenzine;
        return true;
    }
}
