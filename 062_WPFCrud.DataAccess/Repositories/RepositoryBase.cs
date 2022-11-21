using _062_WPFCrud.DataAccess.Context;
using _062_WPFCrud.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _062_WPFCrud.DataAccess.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        public WPFCrudEntities _db;

        public RepositoryBase()
        {
            this._db = new WPFCrudEntities();
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _db.Set<TEntity>().Remove(entity);
                return _db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //Hacer algo con la excepción aquí, como por ejemplo, guardarla en algún log
                //throw ex;
                return false;
            }
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public TEntity Get(int id)
        {
            try
            {
                return _db.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                //Hacer algo con la excepción aquí, como por ejemplo, guardarla en algún log
                return null;
            }            
        }

        public List<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public bool Insert(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return _db.SaveChanges() > 0;
        }
    }
}
