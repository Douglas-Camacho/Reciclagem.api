using AutoMapper;
using Reciclagem.api.Models;
using Reciclagem.api.Data.Repository;
using Reciclagem.api.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Reciclagem.api.Services;
using Reciclagem.api.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

#region AutoMapper
// Config do AutoMapper
var mapperConfig = new MapperConfiguration(c =>
{
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<CidadaoModel, CidadaoViewModel>();
    c.CreateMap<CidadaoViewModel, CidadaoModel>();
    c.CreateMap<CidadaoCreateViewModel, CidadaoModel>();
    c.CreateMap<CidadaoUpdateViewModel, CidadaoModel>();
});

IMapper mapper = mapperConfig.CreateMapper();
#endregion

#region Auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789")),
        };
    });
#endregion

builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
