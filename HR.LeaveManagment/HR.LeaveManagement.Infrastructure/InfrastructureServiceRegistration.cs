using HR.LeaveManagement.Infrastructure.Mail;
using HR.LeaveManagment.Application.Contracts.Infrastructure;
using HR.LeaveManagment.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrstructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;

        }
    }
}
