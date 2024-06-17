﻿using Employees.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Employees.Domain.Aggregates.EmployeeAggregate.Repository;
using Employees.Infrastructure.Persistance.Repositories;

namespace Employees.Infrastructure
{
    /// <summary>
    /// Inject services into the application.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Register dependencies for the application from the Infrastructure layer.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // TODO: Add the connection string to the database.
            services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(""));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
