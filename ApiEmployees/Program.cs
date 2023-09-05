using ApiEmployees.Entities;
using ApiEmployees.Repository;
using ApiEmployees.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeesInformation, EmployeesInformationService>();
builder.Services.AddScoped<IDataAccess<ServiceResponse>, EmployeesDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("./v1/swagger.json", "API Employees");
    });
}

app.UseHttpsRedirection();
app.UseCors(x=>x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).WithOrigins("http://localhost:4200"));

app.UseAuthorization();

app.MapControllers();

app.Run();