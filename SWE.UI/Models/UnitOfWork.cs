using SWE.UI.interfaces;
using SWE.UI.Repositories.FacultieRepository;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly SWEContext context;
        public UnitOfWork(SWEContext context)
        {
            this.context = context;
            Facultie = new FacultieRepository(context);
        }

        public IFacultieRepository Facultie { get; private set; }

        public int Commet() => context.SaveChanges();

        public void Dispose() => context.Dispose();
    }
}
