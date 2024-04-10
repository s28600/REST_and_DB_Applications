using APDB_C03.Exceptions;

namespace APDB_C03.Containers;

public class CooledContainer : BaseContainer
{
    private static int _id = 1;
    private static readonly Dictionary<string, double> TempsDictionary = new()
    {
        {"bananas", 13.3},
        {"chocolate", 18},
        {"fish", 2},
        {"meat", -15},
        {"ice cream", -18},
        {"frozen pizza", -30}, 
        {"cheese", 7.2},
        {"sausages", 5}, 
        {"butter", 20.5},
        {"eggs", 19}
    };
    public string LoadType { get; }
    public double Temp { get; }
    public CooledContainer(double maxLoad, double weight, double height, double depth, string loadType) : base(maxLoad, weight, height, depth)
    {
        foreach (var type in TempsDictionary.Keys)
        {
            if (loadType.Equals(type))
            {
                LoadType = loadType;
                Temp = TempsDictionary[loadType];
            }
        }

        if (LoadType == null)
        {
            throw new UnsupportedProductException();
        }
        
        SerialNum += "-G-" + _id;
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
    }
}