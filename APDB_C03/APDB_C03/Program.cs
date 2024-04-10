using APDB_C03.Containers;

namespace APDB_C03;

class Program
{
    static void Main(string[] args)
    {
        LiquidContainer l1 = new LiquidContainer(20000, 3.5, 200, 900, "paliwo");
        l1.AddLoad(15000);
        LiquidContainer l2 = new LiquidContainer(20000, 3.5, 200, 900, "paliwo");
        l2.AddLoad(10000);
        l2.AddLoad(1000);
        LiquidContainer l3 = new LiquidContainer(20000, 3.5, 200, 900, "mleko");
        l3.AddLoad(18000);
        l3.AddLoad(1000);
        Console.WriteLine(l3.IsDangerous);
        LiquidContainer l4 = new LiquidContainer(20000, 3.5, 200, 900, "mleko");
        Console.WriteLine(l4.Load);
    }
}