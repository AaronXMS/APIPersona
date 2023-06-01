using app.domain;
using app.logic;
using app.repository.Repository;
using app.repository.UOW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PersonaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IPersonaUOW, PersonaUOW>();

builder.Services.AddScoped<IRepoPersona, RepoPersona>();

builder.Services.AddScoped<PersonaLogic>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add cors config
builder.Services.AddCors(options =>
{
    options.AddPolicy("customCors", policy =>
    {
        policy
        .SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("customCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
