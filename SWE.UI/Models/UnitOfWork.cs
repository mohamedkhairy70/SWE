using SWE.UI.interfaces;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private readonly SWEContext context;
        public UnitOfWork(SWEContext context)
        {
            this.context = context;
            Repository = new Repository<T>(context);
        }
        public IRepository<T> Repository { get; }

        public void Commet() => context.SaveChanges();

        public void Dispose() => context.Dispose();
    }
}
