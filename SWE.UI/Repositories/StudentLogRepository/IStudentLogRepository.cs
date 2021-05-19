using SWE.UI.interfaces;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.StudentLogRepository
{
    public interface IStudentLogRepository : IRepository<StudentLog>
    {
        bool Register(StudentLog studentLog, string password);
        StudentLog Login(string username, string password);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool UserExsists(string username);
    }
}
