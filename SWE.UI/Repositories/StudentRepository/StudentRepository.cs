using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SWE.UI.Repositories.StudentRepository
{
    public class StudentRepository : GUIDRepository<Student>, IStudentRepository
    {
        private SWEContext _context;
        public StudentRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Student> AllNotDeleted() => _context.Studentes.Where(f => !f.IsDelete);

        public IEnumerable<Student> GetByName(string _Name)
        {
            return _context.Studentes
                .Where(f => EF.Functions.Contains(f.FullName, _Name) && !f.IsDelete);
        }
    }
}
