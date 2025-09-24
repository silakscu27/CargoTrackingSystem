namespace CargoTrackingSystem.Domain.Entities
{
    public class Package
    {
        public int PackageId { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; }

        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public ICollection<TrackingStatus> TrackingStatuses { get; set; }
    }
}
