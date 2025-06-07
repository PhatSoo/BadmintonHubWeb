namespace BadmintonHubWeb.Models
{
    public class CourtViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal PricePerHour { get; set; }
    }
}
