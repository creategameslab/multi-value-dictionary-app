namespace App.Core.Exceptions;

public class InvalidParameterException : Exception
{
    public InvalidParameterException() : base("One or more inputs were not valid or missing.") { }
    public InvalidParameterException(string message) : base(message) { }
}
