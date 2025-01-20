namespace Grafik.Data;

public class UserHourLimit
{
    public Guid Id { get; set; }
    public Guid PlanningSessionId { get; set; }
    public PlanningSession PlanningSession { get; set; }
    public Guid PlannerUserId { get; set; }
    public PlannerUser PlannerUser { get; set; }

    public int UnavailabilityPaidHoursLimit { get; set; }
    public int UnavailabilityFreeHoursLimit { get; set; }
}