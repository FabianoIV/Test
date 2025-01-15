using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grafik.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<PlanningSession> PlanningSessions { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<PlannerUser> PlannerUsers { get; set; }
    public DbSet<ExcludedTime> ExcludedTime { get; set; }
    public DbSet<UserHourLimit> UserHourLimit { get; set; }
    public DbSet<ReservationUserLimit> ReservationUserLimits { get; set; }
}
