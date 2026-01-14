using Microsoft.OpenApi.Models;
using MyRecipeBook.API.Converters;
using MyRecipeBook.API.Filters;
using MyRecipeBook.API.Middleware;
using MyRecipeBook.API.Token;
using MyRecipeBook.Application;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
const string bearer = "Bearer";

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions
    .Converters.Add(new StringConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(bearer, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                    Enter 'Bearer' [space] and then your token in the text input below.
                    Example: 'Bearer 13245abcdf'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = bearer
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = bearer
                },
                Scheme = "oauth2",
                Name = bearer,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddScoped<ITokenProvider, HttpTokenValue>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

await app.RunAsync();


namespace MyRecipeBook.API
{
    public partial class Program
    {
        protected Program(){}
    }
}