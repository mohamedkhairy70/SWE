using System;
using System.Threading.Tasks;

namespace SWE.UI.interfaces
{
    interface IUnitOfWork<T> : IDisposable where T : class,IEntity
    {
        IRepository<T> Repository { get; }

        void Commet();
    }
}
