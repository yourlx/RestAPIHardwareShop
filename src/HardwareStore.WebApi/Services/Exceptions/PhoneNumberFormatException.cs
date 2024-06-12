namespace HardwareStore.WebApi.Services;

public class PhoneNumberFormatException : Exception
{
    public PhoneNumberFormatException()
    {
    }

    public PhoneNumberFormatException(string message) : base(message)
    {
    }

    public PhoneNumberFormatException(string message, Exception ex) : base(message, ex)
    {
    }
}