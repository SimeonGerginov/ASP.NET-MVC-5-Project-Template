using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

using Bytes2you.Validation;

using MVC5_Template.Core.Contracts;
using MVC5_Template.Core.Entities;

namespace MVC5_Template.Persistence.Data.Repositories
{
    public class EfRepository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly IDbSet<T> _dbSet;
        private readonly MsSqlDbContext _dbContext;

        public EfRepository(MsSqlDbContext context)
        {
            Guard.WhenArgument(context, "Context").IsNull().Throw();

            this._dbContext = context;
            this._dbSet = this._dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;

            var entry = this._dbContext.Entry(entity);
            this.AttachEntity(entry, entity);

            entry.State = EntityState.Modified;
        }

        public IEnumerable<T> GetAll()
        {
            return this._dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression)
        {
            return this._dbSet
                .Where(filterExpression)
                .AsEnumerable();
        }

        public T GetById(TKey id)
        {
            return this._dbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this._dbContext.Entry(entity);
            this.AttachEntity(entry, entity);

            entry.State = EntityState.Modified;
        }

        private void AttachEntity(DbEntityEntry<T> entry, T entity)
        {
            if (entry.State == EntityState.Detached)
            {
                this._dbSet.Attach(entity);
            }
        }
    }
}
