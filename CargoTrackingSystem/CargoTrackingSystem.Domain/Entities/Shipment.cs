namespace CargoTrackingSystem.Domain.Entities
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string ShipmentNumber { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}
