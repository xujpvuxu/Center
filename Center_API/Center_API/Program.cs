using Center_API.Extensions;
using Center_API.Middlewawre;
using Center_API.Models;
using Center_API.Models.DB;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Extensions JWT
    builder.Services.AddJWTAuthentication();

    builder.Services.AddDbContext<CenterContext>(
       options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    string keyCorsPolicy = "CorsPolicy";
    builder.Services.AddCors(options => options.AddPolicy(
         "CorsPolicy",
        builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(_ => true)
                .AllowCredentials();
        }
    ));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(keyCorsPolicy);

    UseMiddlewareExtensions.UseMiddleware<ExceptionMiddleware>(app);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch
{
}