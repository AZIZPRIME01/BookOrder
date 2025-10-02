using BookOrder.Data;
using BookOrder.Repositories;
using BookOrder.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService, BookService>();


var app = builder.Build();

app.UseHttpsRedirection();

app.Run();


