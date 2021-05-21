using SWE.UI.interfaces;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.DepartmentRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> AllNotDeleted();
        Task<IEnumerable<Department>> GetByName(string _Name);
        Task<IEnumerable<Department>> GetByFaculties(string _Name);
    }
}
