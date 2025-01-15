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
            if (Type == ReservationType.UnavailabilityPaid)
            {
                return $"{PlannerUser?.Name ?? "Nieznany"}: Niedostępność płatna za dzień {From.Date:yyyy-MM-dd} (Zmiana dzienna i nocna)";
            }
            else if (Type == ReservationType.UnavailabilityFree)
            {
                var shiftText = From.Hour == 7 ? "zmiana dzienna" : "zmiana nocna";
                return $"{PlannerUser?.Name ?? "Nieznany"}: Niedostępność bezpłatna ({shiftText}) w dniu {From.Date:yyyy-MM-dd}";
            }
            else if (Type == ReservationType.SchooolReunion)
            {
                return $"{PlannerUser?.Name ?? "Nieznany"}: zjazd od {From.Date:yyyy-MM-dd} do {To.Date:yyyy-MM-dd}";
            }

            var typeDisplay = Type.GetType()
                      .GetField(Type.ToString())
                      ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                      .FirstOrDefault() as DisplayAttribute;
            var typeDescription = typeDisplay?.Description ?? Type.ToString();
            return $"{typeDescription} rezerwacja od {From:yyyy-MM-dd HH:mm} do {To:yyyy-MM-dd HH:mm} przez {PlannerUser?.Name ?? "Nieznany"}";
        }
    }

    [NotMapped]
    public bool IsDayShift { get { return From.Hour == 7; } }
    [NotMapped]
    public bool IsNightShift { get { return From.Hour == 19; } }

    public override string ToString()
    {
        return CalendarDescription;
    }
}
