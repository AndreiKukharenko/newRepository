using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Models;

namespace FilmsWebApi.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AppContext _appContext;

        private readonly IDbSet<TEntity> _currentDbSet;

        public BaseRepository(AppContext appContext)
        {
            _appContext = appContext;
            _currentDbSet = appContext.Set<TEntity>();
        }

        protected IDbSet<TEntity> CurrentDbSet
        {
            get
            {
                return _currentDbSet;
            }
        }

        public ICollection<TEntity> GetAll()
        {
            return CurrentDbSet.ToList();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity,bool>> filter)
        {
            IQueryable<TEntity> query = _currentDbSet.Where(filter);
            return query;
        }

        public TEntity GetById (int id)
        {
            return CurrentDbSet.Find(id);
        }
        
        public void Add(TEntity newModel)
        {
            CurrentDbSet.Add(newModel);
        }

        public void AddOrUpdate(TEntity newModel)
        {
            if (newModel == null)
            {
                throw new ArgumentNullException(nameof(newModel));
            }
            var existingModel = GetById(newModel.Id);
            if(existingModel == null)
            {
                Add(newModel);
            }
            else
            {
                _appContext.Entry(existingModel).CurrentValues.SetValues(newModel); // can be picked out in a separate method Update();
                // views must contain all properties: see https://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record
            }
            _appContext.SaveChanges();
        }

        public void Delete(int id)
        {
            CurrentDbSet.Remove(GetById(id));
            _appContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Delete(entity.Id);
        }
    }
}
