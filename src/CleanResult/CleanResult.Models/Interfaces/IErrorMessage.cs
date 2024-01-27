namespace CleanResult.Models.Interfaces;

internal interface IErrorMessage
{
    string Code { get; init; }
    string Message { get; init; }
}