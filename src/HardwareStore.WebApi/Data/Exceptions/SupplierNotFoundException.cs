namespace HardwareStore.WebApi.Data;

public class SupplierNotFoundException : Exception
{
    public SupplierNotFoundException()
    {
    }

    public SupplierNotFoundException(string message) : base(message)
    {
    }

    public SupplierNotFoundException(string message, Exception ex) : base(message, ex)
    {
    }
}