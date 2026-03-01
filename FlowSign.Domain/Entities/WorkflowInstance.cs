using System;
namespace flowsing.Domain.Entities;
using flowsing.Domain.Enums;
public class WorkflowInstance
{
    public Guid Id { get; private set; }
    public Guid DocumentId { get; private set; }
    private SigningType SigningType { get; private set; }
    private WorkflowStatus Status { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime CompletedAt { get; private set; }
}
