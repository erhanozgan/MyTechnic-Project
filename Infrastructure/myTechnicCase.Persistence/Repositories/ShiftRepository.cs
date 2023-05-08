using myTechnicCase.Application.Interfaces.Repositories;
using myTechnicCase.Domain.Entity;
using myTechnicCase.Persistence.DataContext;
using myTechnicCase.Persistence.Repositories.Base;

namespace myTechnicCase.Persistence.Repositories;

public class ShiftRepository : BaseRepository<MyTechnicDbContext, Shift> , IShiftRepository
{
    private readonly MyTechnicDbContext _myTechnicDbContext;
    public ShiftRepository(MyTechnicDbContext dbContext) : base(dbContext)
    {
        _myTechnicDbContext = dbContext;
    }   
}