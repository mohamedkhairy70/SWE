using SWE.UI.Models;
using SWE.UI.Models.Domain;

namespace SWE.UI.ImplementForms
{
    public class ImplementFaculties
    {
        public void Updated(int _Id, string _Name, bool _IsDelete)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Facultie.Update(new Facultie { Id = _Id, Name = _Name, IsDelete = _IsDelete });

                work.Commet();
            }

        }
        public void Add(string _Name)
        {
            using (var work = new UnitOfWork(new SWEContext()))
            {
                work.Facultie.Add(new Facultie { Name = _Name });

                work.Commet();
            }

        }
    }
}
