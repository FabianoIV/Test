namespace Grafik.Data;

public class ReservationUserLimit
{
    public Guid Id { get; set; }
    public Guid PlannedUserId { get; set; }
    public int UnavailabilityFreeDaysLimit { get; set; }
    public int UnavailabilityPaidDaysLimit { get; set; }
}
