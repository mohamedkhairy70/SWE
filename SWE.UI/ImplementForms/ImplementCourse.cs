using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Threading.Tasks;

namespace SWE.UI.ImplementForms
{
    public class ImplementCourse
    {
        private int resultCommet = 0;

        public async Task<bool> Updated(int _Id, string _Name, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
                {
                    work.Course.Update(new Course { Id = _Id, Name = _Name, IsDelete = _IsDelete });

                    resultCommet = await work.Commet();
                }

                if (resultCommet == 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }

        }
        public async Task<bool> Add(string _Name)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContextFactory().CreateDbContext()))
                {
                    await work.Course.Add(new Course { Name = _Name });

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
