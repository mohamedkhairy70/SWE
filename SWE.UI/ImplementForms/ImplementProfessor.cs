using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Threading.Tasks;

namespace SWE.UI.ImplementForms
{
    public class ImplementProfessor
    {
        private int resultCommet =0;

        public async Task<bool> Updated(int _Idprofessor, string _NameDepartment, int _IdDepartment, int? _IdManager, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    var department = await work.Department.GetId(_IdDepartment);
                    var professor = (_IdManager == null) ? null : await work.Professor.GetId(_IdManager);
                    work.Professor.Update(new Professor
                    {
                        Id = _Idprofessor,
                        Name = _NameDepartment,
                        Department = department,
                        ProfessorManage = professor,
                        IsDelete = _IsDelete
                    });

                    resultCommet = await work.Commet();
                }
                if (resultCommet == 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
        public async Task<bool> Deleted(int _IdDepartment, string _NameProfessor, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    work.Professor.Update(new Professor
                    {
                        Id = _IdDepartment,
                        Name = _NameProfessor,
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
        public async Task<bool> Add(string _NameProfessor, int _IdDepartment, int? _IdManager)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    var department = await work.Department.GetId(_IdDepartment);
                    var professor = (_IdManager == null) ? null : await work.Professor.GetId(_IdManager);
                    await work.Professor.Add(new Professor { Name = _NameProfessor, Department = department, ProfessorManage = professor });

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
