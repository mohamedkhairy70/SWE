using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SWE.UI.Repositories.DepartmentRepository
{
    public class DepartmentRepository : GUIDRepository<Department>, IDepartmentRepository
    {
        private SWEContext _context;
        public DepartmentRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Department> AllNotDeleted() => _context.Departments.Where(f => !f.IsDelete);

        public IEnumerable<Department> GetByName(string _Name) => _context.Departments.Where(f => EF.Functions.Contains(f.Name,_Name) && !f.IsDelete);
        public IEnumerable<Department> GetByFaculties(string _Name)
        {
            return _context.Departments.Where(f => EF.Functions.Contains(f.Facultie.Name, _Name) && !f.IsDelete);
        }
    }
}
