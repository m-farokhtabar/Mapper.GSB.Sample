using Logging;
using Mapper.GSB.Rest.API.StartupConfig.Applications;
using Mapper.GSB.Rest.API.StartupConfig.Services;
using Mapper.GSB.Rest.API.StartupConfig.Services.Swagger;
using Mapper.GSB.Rest.API.StartupConfig.Settings;
using Serilog;
using Microsoft.Extensions.Caching.Memory;
using Mapper.GSB.Application.Configuration.StratupConfig;
using Mapper.GSB.Infrastructure.Configuration.StartupConfig;
using Mapper.GSB.Application.SeedWorks;
using Mapper.GSB.Rest.API;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(LoggingConfiguration.SeriLogConfiguration);

AuthSettings authSettings = builder.Configuration.GetSection("AuthSettings").Get<AuthSettings>()!;
MassTransitSettings massTransitSettings = builder.Configuration.GetSection("MassTransitSettings").Get<MassTransitSettings>()!;

ApplicationSettings applicationSettings = builder.Configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>()!;
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestBodyLogLimit = 2097152; //2MB
    logging.ResponseBodyLogLimit = 2097152; //2MB
});
builder.Services.AddSingleton<IInsuranceCompaniesIds>(_ => applicationSettings);
builder.Services.AddMemoryCache();
builder.Services.ConfigureController();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureSwashBuckleSwagger(builder.Configuration);
builder.Services.ApplicationConfiguration(x => x.DefaultConfiguration());
builder.Services.InfrastructureConfiguration(builder.Configuration["ConnectionStrings:DbConnection"]!, x => x.DefaultConfiguration(builder.Configuration["ConnectionStrings:DbBIConnection"]!, 
                                                                                                                                   builder.Configuration["ConnectionStrings:DbFilterConnection"]!,
                                                                                                                                   builder.Configuration["ConnectionStrings:DbPersonPolicyInfoConnection"]!));

builder.Services.ConfigureMassTransit(massTransitSettings);
builder.Services.ConfigureAuthentcation(authSettings, builder.Configuration["ConnectionStrings:IdpConnection"]!, builder.Configuration["ConnectionStrings:UserAccountConnection"]!);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCustomizeLocalization();
app.UseCustomizeExceptionHandler();
app.UseCustomizeStatusCodePages();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseSwashBuckleSwagger();
app.UseCorsAllowAny();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
