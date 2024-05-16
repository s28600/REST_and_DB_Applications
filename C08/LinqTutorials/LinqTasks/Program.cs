using LinqTasks.Models;

namespace LinqTasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======= ZAD X =======");

        var result = Tasks.Task14();

        foreach (var res in result)
        {
            Console.WriteLine(res);
        }
    }
}