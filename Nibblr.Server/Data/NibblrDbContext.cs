using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public class NibblrDbContext(DbContextOptions<NibblrDbContext> options) : DbContext(options) {
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Instructions> Instructions => Set<Instructions>();
    public DbSet<Ingredients> Ingredients => Set<Ingredients>();
    public DbSet<Tag> Tags => Set<Tag>();
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID);

            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Description);
            entity.Property(e => e.Bookmarked).IsRequired();
            entity.Property(e => e.URL);
            
            entity.Property(e => e.Servings);
            entity.Property(e => e.Calories);
            entity.Property(e => e.Carbs);
            entity.Property(e => e.Fat);
            entity.Property(e => e.Protein);
            
            entity.HasMany(e => e.Ingredients)
                .WithOne()
                .HasForeignKey(e => e.RecipeID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasMany(e => e.Instructions)
                .WithOne()
                .HasForeignKey(e => e.RecipeID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Tags)
                .WithMany(e => e.Recipes)
                .UsingEntity(j => j.ToTable("RecipeTags"));        
        });

        modelBuilder.Entity<Ingredients>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID);

            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.Unit).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Notes);
        });
        
        modelBuilder.Entity<Instructions>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID);

            entity.Property(e => e.Step).IsRequired();
            entity.Property(e => e.Body).IsRequired();
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID);
            
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Name).IsRequired();
        });
    }
}