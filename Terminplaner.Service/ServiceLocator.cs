using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminplaner.Model.Entities;

namespace Terminplaner.Service
{
    /// <summary>
    /// provides config and registration of services and dbcontext for the app
    /// enables dependency injection across the app
    /// </summary>
    public class ServiceLocator
    {

        public static void ConfigureDataServices(IServiceCollection services)
        {

            // getting connection string
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // register dbcontext
            services.AddDbContext<TerminplanerDbContext>(option => option.UseSqlServer(connectionString));

            // register services
            services.AddSingleton<AppointmentService>();
            services.AddSingleton<UserService>();

        }


    }
}
