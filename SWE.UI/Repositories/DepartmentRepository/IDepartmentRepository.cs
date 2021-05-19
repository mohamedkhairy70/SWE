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
        IEnumerable<Department> AllNotDeleted();
        IEnumerable<Department> GetByName(string _Name);
        IEnumerable<Department> GetByFaculties(string _Name);
    }
}
