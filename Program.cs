using DotNetEnv;
using To_Do.Extensions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Configure Extensions
builder.Services.AddCorsConfiguration();
builder.Services.AddDatabaseConfiguration();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();


// Middleware for development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Middleware de Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel_Riwi API V1");
});

// Middleware for redirecting to swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

// Middleware CORS
app.UseCors("AllowSpecificOrigin");

// hability to serve static files
app.UseStaticFiles();

// authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
