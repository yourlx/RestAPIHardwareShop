namespace HardwareStore.WebApi.Data;

public class AddressNotFoundException : Exception
{
    public AddressNotFoundException()
    {
    }

    public AddressNotFoundException(string message) : base(message)
    {
    }

    public AddressNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}