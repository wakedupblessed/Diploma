using Diploma.Api.Endpoints;
using Diploma.Api.Middleware;
using Diploma.Api.OptionsSetup;
using Diploma.Application;
using Diploma.Application.Contracts.Services;
using Identity;
using Identity.DbContext;
using Identity.Models;
using Infrastructure;
using Infrastructure.SvmPrediction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IdentityDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbConnection")));

builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDatabaseContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Feedback Analyzer", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.ConfigureOptions<SvmPredictionOptionsSetup>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddHttpClient<ISvmPredictionService, SvmPredictionService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5067");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    await ApplicationDatabaseInitializer.Initialize(scope.ServiceProvider);
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.AddAuthenticationEndpoints();

app.AddFeedbackEndpoints();

app.AddVacancyEndpoints();

app.AddCandidateEndpoints();

app.Run();