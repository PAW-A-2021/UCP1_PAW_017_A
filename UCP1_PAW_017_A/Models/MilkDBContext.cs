using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_017_A.Models
{
    public partial class MilkDBContext : DbContext
    {
        public MilkDBContext()
        {
        }

        public MilkDBContext(DbContextOptions<MilkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Kurir> Kurirs { get; set; }
        public virtual DbSet<Produk> Produks { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Admin");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_HP");
            });

            modelBuilder.Entity<Kurir>(entity =>
            {
                entity.HasKey(e => e.IdKurir);

                entity.ToTable("Kurir");

                entity.Property(e => e.IdKurir)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Kurir");

                entity.Property(e => e.NamaKurir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Kurir");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_HP");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.ToTable("Produk");

                entity.Property(e => e.IdProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Produk");

                entity.Property(e => e.HargaProduk).HasColumnName("Harga_Produk");

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Produk");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdAdmin).HasColumnName("ID_Admin");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdKurir).HasColumnName("ID_Kurir");

                entity.Property(e => e.IdProduk).HasColumnName("ID_Produk");

                entity.Property(e => e.TotalTransaksi).HasColumnName("Total_Transaksi");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Transaksi_Admin");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Transaksi_Customer");

                entity.HasOne(d => d.IdKurirNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdKurir)
                    .HasConstraintName("FK_Transaksi_Kurir");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdProduk)
                    .HasConstraintName("FK_Transaksi_Produk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
