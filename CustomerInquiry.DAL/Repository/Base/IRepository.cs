using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerInquiry.DAL.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Remove(T entity);
    }
}
