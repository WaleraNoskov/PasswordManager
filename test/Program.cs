using MediatR;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Application;
using PasswordManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PasswordManagerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PasswordManagerDbConnection"), 
    builder => builder.MigrationsAssembly("PasswordManager.Infrastructure")));

builder.Services.AddMediatR(typeof(CreateEmailAddressPasswordCommandHandler).Assembly);

builder.Services.AddTransient<IEmailAddressPasswordRepository, EmailAddressPasswordRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
