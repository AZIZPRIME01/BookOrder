using BookOrder.Data;
using BookOrder.Repositories;
using BookOrder.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("SampleDbConnection");

/* 
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BookOrderDbContext>(Options
=> Options.UseNpgsql(connectionString));

  */

/*  builder.Services.AddDbContext<BookOrderDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
  */
 
builder.Services.AddDbContext<BookOrderDbContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();


var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();


