using CleanResult.Models.Enums;

namespace CleanResult.Models.Interfaces;

internal interface IResult<T> where T : class
{
    T? Object { get; set; }
    IReadOnlyCollection<ErrorMessage> Errors { get; }
    ResultType ResultType { get; }
    void AddError(string code, string message);
}