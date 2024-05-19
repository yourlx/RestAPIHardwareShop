namespace HardwareStore.WebApi.Data;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException()
    {
    }

    public ProductNotFoundException(string message) : base(message)
    {
    }

    public ProductNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}