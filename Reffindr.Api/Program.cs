using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Reffindr.Api.Middleware;
using Reffindr.Application.Services.Classes;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Extensions.Claims.ServiceWrapper;
using Reffindr.Infrastructure.Repositories.Classes;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
#region Services Area
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionStrings);
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reffindr API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el token JWT en el formato: Bearer {tu token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var allowedOrigin = builder.Configuration.GetValue<string>("AllowedOrigins")!;
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.WithOrigins(allowedOrigin).AllowAnyHeader().AllowAnyMethod();
    });

    opciones.AddPolicy("free", configuracion =>
    {
        configuracion.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddHttpContextAccessor();

#region Services

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPropertiesService, PropertiesService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IUserContext, UserContext>();

#endregion Services

#region Repositories
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IPropertiesRepository, PropertiesRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion Repositories

#endregion Services Area

var app = builder.Build();

#region Middlewares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
// Middleware para manejar excepciones globales
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<TimingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

#endregion Middlewares
app.Run();