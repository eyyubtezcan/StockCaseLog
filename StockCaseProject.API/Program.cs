using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using StockCaseProject.Repository;
using StockCaseProject.Repository.Abstract;
using StockCaseProject.Repository.Concreate;
using StockCaseProject.Service;
using StockCaseProject.Service.Abstract;
using StockCaseProject.Service.Concreate;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//builder.Services.AddDbContext<ApplicationDbContext>(conf =>
//{
//    var connStr = builder.Configuration["ConnectionStrings:SqlConStr"].ToString();
//    conf.UseSqlServer("", opt =>
//    {
//        opt.EnableRetryOnFailure();
//    });
//});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<DbContext, ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>((provider, options) =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
    {
        o.MigrationsAssembly("StockCaseProject.Repository");
    });
    options.AddInterceptors(provider.GetRequiredService<LoggingSavingChangesInterceptor>());
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

#region Repositories

builder.Services.AddScoped<IStockRepository, StockRepository>();

#endregion

#region Services
builder.Services.AddScoped<IStockService, StockService>();

#endregion


builder.Services.AddControllers();





builder.Services.AddScoped<LoggingSavingChangesInterceptor>();

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
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
