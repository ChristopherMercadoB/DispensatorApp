using DispensatorApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispensatorApp.Application
{
    public static class DependencyInyection
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Services:
            services.AddTransient<DispensationModeService, DispensationModeService>();
            services.AddTransient<DispensationQuantitiesService, DispensationQuantitiesService>();
        }
    }
}
