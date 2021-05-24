using SWE.UI.interfaces;
using SWE.UI.Repositories.CourseRepository;
using SWE.UI.Repositories.DepartmentRepository;
using SWE.UI.Repositories.FacultieRepository;
using SWE.UI.Repositories.ProfessorRepository;
using SWE.UI.Repositories.StudentLogRepository;
using SWE.UI.Repositories.StudentRepository;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly SWEContext context;
        public UnitOfWork(SWEContext context)
        {
            this.context = context;
            Facultie = new FacultieRepository(context);
            Department = new DepartmentRepository(context);
            Professor = new ProfessorRepository(context);
            Student = new StudentRepository(context);
            StudentLog = new StudentLogRepository(context);
            Course = new CourseRepository(context);
        }

        public IFacultieRepository Facultie { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IProfessorRepository Professor { get; private set; }
        public IStudentRepository Student { get; private set; }
        public IStudentLogRepository StudentLog { get; private set; }
        public ICourseRepository Course { get; private set; }
        public async Task<int> Commet() => await context.SaveChangesAsync();

        public void Dispose() => context.Dispose();
    }
}
