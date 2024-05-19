namespace HardwareStore.WebApi.Data;

public class ImageNotFoundException : Exception
{
    public ImageNotFoundException()
    {
    }

    public ImageNotFoundException(string message) : base(message)
    {
    }

    public ImageNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}