using SWE.UI.Repositories.FacultieRepository;
using System;
using System.Threading.Tasks;

namespace SWE.UI.interfaces
{
    interface IUnitOfWork : IDisposable 
    {
        IFacultieRepository Facultie { get; }
        int Commet();
    }
}
