using System;

namespace SWE.UI.Models.Domain
{
    public class StudentLog
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
