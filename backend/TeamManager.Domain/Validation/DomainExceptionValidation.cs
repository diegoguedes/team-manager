namespace TeamManager.Domain.Validation;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)
    { }

    public static void When(bool haError, string error)
    {
        if (haError)
            throw new DomainExceptionValidation(error);
    }
}