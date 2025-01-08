namespace Grafik.Data;

public class ExcludedTime
{
    public Guid Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public Guid PlanningSessionId { get; set; }
    public PlanningSession? PlanningSession { get; set; }
    public string? Reason { get; set; }
}
