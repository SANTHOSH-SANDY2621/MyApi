using Microsoft.EntityFrameworkCore;
using MyApi.BussinessLogic;
using MyApi.BussinessLogic.IBussinessLogic;
using MyApi.BussinessRepository;
using MyApi.BussinessRepository.IBussinessRepository;
using MyApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<LearningNetContext>(opt => opt.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Learning;Integrated Security=True;Trust Server Certificate=True"));

//repo
builder.Services.AddTransient<IEmployerBussinessLogic, EmployerBussinessLogic>();
builder.Services.AddTransient<IEmployerRepository, EmployerRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
