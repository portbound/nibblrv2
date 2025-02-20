using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {
    public DbSet<Instructions> Instructions => Set<Instructions>();
    public DbSet<Ingredients> Ingredients => Set<Ingredients>();
    public DbSet<Macros> Macros => Set<Macros>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Recipe> Recipes => Set<Recipe>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Description);
            entity.HasIndex(e => e.URL).IsUnique();
            
            entity.HasOne(e => e.Macros)
                .WithOne(e => e.Recipe)
                .HasForeignKey<Macros>(macros => macros.RecipeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Ingredients)
                .WithOne(e => e.Recipe)
                .HasForeignKey(ingredients => ingredients.RecipeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.Instructions)
                .WithOne(e => e.Recipe)
                .HasForeignKey(instructions => instructions.RecipeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Category)
                .WithOne(e => e.Recipe)
                .HasForeignKey<Category>(category => category.RecipeId)
                .IsRequired();
        });
        
        modelBuilder.Entity<Instructions>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Step);
            entity.Property(e => e.Body);
        });
        
        modelBuilder.Entity<Ingredients>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Name);
            entity.Property(e => e.Quantity);
            entity.Property(e => e.Weight);
            entity.Property(e => e.WeightUnit);
            entity.Property(e => e.Description);
        });
        
        modelBuilder.Entity<Macros>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Calories);
            entity.Property(e => e.Fat);
            entity.Property(e => e.Carbs);
            entity.Property(e => e.Protein);
        });
        
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            
            entity.Property(e => e.Name);
        });
    }
}