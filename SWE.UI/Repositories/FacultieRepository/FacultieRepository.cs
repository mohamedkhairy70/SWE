using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.FacultieRepository
{
    public class FacultieRepository : GUIDRepository<Facultie>,IFacultieRepository
    {
        private SWEContext _context;
        public FacultieRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Facultie>> AllNotDeleted() => await _context.Faculties.Where(f => !f.IsDelete).ToListAsync();

        public async Task<IEnumerable<Facultie>> GetByName(string _Name)
        {
            return await _context.Faculties.Where(f => EF.Functions.Contains(f.Name, _Name) && !f.IsDelete).ToListAsync();
        }
    }
}
