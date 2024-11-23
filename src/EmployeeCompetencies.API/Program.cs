using FluentValidation;
using Microsoft.EntityFrameworkCore;
using EmployeeCompetencies.DataAccess;
using EmployeeCompetencies.UseCases.Contracts;
using EmployeeCompetencies.UseCases.Abstractions;
using EmployeeCompetencies.DataAccess.Repositories;
using EmployeeCompetencies.UseCases.Validators;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddProblemDetails();

services.AddAutoMapper(x => x.AddProfile<MappingProfile>());

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => 
        cfg.RegisterServicesFromAssemblies(assembly));
}

services.AddDbContext<Context>(
    options =>
    {
        options.UseNpgsql(
            builder.Configuration
            .GetConnectionString("DefaultConnection"));
    }
);

services.AddScoped<IValidator<PersonRequest>, PersonRequestValidator>();
services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
