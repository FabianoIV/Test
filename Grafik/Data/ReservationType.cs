using System.ComponentModel.DataAnnotations;

namespace Grafik.Data;

public enum ReservationType
{
    [Display(Description = "Niedostępność Płatna")]
    UnavailabilityPaid,
    [Display(Description = "Zjazd")]
    SchooolReunion,
    [Display(Description = "Niedostępność Bezpłatna")]
    UnavailabilityFree,
}
