using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVC5_Template.Core.Contracts
{
    public interface IRepository<T, TKey> where T : class, IAuditable, IDeletable
    {
        T GetById(TKey id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
