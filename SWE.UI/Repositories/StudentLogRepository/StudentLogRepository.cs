using Microsoft.EntityFrameworkCore;
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

        public async Task<StudentLog> Register(StudentLog studentLog, string password)
        {
            
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            studentLog.PasswordHash = passwordHash;
            studentLog.PasswordSalt = passwordSalt;
            await _context.StudentLog.AddAsync(studentLog);
            return await _context.StudentLog.
                FirstOrDefaultAsync(u => u.UserName == studentLog.UserName && u.PasswordHash == passwordHash);
        }
        public async Task<StudentLog> Edit(StudentLog studentLog, string password)
        {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            studentLog.PasswordHash = passwordHash;
            studentLog.PasswordSalt = passwordSalt;
            _context.StudentLog.Update(studentLog);

            return await _context.StudentLog.
                FirstOrDefaultAsync(u => u.UserName == studentLog.UserName && u.PasswordHash == passwordHash);
        }

        public async Task<StudentLog> Login(string username, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            return await _context.StudentLog.
                FirstOrDefaultAsync(u => u.UserName == username && u.PasswordHash == passwordHash);
        }

        //public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != passwordHash[i])
        //                return false;
        //        }
        //    }
        //    return true;
        //}

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
         {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExsists(string username)
        {
            return await _context.StudentLog.AnyAsync(u => u.UserName == username);
        }
    }       
}
