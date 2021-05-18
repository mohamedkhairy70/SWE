using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SWE.UI.Repositories.FacultieRepository
{
    public class FacultieRepository : GUIDRepository<Facultie>,IFacultieRepository
    {
        private SWEContext _context;
        public FacultieRepository(SWEContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Facultie> AllNotDeleted() => _context.Faculties.Where(f => !f.IsDelete);

        public IEnumerable<Facultie> GetByName(string _Name) => _context.Faculties.Where(f => EF.Functions.Contains(f.Name,_Name) && !f.IsDelete);

    }
}
