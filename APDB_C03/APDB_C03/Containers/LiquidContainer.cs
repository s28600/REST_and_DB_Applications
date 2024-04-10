using APDB_C03.Exceptions;
using APDB_C03.Interfaces;

namespace APDB_C03.Containers;

public class LiquidContainer : BaseContainer, IHazardNotifier
{
    private static int _id = 1;
    private static readonly string[] DangerousTypes = {"paliwo"};
    public string LoadType { get; private set; }
    public bool IsDangerous { get; }

    public LiquidContainer(double maxLoad, double weight, double height, double depth, string loadType) : base(maxLoad, weight, height, depth) 
    {
        LoadType = loadType;
        IsDangerous = false;
        
        foreach (var type in DangerousTypes)
            if (loadType.Equals(type)) IsDangerous = true;
        
        SerialNum += "-L-" + _id;
        _id++;
    }

    public override void EmptyLoad()
    {
        Load = 0;
        Console.WriteLine("Container emptied.");
    }

    public override void AddLoad(double addedLoad)
    {
        var newLoad = Load + addedLoad;
        
        if (newLoad > MaxLoad)
            throw new OverfillException();
        
        if (IsDangerous && newLoad > MaxLoad*0.5)
            NotifyHazard("Exceeded load capacity for dangerous loads (50%). Operation blocked.");
        else if (newLoad > MaxLoad*0.9)
            NotifyHazard("Exceeded load capacity (90%). Operation blocked.");
        else {
            Load = newLoad;
            Console.WriteLine("Added " + addedLoad + "kg of load to container " + SerialNum + ". Capacity is at " + Load/MaxLoad*100 + "% now.");
        }
    }

    public void NotifyHazard(string text)
    {
        Console.WriteLine("Dangerous operation regarding container " + SerialNum + ":");
        Console.WriteLine(text);
    }
}