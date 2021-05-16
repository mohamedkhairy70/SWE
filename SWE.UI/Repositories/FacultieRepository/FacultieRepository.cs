using SWE.UI.Models;
using SWE.UI.Models.Domain;

namespace SWE.UI.Repositories.FacultieRepository
{
    public class FacultieRepository : GUIDRepository<Facultie>,IFacultieRepository
    {
        public FacultieRepository(SWEContext context):base(context)
        {
                
        }
    }
}
