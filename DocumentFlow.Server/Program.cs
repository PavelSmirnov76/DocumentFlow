using Microsoft.EntityFrameworkCore;
using DocumentFlow.Server.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DocumentFlowServerContext>(options =>
    options.UseSqlServer("Server=localhost;Database=documentflowDB;Trusted_Connection=True;"));

//"workstation id=documentflowdb.mssql.somee.com;packet size=4096;user id=PavelSmirnov76_SQLLogin_1;" +
//"pwd=ds3wuqc8qx;data source=documentflowdb.mssql.somee.com;persist security info=False;initial catalog=documentflowdb"



builder.Services.AddCors(); // Make sure you call this previous to AddMvc

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
