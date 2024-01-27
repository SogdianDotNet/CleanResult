using CleanResult.Models.Interfaces;

namespace CleanResult.Models;

public record ErrorMessage(string Code, string Message) : IErrorMessage;