using myTechnicCase.Application.Interfaces.Repositories;
using myTechnicCase.Domain.Entity;
using myTechnicCase.Persistence.DataContext;
using myTechnicCase.Persistence.Repositories.Base;

namespace myTechnicCase.Persistence.Repositories;

public class TeamRepository : BaseRepository<MyTechnicDbContext, Team> , ITeamRepository
{
    private readonly MyTechnicDbContext _myTechnicDbContext;
    public TeamRepository(MyTechnicDbContext dbContext) : base(dbContext)
    {
        _myTechnicDbContext = dbContext;
    }   
}