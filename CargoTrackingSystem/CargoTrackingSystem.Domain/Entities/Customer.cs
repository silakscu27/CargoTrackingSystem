namespace CargoTrackingSystem.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
    }
}
