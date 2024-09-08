using Application.Services.Interfaces;
using Application.Services;
using Domain.Entity;
using Infrastructure.Repository;
using LibraryAPI.Extensions;
using LibraryAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDBContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();


var jwtOptions = builder.Configuration.GetSection("Jwt")
    .Get<JwtOptions>();

builder.Services.AddAuthenticationWithJwtBearer(jwtOptions);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();

builder.Services.AddValidators();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwtSecurity();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book API", Version = "v1" });
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<ValidationMiddleware>();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();