using Auction.Api.Controller;
using Auction.Api.Filters;
using Auction.Api.Interfaces;
using Auction.Api.Repositories;
using Auction.Api.Repositories.Data_Access;
using Auction.Api.Services;
using Auction.Api.UseCase.Auctions.GetCurrents;
using Auction.Api.UseCase.Offers.CreateOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<IUserRepositories,UserRepositories>();
builder.Services.AddScoped<IAuctionRepositories,AuctionRepositories>();
builder.Services.AddScoped<IOfferRepositories,OfferRepositories>();
builder.Services.AddScoped<AutenticationUserAttribute>();
builder.Services.AddScoped<ILoggedUser,LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();

builder.Services.AddDbContext<AuctionDbContext>(options =>
{
    options.UseSqlite(@"Data Source = C:\Users\gabri\Downloads\leilaoDbNLW.db");
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.
           Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


