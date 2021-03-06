using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.CourseRepository
{
    public class CourseRepository : GUIDRepository<Course>, ICourseRepository
    {
        private SWEContext _context;
        public CourseRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> AllNotDeleted() => await _context.Courses.Include(x=>x.Department).Where(f => !f.IsDelete).ToListAsync();

        public async Task<IEnumerable<Course>> GetByName(string _Name)
        {
            return await _context.Courses.Include(x => x.Department).Where(f => EF.Functions.Contains(f.Name, _Name) && !f.IsDelete).ToListAsync();
        }
    }
}
