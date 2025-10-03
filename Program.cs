using BookOrder.Data;
using BookOrder.Repositories;
using BookOrder.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddDbContext<BookOrderDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService, BookService>();


var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();


