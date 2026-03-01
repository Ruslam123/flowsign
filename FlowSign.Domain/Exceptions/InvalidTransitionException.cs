using System;

namespace FlowSign.Domain.Exceptions;

public class InvalidTransitionException : DomainException
{
    public DocumentStatus From { get; }
    public DocumentStatus To { get; }
    public InvalidTransitionException(DocumentStatus from, DocumentStatus to)
        : base($"Cannot transition from {from} to {to}")
    {
        From = from;
        To = to;
    }
}