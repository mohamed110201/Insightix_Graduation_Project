using Graduation_Project.Extenstions;
using Graduation_Project.Filters;
using Graduation_Project.Hubs;
using Graduation_Project.Hubs.MachineData;
using Graduation_Project.Hubs.Notifications;
using Graduation_Project.Modules.Email;
using Graduation_Project.Modules.Email.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.RegisterConfigurations();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterCaching();
builder.Services.RegisterResend(builder.Configuration);
builder.Services.RegisterRazorLightEngine();
builder.Services.RegisterNotifiers();
builder.Services.AddSignalR();
builder.Logging.ClearProviders();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers(options =>
{
    options.ModelValidatorProviders.Clear();
    options.Filters.Add(typeof(ValidationFilter));
});
builder.Services.RegisterValidations();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.RegisterFailuresPredictionBackground();
builder.Services.RegisterSimulationDataBackground();

builder.Services.RegisterIdentityUser();
builder.Services.RegisterAuthentication(builder.Configuration);




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();
await app.SeedAdminUser();

app.RegisterMiddlewares();

app.UseCors("AllowAll");


app.MapHub<MachineHub>("/machineHub",options => 
    options.Transports = 
    Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets |
    Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling
    );

app.MapHub<NotificationsHub>("/notificationsHub",options => 
    options.Transports = 
        Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets |
        Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling
);

await app.Services.AddSeedData();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();