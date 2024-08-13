using DataAccess.Entities;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWork;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private IDbContextTransaction? _tran;
    private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public EFUnitOfWork(DbContext context)
    {
        _context = context;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new EFRepository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public void CreateTransaction()
    {
        _tran = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        if (_tran == null)
        {
            throw new Exception();
        }
        _tran.Commit();
    }

    public void Rollback()
    {
        if (_tran == null)
        {
            throw new Exception();
        }
        _tran.Rollback();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}