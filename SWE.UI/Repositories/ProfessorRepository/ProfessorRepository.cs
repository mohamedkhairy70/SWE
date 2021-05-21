using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.ProfessorRepository
{
    public class ProfessorRepository : GUIDRepository<Professor>, IProfessorRepository
    {
        private SWEContext _context;
        public ProfessorRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professor>> AllNotDeleted() => await _context.Professores.Where(f => !f.IsDelete).ToListAsync();

        public async Task<IEnumerable<Professor>> GetByName(string _Name)
        {
            return await _context.Professores
                .Where(f => EF.Functions.Contains(f.Name, _Name) && !f.IsDelete).ToListAsync();
        }
    }
}
