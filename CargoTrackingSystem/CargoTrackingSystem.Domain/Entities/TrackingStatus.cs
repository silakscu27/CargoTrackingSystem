namespace CargoTrackingSystem.Domain.Entities
{
    public class TrackingStatus
    {
        public int TrackingStatusId { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public DateTime StatusDate { get; set; }
        public string Status { get; set; }
    }
}
