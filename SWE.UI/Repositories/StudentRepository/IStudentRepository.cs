using SWE.UI.interfaces;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.StudentRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> AllNotDeleted();
        IEnumerable<Student> GetByName(string _Name);
    }
}
