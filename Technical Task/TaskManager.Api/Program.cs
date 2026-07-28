using TaskManager.Application.DependencyInjection;
using TaskManager.Infrastructure.DependencyInjection;
using TaskManager.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularPolicy", policy =>
    {
        policy.WithOrigins(
                "http://localhost:4200",
                "http://localhost:53630"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Exception Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AngularPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();


