using System;
using System.Text.Json.Serialization;
using flowsing.Domain.Enums;
namespace flowsing.Domain.Entities;
public class Document
{
	{
        SignatureRequest = new List<SignatureRequest>();
        DocumentVersion = new List<DocumentVersion>();
	}
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid OwnerId { get; set; }
    public DocumentStatus Status { get; set; }
    public SigningType SigningType { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<DocumentVersion> DocumentVersion { get; set;
    public List<SignatureRequest> SignatureRequest { get; set; }
}
