using InfoDengue.Context;
using InfoDengue.Interfaces.Repositories;
using InfoDengue.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfoDengue;

public static class Setup
{
    public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("InfoDengueDB");
        builder.Services.AddDbContext<InfoDengueDbContext>(options =>
            options.UseSqlServer(connectionString));
    }

    public static void AddRegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
        builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
    }

    public static void AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }
}
