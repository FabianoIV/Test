namespace Grafik.Data;

public class PlannerUser
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public string SchoolReuninionCardColor { get; set; }
    public string UnavailabilityPaidCardColor { get; set; }
    public string UnavailabilityFreeDayShiftCardColor { get; set; }
    public string UnavailabilityFreeNightShiftCardColor { get; set; }
}
