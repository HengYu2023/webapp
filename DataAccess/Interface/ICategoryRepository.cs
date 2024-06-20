using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Category GetById(int ctgId);
        IQueryable<Category> GetAll();
        void SaveChanges();
    }
}
