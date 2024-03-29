
using FluentValidation.AspNetCore;
using TaskManager.Infraestructure.Filters;
using TaskManager.Infraestructure.Mapping;
using TaskManager.Presentation.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mapper = typeof(AutoMapperProfile).Assembly;
builder.Services.AddAutoMapper(mapper);

builder.Services.AddControllers()
                .AddNewtonsoftJson(
                            options => options.SerializerSettings
                            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguratedDBFromTheAppSettingStringConnection();
builder.Services.AddSumary();
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 