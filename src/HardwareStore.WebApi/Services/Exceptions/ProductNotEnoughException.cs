namespace HardwareStore.WebApi.Services;

public class ProductNotEnoughException : Exception
{
    public ProductNotEnoughException()
    {
    }

    public ProductNotEnoughException(string message) : base(message)
    {
    }

    public ProductNotEnoughException(string message, Exception ex) : base(message, ex)
    {
    }
}