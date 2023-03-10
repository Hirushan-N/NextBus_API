using System.ComponentModel.DataAnnotations;

namespace NextBus_API.Models.Entities
{
    public class Conductor
    {
        public Guid Id { get; set; }
        [Key]
        public string? ConductorCode { get; set; } // Prefix = CDC
        public BusOwner BusOwner { get; set; }
        public string? Name { get; set; }
        public string? NIC { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Mobile3 { get; set; }
        public string? Email { get; set; }
        public string? RegDate { get; set; }
    }
}
