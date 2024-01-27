namespace CleanResult.Models.Exceptions;

/// <inheritdoc />
[Serializable]
public sealed class CleanResultException : Exception
{
    public readonly IReadOnlyCollection<ErrorMessage> Errors = [];

    public CleanResultException(string message) : base(message) { }

    public CleanResultException(string message, IReadOnlyCollection<ErrorMessage> errors) : base(message)
    {
        Errors = errors;
    }
}