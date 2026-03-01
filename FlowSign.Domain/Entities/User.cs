using System;
namespace flowsing.Domain.Entities;
using flowsing.Domain.Enums;
public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FullName { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(Guid id, string email, string passwordHash, string fullName, UserRole role, bool isActive, DateTime createdAt)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        FullName = fullName;
        Role = role;
        IsActive = isActive;
        CreatedAt = createdAt;
    }
}
