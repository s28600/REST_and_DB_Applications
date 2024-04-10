namespace APDB_C03.Exceptions;

public class UnsupportedProductException : Exception
{
    public UnsupportedProductException() : base("Product is not supported.") {}
}