namespace CargoTrackingSystem.Domain.Enums;

public enum ShipmentStatus
{
    Pending,        // Gönderi oluşturuldu ama henüz işlenmedi
    InTransit,      // Taşıma sürecinde
    Delivered,      // Teslim edildi
    Cancelled,      // İptal edildi
    Returned        // İade edildi
}
