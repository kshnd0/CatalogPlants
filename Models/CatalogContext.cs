using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CatalogPlants.Models;

public partial class CatalogContext : DbContext
{
    public CatalogContext()
    {
    }

    public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CareLog> CareLogs { get; set; }

    public virtual DbSet<CareRequirement> CareRequirements { get; set; }

    public virtual DbSet<DiseaseHistory> DiseaseHistories { get; set; }

    public virtual DbSet<LifeForm> LifeForms { get; set; }

    public virtual DbSet<Pathogen> Pathogens { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PlantParameter> PlantParameters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Catalog_plant ;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CareLog>(entity =>
        {
            entity.HasKey(e => e.CareLogId).HasName("PK__care_log__D5D9827C98BAB23F");

            entity.ToTable("care_log");

            entity.Property(e => e.CareLogId).HasColumnName("care_log_id");
            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.PlantId).HasColumnName("plant_id");

            entity.HasOne(d => d.Plant).WithMany(p => p.CareLogs)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__care_log__plant___6E01572D");
        });

        modelBuilder.Entity<CareRequirement>(entity =>
        {
            entity.HasKey(e => e.CareRequirementsId).HasName("PK__care_req__87697E1F9C13E252");

            entity.ToTable("care_requirements");

            entity.Property(e => e.CareRequirementsId).HasColumnName("care_requirements_id");
            entity.Property(e => e.Lighting).HasColumnName("lighting");
            entity.Property(e => e.TemperatureSummer)
                .HasMaxLength(100)
                .HasColumnName("temperature_summer");
            entity.Property(e => e.TemperatureWinter)
                .HasMaxLength(100)
                .HasColumnName("temperature_winter");
            entity.Property(e => e.WateringSummer).HasColumnName("watering_summer");
            entity.Property(e => e.WateringWinter).HasColumnName("watering_winter");
        });

        modelBuilder.Entity<DiseaseHistory>(entity =>
        {
            entity.HasKey(e => e.DiseaseHistoryId).HasName("PK__disease___B57BE320859F9758");

            entity.ToTable("disease_history");

            entity.Property(e => e.DiseaseHistoryId).HasColumnName("disease_history_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.PathogenId).HasColumnName("pathogen_id");
            entity.Property(e => e.PlantId).HasColumnName("plant_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Pathogen).WithMany(p => p.DiseaseHistories)
                .HasForeignKey(d => d.PathogenId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__disease_h__patho__6A30C649");

            entity.HasOne(d => d.Plant).WithMany(p => p.DiseaseHistories)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__disease_h__plant__693CA210");
        });

        modelBuilder.Entity<LifeForm>(entity =>
        {
            entity.HasKey(e => e.LifeFormId).HasName("PK__life_for__8A05DA1D6066FC0D");

            entity.ToTable("life_form");

            entity.Property(e => e.LifeFormId).HasColumnName("life_form_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Pathogen>(entity =>
        {
            entity.HasKey(e => e.PathogenId).HasName("PK__pathogen__AC3DF02240905B4B");

            entity.ToTable("pathogen");

            entity.Property(e => e.PathogenId).HasColumnName("pathogen_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.PlantId).HasName("PK__plant__A576B3B4F748CF13");

            entity.ToTable("plant");

            entity.Property(e => e.PlantId).HasColumnName("plant_id");
            entity.Property(e => e.CareRequirementsId).HasColumnName("care_requirements_id");
            entity.Property(e => e.LatinName)
                .HasMaxLength(255)
                .HasColumnName("latin_name");
            entity.Property(e => e.LifeFormId).HasColumnName("life_form_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.CareRequirements).WithMany(p => p.Plants)
                .HasForeignKey(d => d.CareRequirementsId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__plant__care_requ__619B8048");

            entity.HasOne(d => d.LifeForm).WithMany(p => p.Plants)
                .HasForeignKey(d => d.LifeFormId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__plant__life_form__60A75C0F");
        });

        modelBuilder.Entity<PlantParameter>(entity =>
        {
            entity.HasKey(e => e.PlantParametersId).HasName("PK__plant_pa__FB7809D0ED1DE9E0");

            entity.ToTable("plant_parameters");

            entity.Property(e => e.PlantParametersId).HasColumnName("plant_parameters_id");
            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .HasColumnName("age");
            entity.Property(e => e.PlantId).HasColumnName("plant_id");
            entity.Property(e => e.PlantingDate)
                .HasColumnType("datetime")
                .HasColumnName("planting_date");
            entity.Property(e => e.Size)
                .HasMaxLength(100)
                .HasColumnName("size");

            entity.HasOne(d => d.Plant).WithMany(p => p.PlantParameters)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__plant_par__plant__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
