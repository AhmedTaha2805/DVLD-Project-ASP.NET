using Microsoft.EntityFrameworkCore;
using DVLD_WebApi.Services;
using DVLD_WebApi.Data;
using DVLD_WebApi.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DVLDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<TestTypeService>();
builder.Services.AddScoped<ApplicationTypeService>();
builder.Services.AddScoped<LicenseClassService>();
builder.Services.AddScoped<TestService>();
builder.Services.AddScoped<TestAppointmentService>();
builder.Services.AddScoped<ApplicationService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddlware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
