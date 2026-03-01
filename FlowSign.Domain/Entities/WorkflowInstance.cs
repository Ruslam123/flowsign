using System;
namespace flowsing.Domain.Entities;
using flowsing.Domain.Enums;
public class WorkflowInstance
{
    public Guid Id { get; private set; }
    public Guid DocumentId { get; private set; }
    public SigningType SigningType { get; private set; }
    public WorkflowStatus Status { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    public WorkflowInstance(Guid id, Guid documentId, SigningType signingType, WorkflowStatus status, DateTime startedAt, DateTime? completedAt)
    {
        Id = id;
        DocumentId = documentId;
        SigningType = signingType;
        Status = status;
        StartedAt = startedAt;
        CompletedAt = completedAt;
    }
}
