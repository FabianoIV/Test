namespace Grafik.Data;

public class PlanningSession
{
    public Guid Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }

    public List<Reservation> Reservations { get; set; }
}
