using SWE.UI.interfaces;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.FacultieRepository
{
    public interface IFacultieRepository : IRepository<Facultie>
    {
        Task<IEnumerable<Facultie>> AllNotDeleted();
        Task<IEnumerable<Facultie>> GetByName(string _Name);
    }
}
