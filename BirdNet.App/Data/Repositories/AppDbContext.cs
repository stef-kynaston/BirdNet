using BirdNet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BirdNet.Data.Repositories;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Genus> Genera { get; set; }
    public DbSet<Species> Species { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(
            entity =>
            {
                entity
                    .HasMany(order => order.Families)
                    .WithOne(family => family.Order)
                    .HasForeignKey(family => family.OrderGuid);
            }
        );

        modelBuilder.Entity<Family>(
            entity =>
            {
                entity
                    .HasOne(family => family.Order)
                    .WithMany(order => order.Families)
                    .HasForeignKey(family => family.OrderGuid);

                entity
                    .HasMany(family => family.Genera)
                    .WithOne(genus => genus.Family)
                    .HasForeignKey(genus => genus.FamilyGuid);
            }
        );

        modelBuilder.Entity<Genus>(
            entity =>
            {
                entity
                    .HasOne(genus => genus.Family)
                    .WithMany(family => family.Genera)
                    .HasForeignKey(genus => genus.FamilyGuid);

                entity
                    .HasMany(genus => genus.Species)
                    .WithOne(species => species.Genus)
                    .HasForeignKey(species => species.GenusGuid);
            }
        );

        modelBuilder.Entity<Species>(
            entity =>
            {
                entity
                    .HasOne(species => species.Genus)
                    .WithMany(genus => genus.Species)
                    .HasForeignKey(species => species.GenusGuid);
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}