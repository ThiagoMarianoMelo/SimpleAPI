using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using TestProject.Configuration;
using TestProject.Domain.ConfigObjects;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection(nameof(JWTConfig)));
builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MapperConfiguration));
builder.Services.ConfigureMediator();

builder.Services.ConfigureDataBase(builder.Configuration);

builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDataProtection();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TestContext>();
    context.Database.Migrate();
}

app.Run();
