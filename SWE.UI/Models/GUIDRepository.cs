using Microsoft.EntityFrameworkCore;
using SWE.UI.interfaces;
using SWE.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class GUIDRepository<T> : IRepository<T> where T : class
    {
        protected readonly SWEContext Context;
        DbSet<T> Table { get; set; }

        public GUIDRepository(SWEContext context)
        {
            Table = context.Set<T>();
            Context = context;
        }
        public void Add(T entity) => Table.Add(entity);

        public void Add(IEnumerable<T> entities) => Table.AddRange(entities);

        public IEnumerable<T> All() => Table.AsNoTracking();

        public void Delete(T entity) => Table.Remove(entity);

        public void Delete(IEnumerable<T> entities) => Table.RemoveRange(entities);

        public T GetId(int? Id) => Table.Find(Id);

        public void Update(T entity) => Table.Update(entity);

        public void Update(IEnumerable<T> entities) => Table.UpdateRange(entities);

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => Table.Where<T>(expression);
    }
}
