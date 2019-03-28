using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FarmProject.Models
{
    public partial class FarmersdbContext : DbContext
    {
        public FarmersdbContext()
        {
        }

        public FarmersdbContext(DbContextOptions<FarmersdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Farm> Farm { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<Participates> Participates { get; set; }
        public virtual DbSet<Productcategory> Productcategory { get; set; }
        public virtual DbSet<Sells> Sells { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost; Database=farmersdb; Uid=root; Pwd=Pipipi98; SslMode=Preferred;");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farm>(entity =>
            {
                entity.ToTable("farm");

                entity.Property(e => e.FarmId)
                    .HasColumnName("farmID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MainProduct)
                    .HasColumnName("mainProduct")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(2)");
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.ToTable("market");

                entity.Property(e => e.MarketId)
                    .HasColumnName("marketID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Credit)
                    .IsRequired()
                    .HasColumnName("credit")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(9,6)");

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasColumnType("decimal(9,6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("varchar(2)");
            });

            modelBuilder.Entity<Participates>(entity =>
            {
                entity.HasKey(e => e.ParticipationId)
                    .HasName("PRIMARY");

                entity.ToTable("participates");

                entity.HasIndex(e => e.MarketId)
                    .HasName("marketID_idx");

                entity.HasIndex(e => e.VendorId)
                    .HasName("vendorID_idx");

                entity.Property(e => e.ParticipationId)
                    .HasColumnName("participationID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MarketId)
                    .HasColumnName("marketID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VendorId)
                    .HasColumnName("vendorID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Market)
                    .WithMany(p => p.Participates)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("marketID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Participates)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vendorID");
            });

            modelBuilder.Entity<Productcategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("productcategory");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Sells>(entity =>
            {
                entity.HasKey(e => e.SellId)
                    .HasName("PRIMARY");

                entity.ToTable("sells");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("categoryID_idx");

                entity.HasIndex(e => e.VendorId)
                    .HasName("vendorID_idx");

                entity.Property(e => e.SellId)
                    .HasColumnName("sellID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VendorId)
                    .HasColumnName("vendorID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Sells)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Sells)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vID");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.HasIndex(e => e.FarmId)
                    .HasName("farmID_idx");

                entity.Property(e => e.VendorId)
                    .HasColumnName("vendorID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FarmId)
                    .HasColumnName("farmID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Stallcount)
                    .HasColumnName("stallcount")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("farmID");
            });
        }
    }
}
