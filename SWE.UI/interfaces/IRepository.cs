using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SWE.UI.interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Add(IEnumerable<T> entities);

        void Update(T entity);
        void Update(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(IEnumerable<T> entities);

        Task<IEnumerable<T>> All();
        Task<T> GetId(int? Id);
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
    }
}
