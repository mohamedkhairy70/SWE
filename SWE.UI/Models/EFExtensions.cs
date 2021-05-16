using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SWE.UI.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public static class EFExtensions
    {
        public static IServiceCollection AddEntityFrameWork(this IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<SWEContext>(options => options.UseSqlServer(ConnectionString, x => x.MigrationsAssembly("SWECon")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IRepository<>), typeof(GUIDRepository<>));

            return services;
        }
    }
}
