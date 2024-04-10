namespace APDB_C03.Exceptions;

public class OverfillException : Exception
{
    public OverfillException() : base("Max load capacity exceeded.") {}
}