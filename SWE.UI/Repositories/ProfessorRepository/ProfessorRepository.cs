using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SWE.UI.Repositories.ProfessorRepository
{
    public class ProfessorRepository : GUIDRepository<Professor>, IProfessorRepository
    {
        private SWEContext _context;
        public ProfessorRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Professor> AllNotDeleted() => _context.Professores.Include(f=>f.Department).Where(f => !f.IsDelete);

        public IEnumerable<Professor> GetByName(string _Name)
        {
            return _context.Professores.Include(f => f.Department)
                .Where(f => EF.Functions.Contains(f.Name, _Name) && !f.IsDelete);
        }
    }
}
