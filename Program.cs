using ConfigurationValidator;
using ConfigurationValidator.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ConfigurationService>();

//builder.Services.Configure<ServiceConfiguration>(
//    builder.Configuration.GetSection(ServiceConfiguration.SectionName));

//builder.Services.AddOptions<ServiceConfiguration>()
//    .Configure<IConfiguration>((serviceConfig,configuration) => 
//    {
//        var configSection = configuration.GetSection(ServiceConfiguration.SectionName);
//        configSection.Bind(serviceConfig);

//        if (string.IsNullOrEmpty(serviceConfig.ApiKey))
//        {
//            throw new ArgumentNullException("serviceConfiguration ApiKey is missing");
//        }
//    });

//builder.Services.AddOptions<ServiceConfiguration>()
//    .Bind(builder.Configuration.GetSection(ServiceConfiguration.SectionName))
//    .ValidateDataAnnotations()
//    .Validate((config) =>
//    {
//        return config.LowestPriority < config.HighestPriority;
//    }, "Highest priority must be greater than lowest priority");

builder.Services.AddOptions<ServiceConfiguration>()
    .Bind(builder.Configuration.GetSection(ServiceConfiguration.SectionName));

builder.Services.AddSingleton<IValidateOptions<ServiceConfiguration>, ServiceConfigurationValidator>();

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
