namespace APDB_C03.Containers;

public abstract class BaseContainer(double maxLoad, double weight, double height, double depth)
{
    public double MaxLoad { get; } = maxLoad;
    public double Weight { get; } = weight;
    public double Height { get; } = height;
    public double Depth { get; } = depth;
    public double Load { get; set; }
    public string SerialNum { get; set; } = "KON";

    public abstract void EmptyLoad();
    public abstract void AddLoad(double addedLoad);
}