using System.Text.Json;
using Graduation_Project.Core.ErrorHandling;
using Graduation_Project.Extenstions;
using Graduation_Project.Filters;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.RegisterConfigurations();
builder.Services.RegisterDbContext(builder.Configuration);



builder.Services.AddControllers(options =>
{
    options.ModelValidatorProviders.Clear();
    options.Filters.Add(typeof(ValidationFilter));
});
builder.Services.RegisterValidations();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.RegisterMiddlewares();
app.Services.AddSeedData();

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