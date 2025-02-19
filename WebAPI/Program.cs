using Persistence;
using FluentValidation.AspNetCore;
using Application.Validators.Products;
using Infrastructure.Filters;
using Infrastructure;
using Infrastructure.Services.Storage.Local;
using Infrastructure.Services.Storage.Azure;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://127.0.0.1:5173").AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())

    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
