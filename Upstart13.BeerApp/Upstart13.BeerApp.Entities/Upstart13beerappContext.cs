﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Upstart13.BeerApp.Entities
{
    public partial class Upstart13beerappContext : DbContext
    {
        public Upstart13beerappContext()
        {
        }

        public Upstart13beerappContext(DbContextOptions<Upstart13beerappContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<AmountUnit> AmountUnit { get; set; }
        public virtual DbSet<Beer> Beer { get; set; }
        public virtual DbSet<FoodPairing> FoodPairing { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientType> IngredientType { get; set; }
        public virtual DbSet<Method> Method { get; set; }
        public virtual DbSet<MethodType> MethodType { get; set; }
        public virtual DbSet<TemperatureUnit> TemperatureUnit { get; set; }
        public virtual DbSet<Volume> Volume { get; set; }
        public virtual DbSet<VolumeType> VolumeType { get; set; }
        public virtual DbSet<VolumeUnit> VolumeUnit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AmountUnit>(entity =>
            {
                entity.Property(e => e.AmountUnitId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Beer>(entity =>
            {
                entity.HasIndex(e => e.BeerId, "Idx_BeerId");

                entity.Property(e => e.Abv).HasColumnType("numeric(2, 1)");

                entity.Property(e => e.AttenuationLevel).HasColumnName("Attenuation_Level");

                entity.Property(e => e.BrewerTips)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Brewer_Tips");

                entity.Property(e => e.ContributedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Contributed_By");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FirstBrewed)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("First_Brewed");

                entity.Property(e => e.Ibu).HasColumnType("numeric(2, 1)");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Image_Url");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ph).HasColumnType("numeric(2, 1)");

                entity.Property(e => e.Tagline)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TargetFg).HasColumnName("Target_Fg");

                entity.Property(e => e.TargetOg).HasColumnName("Target_Og");
            });

            modelBuilder.Entity<FoodPairing>(entity =>
            {
                entity.HasIndex(e => e.FoodPairingId, "Idx_FoodPairingId");

                entity.Property(e => e.FoodPairingId).ValueGeneratedNever();

                entity.Property(e => e.Food)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Beer)
                    .WithMany(p => p.ListFoodPairing)
                    .HasForeignKey(d => d.BeerId)
                    .HasConstraintName("FK_FOODPAIR_REFERENCE_BEER");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasIndex(e => e.IngredientId, "Idx_IngredientId");

                entity.Property(e => e.Add)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AmountUnit)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmountValue).HasColumnType("numeric(2, 1)");

                entity.Property(e => e.Attribute)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Beer)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.BeerId)
                    .HasConstraintName("FK_INGREDIE_REFERENCE_BEER");

                entity.HasOne(d => d.IngredienteType)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.IngredienteTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INGREDIE_REFERENCE_INGREDIE");
            });

            modelBuilder.Entity<IngredientType>(entity =>
            {
                entity.HasKey(e => e.IngredienteTypeId)
                    .HasName("PK_INGREDIENTTYPE");

                entity.Property(e => e.IngredienteTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Method>(entity =>
            {
                entity.HasIndex(e => e.MethodId, "Idx_MethodId");

                entity.Property(e => e.TemperatureUnit)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Beer)
                    .WithMany(p => p.Method)
                    .HasForeignKey(d => d.BeerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_METHOD_REFERENCE_BEER");

                entity.HasOne(d => d.MethodType)
                    .WithMany(p => p.Method)
                    .HasForeignKey(d => d.MethodTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_METHOD_REFERENCE_METHODTY");
            });

            modelBuilder.Entity<MethodType>(entity =>
            {
                entity.Property(e => e.MethodTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemperatureUnit>(entity =>
            {
                entity.HasKey(e => e.IdTemperatureUnit)
                    .HasName("PK_TEMPERATUREUNIT");

                entity.Property(e => e.IdTemperatureUnit).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.HasIndex(e => e.VolumeId, "Idx_VolumeId");

                entity.Property(e => e.VolumeId).ValueGeneratedNever();

                entity.Property(e => e.VolumeUnit)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Beer)
                    .WithMany(p => p.Volume)
                    .HasForeignKey(d => d.BeerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VOLUME_REFERENCE_BEER");

                entity.HasOne(d => d.VolumeType)
                    .WithMany(p => p.Volume)
                    .HasForeignKey(d => d.VolumeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VOLUME_REFERENCE_VOLUMETY");
            });

            modelBuilder.Entity<VolumeType>(entity =>
            {
                entity.Property(e => e.VolumeTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VolumeUnit>(entity =>
            {
                entity.Property(e => e.VolumeUnitId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}