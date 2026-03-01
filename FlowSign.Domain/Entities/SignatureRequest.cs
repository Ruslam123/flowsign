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

    public SignatureRequest(Guid id, Guid workflowInstanceId, Guid documentId, Guid signerId, int order, SignatureRequestStatus status, DateTime? signedAt, string? rejectionReason, string? documentVersionHash)
    {
        Id = id;
        WorkflowInstanceId = workflowInstanceId;
        DocumentId = documentId;
        SignerId = signerId;
        Order = order;
        Status = status;
        SignedAt = signedAt;
        RejectionReason = rejectionReason;
        DocumentVersionHash = documentVersionHash;
    }
}
