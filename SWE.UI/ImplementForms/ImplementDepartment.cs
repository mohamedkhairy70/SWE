using SWE.UI.Models;
using SWE.UI.Models.Domain;

namespace SWE.UI.ImplementForms
{
    public class ImplementDepartment
    {
        public void Updated(int _IdDepartment, string _NameDepartment, int _IdFacultie, int? _IdManager, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var facultie = work.Facultie.GetId(_IdFacultie);
                var professor = (_IdManager == null) ? null : work.Professor.GetId(_IdManager);
                work.Department.Update(new Department
                {
                    Id = _IdDepartment,
                    Name = _NameDepartment,
                    Facultie = facultie,
                    ProfessorManage = professor,
                    IsDelete = _IsDelete
                });

                work.Commet();
            }

        }
        public void Deleted(int _IdDepartment, string _NameDepartment, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Department.Update(new Department
                {
                    Id = _IdDepartment,
                    Name = _NameDepartment,
                    IsDelete = _IsDelete
                });

                work.Commet();
            }

        }
        public void Add(string _NameDepartment, int _IdFacultie, int? _IdManager)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var facultie = work.Facultie.GetId(_IdFacultie);
                var professor = (_IdManager == null) ? null : work.Professor.GetId(_IdManager);
                work.Department.Add(new Department { Name = _NameDepartment, Facultie = facultie, ProfessorManage = professor });

                work.Commet();
            }

        }
    }
}
