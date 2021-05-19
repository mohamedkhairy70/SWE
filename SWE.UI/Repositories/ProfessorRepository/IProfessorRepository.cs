using SWE.UI.interfaces;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.ProfessorRepository
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        IEnumerable<Professor> AllNotDeleted();
        IEnumerable<Professor> GetByName(string _Name);
    }
}
