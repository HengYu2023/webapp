using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private IDbContextTransaction? _tran;

    public UnitOfWork(DbContext context)
    {
        _context = context;
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