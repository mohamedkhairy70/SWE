using SWE.UI.interfaces;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.CourseRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> AllNotDeleted();
        Task<IEnumerable<Course>> GetByName(string _Name);
    }
}
