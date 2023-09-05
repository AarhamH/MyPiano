using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("WebApiDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(options =>
{
    options
        .AllowAnyOrigin()          // Allow requests from any origin (domain)
        .AllowAnyMethod()          // Allow any HTTP method (e.g., GET, POST, PUT, DELETE)
        .AllowAnyHeader();          // Allow any HTTP headers in the request
});

app.UseAuthorization();

app.MapControllers();

app.Run();
