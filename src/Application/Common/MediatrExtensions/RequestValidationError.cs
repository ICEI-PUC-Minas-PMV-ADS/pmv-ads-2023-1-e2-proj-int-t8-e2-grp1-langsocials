using FluentResults;

namespace Application.Common.MediatrExtensions;

public class RequestValidationError : Error
{
    public required Dictionary<string, string[]> FieldErrorsDictionary { get; set; }
}
