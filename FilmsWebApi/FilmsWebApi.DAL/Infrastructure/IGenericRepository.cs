using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace FilmsWebApi.DAL.Infrastructure
{
    public interface IGenericRepository<TEntity>
    {
        ICollection<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);

        TEntity GetById(int id);

        void Add(TEntity newModel);

        void AddOrUpdate(TEntity newModel);

        void Delete(int id);

        void Delete(TEntity entity);
        
    }
}
