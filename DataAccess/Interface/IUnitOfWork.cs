namespace DataAccess.Interface;

public interface IUnitOfWork
{
    void CreateTransaction();
    void Commit();
    void Rollback();
    void Save();
}