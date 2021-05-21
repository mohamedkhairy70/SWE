using SWE.UI.Models;
using SWE.UI.Models.Domain;
using System.Threading.Tasks;

namespace SWE.UI.ImplementForms
{
    public class ImplementFaculties
    {
        private int resultCommet = 0;

        public async Task<bool> Updated(int _Id, string _Name, bool _IsDelete)
        {
            try
            {
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    work.Facultie.Update(new Facultie { Id = _Id, Name = _Name, IsDelete = _IsDelete });

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
                using (var work = new UnitOfWork(new SWEContext()))
                {
                    await work.Facultie.Add(new Facultie { Name = _Name });

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
