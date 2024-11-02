using Carter;
using Microsoft.EntityFrameworkCore;
using VerticalSliceSample.DataBase;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//                          services container

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DataContext
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    "Server=localhost;Database=VearticalSliceSample;User Id=SA;Password=12230500o90P;TrustServerCertificate=True"));

//Mediatr
builder.Services.AddMediatR(Config =>
{
    Config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//Carter
builder.Services.AddCarter();

var app = builder.Build();

//                        HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();
app.Run();
