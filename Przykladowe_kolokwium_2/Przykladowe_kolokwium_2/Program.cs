using Microsoft.EntityFrameworkCore;
using Przykladowe_kolokwium_2.Context;
using Przykladowe_kolokwium_2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMuzykService, MuzykService>();

builder.Services.AddDbContext<LabelDbContext>(opt =>
{
    string connString = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();