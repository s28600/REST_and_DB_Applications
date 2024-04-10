using APDB_C03.Interfaces;
using APDB_C03.Exceptions;

namespace APDB_C03.Containers;

public class GasContainer : BaseContainer, IHazardNotifier
{
    private static int _id = 1;
    public double Psi { get; }
    public GasContainer(double maxLoad, double weight, double height, double depth) : base(maxLoad, weight, height, depth)
    {
        SerialNum += "-G-" + _id;
        _id++;
    }

    public override void EmptyLoad()
    {
        Load *= 0.05;
        Console.WriteLine("Container emptied.");
    }

    public override void AddLoad(double addedLoad)
    {
        var newLoad = Load + addedLoad;
        
        if (newLoad > MaxLoad)
            throw new OverfillException();
    }

    public void NotifyHazard(string text)
    {
        Console.WriteLine("Dangerous operation regarding container " + SerialNum + ":");
        Console.WriteLine(text);
    }
}