using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Car_Rental.Common.Error.ErrorTracker;

namespace Car_Rental.Common.Error;

public class Error
{
    public ErrorProjects Project { get; init; }
    public ErrorSources Source { get; init; }
    public ErrorTypes Type { get; init; }
    public string Message { get; init; }
    public bool Active { get; set; }

    public override string ToString() => $"{Type}";

    public Error(ErrorProjects project, ErrorSources source, ErrorTypes type, string message)
    {
        Project = project;
        Source = source;
        Type = type;
        Message = message;
    }
}
