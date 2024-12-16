using CompanyEmployees.Extensions;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using Service;
using Service.Contracts;

var builder = WebApplication.CreateBuilder(args);

//LogManager.Setup().LoadConfigurationFromFile("nlog.config");

//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigurationSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

//Alterar o retorno para XML
//builder.Services.AddControllers(config => {
//    config.RespectBrowserAcceptHeader = true;
//}).AddXmlDataContractSerializerFormatters().AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// The one for the request pipeline configuration

if (app.Environment.IsProduction())
        app.UseHsts();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();
//app.UseForwardedHeaders( new ForwardedHeadersOptions {
//    ForwardedHeaders = ForwardedHeaders.All
//});

app.UseCors("CorsPolicy");

app.UseAuthorization();


app.MapControllers();

app.Run();
