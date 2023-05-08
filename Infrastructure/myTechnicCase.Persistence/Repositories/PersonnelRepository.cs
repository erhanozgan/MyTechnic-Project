using myTechnicCase.Application.Interfaces.Repositories;
using myTechnicCase.Domain.Entity;
using myTechnicCase.Persistence.DataContext;
using myTechnicCase.Persistence.Repositories.Base;

namespace myTechnicCase.Persistence.Repositories;

public class PersonnelRepository : BaseRepository<MyTechnicDbContext, Personnel> , IPersonnelRepository
{
    private readonly MyTechnicDbContext _myTechnicDbContext;
    public PersonnelRepository(MyTechnicDbContext dbContext) : base(dbContext)
    {
        _myTechnicDbContext = dbContext;
    }   
}