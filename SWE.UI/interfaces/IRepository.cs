using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SWE.UI.interfaces
{
    public interface IRepository<T> where T : class,IEntity
    {
        void Add(T entity);
        void Add(IEnumerable<T> entities);

        void Update(T entity);
        void Update(IEnumerable<T> entities);

        void Delete(T entity);
        void Delete(IEnumerable<T> entities);

        IEnumerable<T> All();
        T GetId(Guid Id);
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
    }
}
