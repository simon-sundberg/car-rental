namespace Car_Rental.Common.Error;

public class Error
{
    public Error(
        ErrorTypes type,
        string message,
        ErrorProjects project = ErrorProjects.None,
        ErrorSources source = ErrorSources.None,
        bool logging = false
    )
    {
        Type = type;
        Message = message;
        Project = project;
        Source = source;
        Logging = logging;
    }

    public bool Active { get; set; }
    public bool Logging { get; init; }
    public string Message { get; init; }
    public ErrorProjects Project { get; init; }
    public ErrorSources Source { get; init; }
    public ErrorTypes Type { get; init; }

    public override string ToString() => $"{Type}";
}
