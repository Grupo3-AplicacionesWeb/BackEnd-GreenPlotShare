using agro_shop.Iam.Domain.Model.Aggregates;
using agro_shop.Iam.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using LandManagement.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace agro_shop.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //IAM
        builder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();

            entity.OwnsOne(u => u.Name, name =>
            {
                name.Property(n => n.FirstName).HasColumnName("FirstName");
                name.Property(n => n.LastName).HasColumnName("LastName");
            });

            entity.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Address).HasColumnName("EmailAddress");
            });
        });

        // Configuración de Role
        builder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        });

        // Configuración de UserRole (entidad intermedia)
        builder.Entity<UserRole>(entity =>
        {
            entity.HasKey(ur => new { ur.UserId, ur.RoleId });

            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        });

        // Configuración de Terrenos
        builder.Entity<Land>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();

            entity.OwnsOne(l => l.Location, location =>
            {
                location.Property(l => l.Latitude).HasColumnName("Latitude");
                location.Property(l => l.Longitude).HasColumnName("Longitude");
                location.Property(l => l.Address).HasColumnName("Address");
                location.Property(l => l.City).HasColumnName("City");
                location.Property(l => l.State).HasColumnName("State");
                location.Property(l => l.PostalCode).HasColumnName("PostalCode");
            });

            entity.OwnsOne(l => l.Price, price =>
            {
                price.Property(p => p.Amount).HasColumnName("Amount");
                price.Property(p => p.Currency).HasColumnName("Currency");
            });

            entity.OwnsOne(l => l.Features, features =>
            {
                features.Property(f => f.Size).HasColumnName("Size");
                features.Property(f => f.SoilType).HasColumnName("SoilType");
                features.Property(f => f.Irrigation).HasColumnName("Irrigation");
            });
        });
    }
}
