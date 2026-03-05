namespace FlowSign.Infrastructure.Persistence;
using FlowSign.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class FlowSignDbContext : DbContext
{
    public DbSet <User> Users { get; set; }
    public DbSet <Document> Documents { get; set; }
    public DbSet <DocumentVersion> DocumentVersions { get; set; }
    public DbSet <WorkflowInstance> WorkflowInstances { get; set; }
    public DbSet <SignatureRequest> SignatureRequests { get; set; }
    public DbSet <AuditLog> AuditLogs { get; set; }

    public FlowSignDbContext(DbContextOptions<FlowSignDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlowSignDbContext).Assembly);
    }

}
