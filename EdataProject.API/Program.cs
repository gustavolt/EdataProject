using EdataProject.Domain.Account;
using EdataProject.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureAPI(builder.Configuration);
//ativar autenticacao e validar o token
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseRouting();

SeedUserRoles(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var seed = serviceScope.ServiceProvider
                               .GetService<ISeedUserRoleInitial>();

        seed?.SeedRoles();
        seed?.SeedUsers();
    }
}