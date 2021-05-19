using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Repositories.StudentLogRepository
{
    public class StudentLogRepository : GUIDRepository<StudentLog>, IStudentLogRepository
    {

        private SWEContext _context;
        public StudentLogRepository(SWEContext context) : base(context)
        {
            _context = context;
        }

        public bool Register(StudentLog studentLog, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            studentLog.PasswordHash = passwordHash;
            studentLog.PasswordSalt = passwordSalt;

            return false;
        }


        public StudentLog Login(string username, string password)
        {
            object[] parameters = { username, password };
            //var spQuery = "LoginUser {0},{1}";
            //var user = _repository.ExecuteQuerySingle(spQuery, parameters);

            //byte[] userByte = user.PasswordSalt.ToArray();

            //if (!VerifyPasswordHash(password, user.PasswordSalt, user.PasswordSalt))
            //    return null;

            return null;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
         {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool UserExsists(string username)
        {
            object[] parameters = { username };
            return false;
        }
    }       
}
