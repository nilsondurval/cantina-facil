using CantinaFacil.Shared.Kernel.Api.Configurations;
using CantinaFacil.Shared.Kernel.Api.Filters;
using CantinaFacil.Api.Configurations;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddControllers();

builder.Services.AddSwaggerConfiguration(builder.Configuration);

builder.Services.AddDataBaseConfiguration(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDependencyInjection();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddMvc(options =>
{
    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
    options.Filters.Add<ExceptionFilter>();
})
.AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddJwtAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
    c.WithExposedHeaders("Content-Disposition");
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseSwaggerConfiguration();

app.Run();
