namespace CargoTrackingSystem.Domain.Enums;

public enum TransferStatus
{
    Scheduled,      // Planlandı
    InProgress,     // Transfer devam ediyor
    Completed,      // Transfer tamamlandı
    Cancelled       // Transfer iptal edildi
}
