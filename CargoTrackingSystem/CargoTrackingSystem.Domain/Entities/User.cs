using CargoTrackingSystem.Domain.Abstractions;

namespace CargoTrackingSystem.Domain.Entities;

public sealed class User : Entity
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty; // örn: Admin, Customer
    public bool IsActive { get; set; } = true;

    // Relations
    public Customer? Customer { get; set; } // 1:1 Customer
}
