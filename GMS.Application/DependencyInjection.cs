using AutoMapper;
using FluentValidation;
using GMS.Application.Services.Authentication.Command.Register;
using GMS.Application.Services.Group.Command;
using GMS.Application.Services.Group.Queries.GetAll;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}