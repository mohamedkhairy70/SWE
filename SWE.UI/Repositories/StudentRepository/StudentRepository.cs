using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.StudentRepository
{
    public class StudentRepository : GUIDRepository<Student>, IStudentRepository
    {
        private SWEContext _context;
        public StudentRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> AllNotDeleted() => await _context.Studentes.Where(f => !f.IsDelete).ToListAsync();

        public async Task<IEnumerable<Student>> GetByName(string _Name)
        {
            return await _context.Studentes
                .Where(f => EF.Functions.Contains(f.FullName, _Name) && !f.IsDelete).ToListAsync();
        }
    }
}
