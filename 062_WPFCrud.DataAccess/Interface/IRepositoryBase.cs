using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _062_WPFCrud.DataAccess.Interface
{
    public interface IRepositoryBase<TEntity>
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        List<TEntity> GetAll();
        TEntity Get(int id);
    }
}
