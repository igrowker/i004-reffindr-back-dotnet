using Microsoft.EntityFrameworkCore;
using Reffindr.Application.Services.Classes;
using Reffindr.Application.Services.Interfaces;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Classes;
using Reffindr.Infrastructure.Repositories.Interfaces;
using Reffindr.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
#region Services Area
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionStrings);

});

#region Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsersService, UsersService>();
#endregion Services

#region Repositories
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
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

app.UseHttpsRedirection();

app.MapControllers();

#endregion Middlewares
app.Run();