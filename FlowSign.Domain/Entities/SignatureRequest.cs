using System;
namespace flowsing.Domain.Entities;
using flowsing.Domain.Enums;
public class SignatureRequest
{
    public Guid Id { get; private set; }
    public Guid WorkflowInstanceId { get; private set; }
    public Guid DocumentId { get; private set; }
    public Guid SignerId { get; private set; }
    public int Order { get; private set; }
    public SignatureRequestStatus Status { get; private set; }
    public DateTime? SignedAt { get; private set; }
    public string? RejectionReason { get; private set; }
    public string? DocumentVersionHash { get; private set; }

}
