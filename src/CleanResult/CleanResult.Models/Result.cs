using CleanResult.Models.Enums;
using CleanResult.Models.Exceptions;
using CleanResult.Models.Interfaces;

namespace CleanResult.Models;

public sealed record Result<T> : IResult<T> where T : class
{
    private readonly List<ErrorMessage> _errors = [];

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="obj">T</param>
    public Result(T obj)
    {
        Object = obj;
    }
    
    /// <summary>
    /// Object
    /// </summary>
    public T? Object { get; set; }
    
    /// <summary>
    /// Errors
    /// </summary>
    public IReadOnlyCollection<ErrorMessage> Errors => _errors.AsReadOnly();

    /// <summary>
    /// ResultType
    /// </summary>
    public ResultType ResultType
    {
        get
        {
            if (Object is null)
            {
                return ResultType.NullObject;
            }

            if (_errors.Any())
            {
                return ResultType.ContainsErrors;
            }

            return ResultType.Success;
        }
    }

    /// <summary>
    /// Adds a new error message to the errors collection.
    /// </summary>
    /// <param name="code">Code or title of the error</param>
    /// <param name="message">Message or description of the error</param>
    public void AddError(string code, string message)
    {
        _errors.Add(new ErrorMessage(code, message));
    }

    /// <summary>
    /// Throws CleanResultException when ResultType is not Success.
    /// </summary>
    /// <exception cref="CleanResultException">Throws CleanResultException when ResultType is not Success</exception>
    public void EnsureSuccessResultType()
    {
        if (ResultType is ResultType.NullObject)
        {
            throw new CleanResultException($"{nameof(T)} Object is null");
        }

        if (ResultType is ResultType.ContainsErrors)
        {
            throw new CleanResultException($"Result contains {_errors.Count} errors", Errors);
        }
    }
}