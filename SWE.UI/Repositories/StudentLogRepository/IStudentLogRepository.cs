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
        Task<StudentLog> Register(StudentLog studentLog, string password);
        Task<StudentLog> Login(string username, string password);
        Task<StudentLog> Edit(StudentLog studentLog, string password);
        //bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        Task<bool> UserExsists(string username);
    }
}
