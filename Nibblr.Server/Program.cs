using AutoMapper;
using Client;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Server.Data;
using Server.Exceptions;
// using Nibblr.Server.Infrastructure.Mappings;
using Server.Repositories;
using Server.Repositories.Interfaces;
using Server.Services;
using Server.Services.Interfaces;
using Server.Validators;
using Shared.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<NibblrDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    connectionString = connectionString.Replace("${DB_PASSWORD}", 
        Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "");
    options.UseNpgsql(connectionString);
});
// builder.Services.AddDbContext<NibblrDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<ITagsRepository, TagsRepository>();
builder.Services.AddScoped<ITagsService, TagsService>();
builder.Services.AddSingleton<AbstractValidator<Recipe>, RecipeValidator>();
    
// builder.Services.AddScoped<IMapper, Mapper>();

builder.Services.AddOpenApi();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();

// Add Authentication and Authorization middleware if required
app.UseAuthentication();
app.UseAuthorization();

// Anti-forgery middleware
app.UseAntiforgery();

// Use static files and Blazor WebAssembly middleware
app.UseStaticFiles();
app.UseBlazorFrameworkFiles();

// Routing setup
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();