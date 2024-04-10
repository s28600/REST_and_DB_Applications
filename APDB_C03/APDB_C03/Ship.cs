using APDB_C03.Containers;
using APDB_C03.Interfaces;

namespace APDB_C03;

public class Ship : IHazardNotifier
{
    private static int _id = 1;
    public int Id { get; }
    public double Speed { get; }
    public int MaxContainersNum { get; }
    public double MaxLoadCapacity { get; }
    public List<BaseContainer> Containers;

    public Ship(double speed, int maxContainersNum, double maxLoadCapacity)
    {
        Id = _id;
        _id++;
        Containers = new List<BaseContainer>();
        Speed = speed;
        MaxContainersNum = maxContainersNum;
        MaxLoadCapacity = maxLoadCapacity;
    }

    public void AddContainer(BaseContainer container)
    {
        double load = 0;
        foreach (var con in Containers)
        {
            load += con.Load;
        }

        if (load + container.Load > MaxLoadCapacity)
            NotifyHazard("Max load capacity exceeded. Operation blocked.");
        else
        {
            Containers.Add(container);
            Console.WriteLine("Container " + container.SerialNum + " loaded onto the ship.");
        }
    }

    public void NotifyHazard(string text)
    {
        Console.WriteLine("Dangerous operation regarding ship " + Id + ":");
        Console.WriteLine(text);
    }
}