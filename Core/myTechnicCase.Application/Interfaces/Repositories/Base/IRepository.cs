using myTechnicCase.Domain.Entity.Base;

namespace myTechnicCase.Application.Interfaces.Repositories.Base;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll();
    TEntity GetById(int id);
    bool Insert(TEntity entity);
    bool Delete(TEntity entity);
    bool Update(TEntity entity);
    bool DeleteById(int id);
}