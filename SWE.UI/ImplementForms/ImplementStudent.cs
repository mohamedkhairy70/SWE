using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System;
using System.Threading.Tasks;

namespace SWE.UI.ImplementForms
{
    public class ImplementStudent
    {
        private int resultCommet =0;

        public async Task<bool> Updated(Student _student, StudentLog _studentLog, string password)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
                {
                    var _studentLogResult = await work.StudentLog.Edit(_studentLog, password);

                    _student.StudentLog = _studentLogResult;

                    resultCommet = await work.Commet();
                }
                if (resultCommet == 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        public async Task<bool> Deleted(int _IdStudent, string _FullName, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
                {
                    work.Student.Update(new Student
                    {
                        Id = _IdStudent,
                        FullName = _FullName,
                        IsDelete = _IsDelete
                    });

                    await work.Commet();
                }
                if (resultCommet == 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        public async Task<bool> Add(Student _student,StudentLog _studentLog,string password)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
                {
                   var _studentLogResult = await work.StudentLog.Register(_studentLog, password);

                    _student.StudentLog = _studentLog;

                    await work.Student.Add(_student);

                    await work.Commet();
                }
                if (resultCommet == 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }

        }
    }
}
