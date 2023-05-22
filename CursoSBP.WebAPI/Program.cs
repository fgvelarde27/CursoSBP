using CursoSBP.Data;
using CursoSBP.Data.Interface;
using Microsoft.EntityFrameworkCore;
using CursoSBP.Data.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("ConexionCursoSBP");
builder.Services.AddDbContext<DataContext>(options => 
options.UseSqlServer(ConnectionString, sqlOption =>
            sqlOption.UseNetTopologySuite()
         ));
builder.Services.AddScoped<IStudentService, StudentService>();
//AddScoped 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
