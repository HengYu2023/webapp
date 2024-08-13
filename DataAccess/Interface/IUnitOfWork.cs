using DataAccess.Entities;

namespace DataAccess.Interface;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : BaseEntity;
    void CreateTransaction();
    void Commit();
    void Rollback();
    void Save();
}