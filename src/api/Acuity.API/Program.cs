using Acuity.Core.Data;
using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AcuityDataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Acuity")));
builder.Services.AddValidatorsFromAssemblyContaining<AcuityDataContext>();
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AcuityDataContext>());
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<AcuityDataContext>();
builder.Services.AddCors(p => p.AddPolicy("cors", builder =>
{
    builder.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));
builder.Services.AddAuthentication().AddCookie();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();
app.UseCors("cors");
app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<IdentityUser>();

app.Run();