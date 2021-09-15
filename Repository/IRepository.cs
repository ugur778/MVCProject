using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
    }
}
