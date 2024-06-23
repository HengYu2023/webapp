using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Save();
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
