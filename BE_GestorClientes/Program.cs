using BE_GestorClientes.Models;
using BE_GestorClientes.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddDbContext<DataAccessContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddCors(options => options.AddPolicy("allowWebapp", 
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//Mapper
builder.Services.AddAutoMapper(typeof(Program));

//Services
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
builder.Services.AddScoped<IOrdenRepository, OrdenRepository>();
builder.Services.AddScoped<IArticulosOrdenRepository, ArticulosOrdenRepository>();


var app = builder.Build();

//Migration
using (var serviceScope = app.Services.CreateScope())
{
    using var context = serviceScope.ServiceProvider.GetRequiredService<DataAccessContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
