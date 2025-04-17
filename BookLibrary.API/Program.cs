using BookLibrary.Core.Repositories;
using BookLibrary.Data.Contexts;
using BookLibrary.Data.Seed;
using BookLibrary.Core.Queries.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o => o.AddPolicy("AllowWebApp", p =>
{
    p.WithOrigins("https://localhost:44333")  // URL + porta do seu Web
     .AllowAnyHeader()
     .AllowAnyMethod();
}));

builder.Services.AddDbContext<LibraryContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDb")));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<SearchBooksQueryHandler>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors("AllowWebApp");

using (var scope = app.Services.CreateScope())
    SeedData.Initialize(scope.ServiceProvider);

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.Run();
