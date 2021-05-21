using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.DepartmentRepository
{
    public class DepartmentRepository : GUIDRepository<Department>, IDepartmentRepository
    {
        private SWEContext _context;
        public DepartmentRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> AllNotDeleted()
        {
            return await _context.Departments.Where(f => !f.IsDelete).ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetByName(string _Name)
        {
            return await _context.Departments.Where(f => EF.Functions.Contains(f.Name, _Name) && !f.IsDelete).ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetByFaculties(string _Name)
        {
            return await _context.Departments.Where(f => EF.Functions.Contains(f.Facultie.Name, _Name) && !f.IsDelete).ToListAsync();
        }
    }
}
