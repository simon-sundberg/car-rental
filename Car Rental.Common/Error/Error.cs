using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Error;

public class Error
{
    public ErrorProjects Project { get; init; }
    public ErrorSources Source { get; init; }
    public ErrorTypes Type { get; init; }
    public string Message { get; init; }
    public bool LoggingIsActive { get; init; }
    public bool Active { get; set; }

    public override string ToString() => $"{Type}";

    public Error(
        ErrorTypes type,
        string message,
        ErrorProjects project = ErrorProjects.None,
        ErrorSources source = ErrorSources.None,
        bool loggingIsActive = false
    )
    {
        Type = type;
        Message = message;
        Project = project;
        Source = source;
        LoggingIsActive = loggingIsActive;
    }
}
