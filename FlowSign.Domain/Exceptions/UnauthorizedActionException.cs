using System;
namespace FlowSign.Domain.Exceptions;

public class UnauthorizedActionException : DomainException
{
    public string Action { get; }
    public UnauthorizedActionException(string action)
     : base($"Action '{action}' is not permitted")
    {
        Action = action;
    }
}
