using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Threading.Tasks;

namespace SWE.UI.ImplementForms
{
    public class ImplementDepartment
    {
        private int resultComment = 0;

        public async Task<bool> Updated(int _IdDepartment, string _NameDepartment, int _IdFacultie, int? _IdManager, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    var facultie = await work.Facultie.GetId(_IdFacultie);
                    var professor = (_IdManager == null) ? null : await work.Professor.GetId(_IdManager);
                    work.Department.Update(new Department
                    {
                        Id = _IdDepartment,
                        Name = _NameDepartment,
                        Facultie = facultie,
                        ProfessorManage = professor,
                        IsDelete = _IsDelete
                    });

                    resultComment = await work.Commet();

                }
                if (resultComment == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Deleted(int _IdDepartment, string _NameDepartment, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    work.Department.Update(new Department
                    {
                        Id = _IdDepartment,
                        Name = _NameDepartment,
                        IsDelete = _IsDelete
                    });

                    resultComment = await work.Commet();
                }
                if (resultComment == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> Add(string _NameDepartment, int _IdFacultie, int? _IdManager)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    var facultie = await work.Facultie.GetId(_IdFacultie);
                    var professor = (_IdManager == null) ? null : await work.Professor.GetId(_IdManager);
                    await work.Department.Add(new Department { Name = _NameDepartment, Facultie = facultie, ProfessorManage = professor });

                    resultComment = await work.Commet();
                }
                if (resultComment == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
