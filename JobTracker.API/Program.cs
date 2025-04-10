using AutoWrapper;
using JobTracker.Data;
using JobTracker.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JobTrackerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("JobTrackerConnection")));
builder.Services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { ApiVersion = "v1", ShowApiVersion = true, ShowStatusCode = true });
app.UseRouting();
app.MapControllers();

app.Run();
