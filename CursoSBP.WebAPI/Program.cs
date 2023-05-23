using CursoSBP.Data;
using CursoSBP.Data.Interface;
using CursoSBP.Data.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "_MyAllowSpecificOrigins";
builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy(name: MyAllowSpecificOrigins,
builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var ConnectionString = builder.Configuration.GetConnectionString("ConexionCursoSBP");
//builder.Services.AddDbContext<DataContext>(con => con.UseSqlServer(ConnectionString));
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

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
