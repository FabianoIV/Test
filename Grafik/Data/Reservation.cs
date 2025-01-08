using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grafik.Data;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid PlanningSessionId { get; set; }
    public ReservationType Type { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public Guid PlannerUserId { get; set; }
    public PlannerUser? PlannerUser { get; set; }
    public string? Comment { get; set; }

    [NotMapped]
    public string CalendarDescription
    {
        get
        {
            var typeDisplay = Type.GetType()
                                  .GetField(Type.ToString())
                                  ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                                  .FirstOrDefault() as DisplayAttribute;
            var typeDescription = typeDisplay?.Description ?? Type.ToString();
            return $"{typeDescription} rezerwacja od {From:yyyy-MM-dd HH:mm} do {To:yyyy-MM-dd HH:mm} przez {PlannerUser?.Name ?? "Nieznany"}";
        }
    }

    public override string ToString()
    {
        return CalendarDescription;
    }
}
