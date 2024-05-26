namespace HardwareStore.WebApi.Services;

public class ProductHasImageException : Exception
{
    public ProductHasImageException()
    {
    }

    public ProductHasImageException(string message) : base(message)
    {
    }

    public ProductHasImageException(string message, Exception ex) : base(message, ex)
    {
    }
}