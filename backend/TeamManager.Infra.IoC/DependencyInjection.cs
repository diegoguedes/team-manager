using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamManager.Application.Interfaces;
using TeamManager.Application.Mappings;
using TeamManager.Application.Services;
using TeamManager.Domain.Interfaces;
using TeamManager.Infra.Data.Context;
using TeamManager.Infra.Data.Repositories;

namespace TeamManager.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IContractorRepository, ContractorRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IContractorService, ContractorService>();
        services.AddScoped<IEmployeeService,EmployeeService>();
        services.AddScoped<ITagService,TagService>();
        services.AddScoped<IRoleService,RoleService>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}