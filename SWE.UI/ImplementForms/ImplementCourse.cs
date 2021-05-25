using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Threading.Tasks;

namespace SWE.UI.ImplementForms
{
    public class ImplementCourse
    {
        private int resultCommet = 0;

        public async Task<bool> Updated(int _Id, string _Name, int _IdDepartment, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
                {
                    var department = await work.Department.GetId(_IdDepartment);
                    work.Course.Update(new Course { Id = _Id, Name = _Name,Department = department, IsDelete = _IsDelete });

                    resultCommet = await work.Commet();
                }

                if (resultCommet == 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }

        }
        public async Task<bool> Add(string _Name, int _IdDepartment)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
                {
                    var department = await work.Department.GetId(_IdDepartment);
                    await work.Course.Add(new Course { Name = _Name,Department = department });

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
