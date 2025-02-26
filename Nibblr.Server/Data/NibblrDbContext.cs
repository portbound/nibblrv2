using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public class NibblrDbContext(DbContextOptions<NibblrDbContext> options) : DbContext(options) {
    public DbSet<Recipe> Recipes => Set<Recipe>();
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();

            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.Description);
            entity.Property(e => e.Bookmarked).IsRequired();
            entity.Property(e => e.URL);

            entity.Property(e => e.Category).IsRequired();

            entity.Property(e => e.Servings);
            entity.Property(e => e.Calories).IsRequired();
            entity.Property(e => e.Carbs).IsRequired();
            entity.Property(e => e.Fat).IsRequired();
            entity.Property(e => e.Protein).IsRequired();

            entity.Property(e => e.IngredientsJson)
                .HasColumnType("TEXT")
                .IsRequired()
                .HasDefaultValue("[]");

            entity.Property(e => e.InstructionsJson)
                .HasColumnType("TEXT")
                .IsRequired()
                .HasDefaultValue("[]");
        });
    }
}