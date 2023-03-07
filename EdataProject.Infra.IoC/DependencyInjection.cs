using EdataProject.Application.Interfaces;
using EdataProject.Application.Mappings;
using EdataProject.Application.Services;
using EdataProject.Domain.Account;
using EdataProject.Domain.Interfaces;
using EdataProject.Infra.Data.Context;
using EdataProject.Infra.Data.Identity;
using EdataProject.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EdataProject.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
        ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddIdentity<ApplicationUser,IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientService, ClientService>();

        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("EdataProject.Application");
        services.AddMediatR(myhandlers);

        return services;
    }
}
