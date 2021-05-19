using SWE.UI.Models;
using SWE.UI.Models.Domain;

namespace SWE.UI.ImplementForms
{
    public class ImplementProfessor
    {
        public void Updated(int _Idprofessor, string _NameDepartment, int _IdDepartment, int? _IdManager, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var department = work.Department.GetId(_IdDepartment);
                var professor = (_IdManager == null) ? null : work.Professor.GetId(_IdManager);
                work.Professor.Update(new Professor
                {
                    Id = _Idprofessor,
                    Name = _NameDepartment,
                    Department = department,
                    ProfessorManage = professor,
                    IsDelete = _IsDelete
                });

                work.Commet();
            }

        }
        public void Deleted(int _IdDepartment, string _NameProfessor, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Professor.Update(new Professor
                {
                    Id = _IdDepartment,
                    Name = _NameProfessor,
                    IsDelete = _IsDelete
                });

                work.Commet();
            }

        }
        public void Add(string _NameProfessor, int _IdDepartment, int? _IdManager)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                var department = work.Department.GetId(_IdDepartment);
                var professor = (_IdManager == null) ? null : work.Professor.GetId(_IdManager);
                work.Professor.Add(new Professor { Name = _NameProfessor, Department = department, ProfessorManage = professor });

                work.Commet();
            }

        }
    }
}
