using System;
namespace flowsing.Domain.Entities;
using flowsing.Domain.Enums;

public class AuditLog
{
    public Guid Id { get; private set; }
    public Guid? DocumentId { get; private set; }
    public Guid UserId { get; private set; }
    public ActionType ActionType { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string IpAddress { get; private set; }
    public string? Details { get; private set; }

    public AuditLog(Guid id, Guid? documentId, Guid userId, ActionType actionType, DateTime timestamp, string ipAddress, string? details)
    {
        Id = id;
        DocumentId = documentId;
        UserId = userId;
        ActionType = actionType;
        Timestamp = timestamp;
        IpAddress = ipAddress;
        Details = details;
    }
}
