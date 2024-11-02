using Microsoft.EntityFrameworkCore;
using VerticalSliceSample.DataBase;

var builder = WebApplication.CreateBuilder(args);

//                          services container

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>options.UseSqlServer(
    "Server=localhost;Database=VearticalSliceSample;User Id=SA;Password=12230500o90P;TrustServerCertificate=True"));

var app = builder.Build();

//                        HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
