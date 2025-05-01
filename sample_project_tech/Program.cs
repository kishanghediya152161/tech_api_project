

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using sample_project_tech.SampleDBContext;
using tech.Common.Helper;
using tech.Repository.IRepository;
using tech.Repository.Repository;
using tech.Services.IServices;
using tech.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddHttpClient();


builder.Services.AddDbContext<SampleDbContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetSection("AppConfigurationSettings:DBConnectionString").Value));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IApiHelper, ApiHelper>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:64947") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); 
    });
});



var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
