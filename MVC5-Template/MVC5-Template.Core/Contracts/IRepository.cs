using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using MVC5_Template.Core.Entities;

namespace MVC5_Template.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
