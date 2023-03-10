namespace NextBus_API.Models.DTO
{
    public class UpdateConductorRequest
    {
        public string? Name { get; set; }
        public string? NIC { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Mobile3 { get; set; }
        public string? Email { get; set; }
        public string? RegDate { get; set; }
    }
}
