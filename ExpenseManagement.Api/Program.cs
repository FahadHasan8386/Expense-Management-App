using ExpenseManagement.Api.Interfaces.IRepositories;
using ExpenseManagement.Api.Interfaces.IServices;
using ExpenseManagement.Api.Repository;
using ExpenseManagement.Api.Services;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Database Connection
builder.Services.AddScoped<System.Data.IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register Services
builder.Services.AddScoped<IDepositsService, DepositsService>();
builder.Services.AddScoped<IExpenseCategoriesService, ExpenseCategoriesService>();

// Register Repositories
builder.Services.AddScoped<IDepositsRepository, DepositsRepository>();
builder.Services.AddScoped<IExpenseCategoriesRepository, ExpenseCategoriesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
