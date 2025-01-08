using Grafik.Data;

namespace Grafik.Repositories;

public interface IPlanningSessionRepository
{
    bool Create(PlanningSession planningSession);
}

public class PlanningSessionRepository : IPlanningSessionRepository
{
    ApplicationDbContext _context;

    public PlanningSessionRepository(ApplicationDbContext context)
    {
        _context = context;
    }



    public bool Create(PlanningSession planningSession)
    {
        _context.PlanningSessions.Add(planningSession);
        return _context.SaveChanges() > 0;
    }
}
