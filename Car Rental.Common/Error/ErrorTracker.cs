using System.Data;
using System.Linq.Expressions;

namespace Car_Rental.Common.Error;

public class ErrorTracker
{
    readonly List<Error> _errors = new();

    public void AddError(Error error)
    {
        if (GetError(e => e.Type == error.Type) is not null)
            throw new InvalidOperationException("Error type already exists");
        _errors.Add(error);
    }

    public Error? GetError(Func<Error, bool> expression) => _errors.SingleOrDefault(expression);

    public List<Error> GetErrors(Func<Error, bool> expression) =>
        _errors.Where(expression).ToList();

    public void ActivateError(ErrorTypes type, Exception? ex = null)
    {
        Error error = _errors.Single(e => e.Type == type);
        error.Active = true;
        if (error.LoggingIsActive)
        {
            Log(type, ex);
        }
    }

    static void Log(ErrorTypes type, Exception? ex)
    {
        Console.WriteLine($"ERROR: {type} {ex?.Message}");
    }

    public void InactivateError(ErrorTypes type) =>
        _errors.Single(e => e.Type == type).Active = false;

    public void InactivateErrors(ErrorSources source) =>
        _errors.FindAll(e => e.Source == source).ForEach(e => e.Active = false);
}
