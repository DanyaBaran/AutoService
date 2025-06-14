using RepairService.Api.Infrastructure;
using RepairService.Api.Interfaces;
using RepairService.Api.Repositories;
using RepairService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IRepairRepository, RepairRepository>();
builder.Services.AddScoped<RepairsService>();
builder.Services.AddScoped<IRepairInfoRepository, RepairInfoRepository>();
builder.Services.AddScoped<RepairInfoService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();