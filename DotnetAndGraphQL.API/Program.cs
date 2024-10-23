using DotnetAndGraphQL.Domain;
using DotnetAndGraphQL.Domain.Context;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("DataSource = app.db"));

builder.Services.AddGraphQLServer().AddQueryType<Query>()
                                   .AddProjections()
                                   .AddFiltering()
                                   .AddSorting();


var app = builder.Build();

//CreateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}