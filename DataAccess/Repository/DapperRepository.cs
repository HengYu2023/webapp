using System.Data;
using DataAccess.Entities;
using DataAccess.Interface;

namespace DataAccess.Repository;

public class DapperRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbConnection _connection;

    public DapperRepository(IDbHelper dbHelper)
    {
        _connection = dbHelper.GetConnection();
    }


    public void Insert(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }
}