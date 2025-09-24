namespace CargoTrackingSystem.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
