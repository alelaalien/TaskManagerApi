
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TaskManager.Domain.CustomEntities.Options;
using TaskManager.Infraestructure.Filters;
using TaskManager.Infraestructure.Mapping;
using TaskManager.Presentation.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mapper = typeof(AutoMapperProfile).Assembly;
builder.Services.AddAutoMapper(mapper);
builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("Pagination"));
builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptions>())
                .AddNewtonsoftJson(options =>
                    { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                      options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    });
                    
                            
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguratedDBFromTheAppSettingStringConnection();
builder.Services.AddSumary();

builder.Services.AddSwaggerGen(documentation =>
   {
       documentation.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Manager API", Version = "v1" });
       var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
       var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
       documentation.IncludeXmlComments(xmlPath);
   }
) ;

builder.Services.AddMvc(options => options.Filters.Add<ValidatorFilter>())
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    });
                
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
        { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API");
            options.RoutePrefix = string.Empty;
        
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 