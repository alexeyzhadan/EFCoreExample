using EFCoreExample.DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreExample.DAL.Repositories.Interfaces
{
    //Only Get, Add, Remove methods
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);    
    }
}