namespace HardwareStore.WebApi.Data;

public class ClientNotFoundException : Exception
{
    public ClientNotFoundException()
    {
    }

    public ClientNotFoundException(string message) : base(message)
    {
    }

    public ClientNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}