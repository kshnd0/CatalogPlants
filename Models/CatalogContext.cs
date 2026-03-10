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

    public virtual DbSet<IstoriiBoleznej> IstoriiBoleznejs { get; set; }

    public virtual DbSet<ParametryRasteniya> ParametryRasteniyas { get; set; }

    public virtual DbSet<Patogen> Patogens { get; set; }

    public virtual DbSet<Rastenie> Rastenies { get; set; }

    public virtual DbSet<Semeistvo> Semeistvos { get; set; }

    public virtual DbSet<TrebovaniyaKUhodu> TrebovaniyaKUhodus { get; set; }

    public virtual DbSet<Uhod> Uhods { get; set; }

    public virtual DbSet<ZhiznennayaForma> ZhiznennayaFormas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DIANAKASHINA\\SQLEXPRESS;Database=Catalog_Plant ;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IstoriiBoleznej>(entity =>
        {
            entity.HasKey(e => e.IstoriyaId).HasName("PK__istorii___056351AA922896ED");

            entity.ToTable("istorii_boleznej");

            entity.Property(e => e.IstoriyaId).HasColumnName("istoriya_id");
            entity.Property(e => e.DataNachala).HasColumnName("data_nachala");
            entity.Property(e => e.DataOkonchaniya).HasColumnName("data_okonchaniya");
            entity.Property(e => e.Opisanie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("opisanie");
            entity.Property(e => e.PatogenId).HasColumnName("patogen_id");
            entity.Property(e => e.RastenieId).HasColumnName("rastenie_id");

            entity.HasOne(d => d.Patogen).WithMany(p => p.IstoriiBoleznejs)
                .HasForeignKey(d => d.PatogenId)
                .HasConstraintName("FK__istorii_b__patog__4AB81AF0");

            entity.HasOne(d => d.Rastenie).WithMany(p => p.IstoriiBoleznejs)
                .HasForeignKey(d => d.RastenieId)
                .HasConstraintName("FK__istorii_b__raste__49C3F6B7");
        });

        modelBuilder.Entity<ParametryRasteniya>(entity =>
        {
            entity.HasKey(e => e.ParametryId).HasName("PK__parametr__AF22EFBFB70108D8");

            entity.ToTable("parametry_rasteniya");

            entity.Property(e => e.ParametryId).HasColumnName("parametry_id");
            entity.Property(e => e.DataPosadki).HasColumnName("data_posadki");
            entity.Property(e => e.RastenieId).HasColumnName("rastenie_id");
            entity.Property(e => e.Razmery)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("razmery");
            entity.Property(e => e.Vozrast).HasColumnName("vozrast");

            entity.HasOne(d => d.Rastenie).WithMany(p => p.ParametryRasteniyas)
                .HasForeignKey(d => d.RastenieId)
                .HasConstraintName("FK__parametry__raste__440B1D61");
        });

        modelBuilder.Entity<Patogen>(entity =>
        {
            entity.HasKey(e => e.PatogenId).HasName("PK__patogen__A231528F218B8FEE");

            entity.ToTable("patogen");

            entity.Property(e => e.PatogenId).HasColumnName("patogen_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Opisanie)
                .HasColumnType("text")
                .HasColumnName("opisanie");
        });

        modelBuilder.Entity<Rastenie>(entity =>
        {
            entity.HasKey(e => e.RastenieId).HasName("PK__rastenie__1B275193E4A00240");

            entity.ToTable("rastenie");

            entity.Property(e => e.RastenieId).HasColumnName("rastenie_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NameLatin)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("name_latin");
            entity.Property(e => e.SemeistvoId).HasColumnName("semeistvo_id");
            entity.Property(e => e.TrebovaniyaId).HasColumnName("trebovaniya_id");
            entity.Property(e => e.ZhiznennayaFormaId).HasColumnName("zhiznennaya_forma_id");

            entity.HasOne(d => d.Semeistvo).WithMany(p => p.Rastenies)
                .HasForeignKey(d => d.SemeistvoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__rastenie__semeis__3F466844");

            entity.HasOne(d => d.Trebovaniya).WithMany(p => p.Rastenies)
                .HasForeignKey(d => d.TrebovaniyaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__rastenie__trebov__412EB0B6");

            entity.HasOne(d => d.ZhiznennayaForma).WithMany(p => p.Rastenies)
                .HasForeignKey(d => d.ZhiznennayaFormaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__rastenie__zhizne__403A8C7D");
        });

        modelBuilder.Entity<Semeistvo>(entity =>
        {
            entity.HasKey(e => e.SemeistvoId).HasName("PK__semeistv__1609584F895FB3A5");

            entity.ToTable("semeistvo");

            entity.Property(e => e.SemeistvoId).HasColumnName("semeistvo_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NameLatin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_latin");
        });

        modelBuilder.Entity<TrebovaniyaKUhodu>(entity =>
        {
            entity.HasKey(e => e.TrebovaniyaId).HasName("PK__trebovan__0B7981EBD1657AE0");

            entity.ToTable("trebovaniya_k_uhodu");

            entity.Property(e => e.TrebovaniyaId).HasColumnName("trebovaniya_id");
            entity.Property(e => e.Osveshchenie)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("osveshchenie");
            entity.Property(e => e.PolivLetom)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("poliv_letom");
            entity.Property(e => e.PolivZimoy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("poliv_zimoy");
            entity.Property(e => e.TemperaturaLetom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("temperatura_letom");
            entity.Property(e => e.TemperaturaZimoy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("temperatura_zimoy");
        });

        modelBuilder.Entity<Uhod>(entity =>
        {
            entity.HasKey(e => e.UhodId).HasName("PK__uhod__8163373FF12552C1");

            entity.ToTable("uhod");

            entity.Property(e => e.UhodId).HasColumnName("uhod_id");
            entity.Property(e => e.DataIVremya)
                .HasColumnType("datetime")
                .HasColumnName("data_i_vremya");
            entity.Property(e => e.Opisanie)
                .HasColumnType("text")
                .HasColumnName("opisanie");
            entity.Property(e => e.RastenieId).HasColumnName("rastenie_id");

            entity.HasOne(d => d.Rastenie).WithMany(p => p.Uhods)
                .HasForeignKey(d => d.RastenieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uhod__rastenie_i__46E78A0C");
        });

        modelBuilder.Entity<ZhiznennayaForma>(entity =>
        {
            entity.HasKey(e => e.ZhiznennayaFormaId).HasName("PK__zhiznenn__3F92DBC2C8664282");

            entity.ToTable("zhiznennaya_forma");

            entity.Property(e => e.ZhiznennayaFormaId).HasColumnName("zhiznennaya_forma_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
