using DispensatorApp.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispensatorApp.Database
{
    public static class DependencyInyection
    {
        public static void AddDatabaseLayer(this IServiceCollection services)
        {
            #region Repository
            services.AddTransient(typeof(GenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<DispensationModeRepository, DispensationModeRepository>();
            services.AddTransient<DispensationQuantitiesRepository, DispensationQuantitiesRepository>();
            #endregion
        }
    }
}
