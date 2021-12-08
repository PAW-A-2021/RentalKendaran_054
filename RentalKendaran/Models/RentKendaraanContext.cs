using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RentalKendaran.Models
{
    public partial class RentKendaraanContext : DbContext
    {
        public RentKendaraanContext()
        {
        }

        public RentKendaraanContext(DbContextOptions<RentKendaraanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Jaminan> Jaminans { get; set; }
        public virtual DbSet<JenisKendaraan> JenisKendaraans { get; set; }
        public virtual DbSet<Kendaraan> Kendaraans { get; set; }
        public virtual DbSet<Kondisi> Kondisis { get; set; }
        public virtual DbSet<Pengembaliaan> Pengembaliaans { get; set; }
        public virtual DbSet<Pengembalian> Pengembalians { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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

                entity.Property(e => e.IdGender).HasColumnName("ID_Gender");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.Nik)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("NIK");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_HP");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.IdGender);

                entity.ToTable("Gender");

                entity.Property(e => e.IdGender)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Gender");

                entity.Property(e => e.NamaGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Gender");

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithOne(p => p.Gender)
                    .HasForeignKey<Gender>(d => d.IdGender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gender_Customer");
            });

            modelBuilder.Entity<Jaminan>(entity =>
            {
                entity.HasKey(e => e.IdJaminan);

                entity.ToTable("Jaminan");

                entity.Property(e => e.IdJaminan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Jaminan");

                entity.Property(e => e.NamaJaminan)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Jaminan");

                entity.HasOne(d => d.IdJaminanNavigation)
                    .WithOne(p => p.Jaminan)
                    .HasForeignKey<Jaminan>(d => d.IdJaminan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jaminan_pengembalian");
            });

            modelBuilder.Entity<JenisKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdJenisKendaraan);

                entity.ToTable("Jenis_Kendaraan");

                entity.Property(e => e.IdJenisKendaraan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Jenis_Kendaraan");

                entity.Property(e => e.NamaJenisKendaraan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Jenis_Kendaraan");

                entity.HasOne(d => d.IdJenisKendaraanNavigation)
                    .WithOne(p => p.JenisKendaraan)
                    .HasForeignKey<JenisKendaraan>(d => d.IdJenisKendaraan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jenis_Kendaraan_kendaraan");
            });

            modelBuilder.Entity<Kendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKendaraan);

                entity.ToTable("kendaraan");

                entity.Property(e => e.IdKendaraan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Kendaraan");

                entity.Property(e => e.IdJenisKendaraan).HasColumnName("ID_Jenis_Kendaraan");

                entity.Property(e => e.Ketersediaan)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NamaKendaraan)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Kendaraan");

                entity.Property(e => e.NoPolisi)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("No_Polisi");

                entity.Property(e => e.NoStnk)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("No_STNK");
            });

            modelBuilder.Entity<Kondisi>(entity =>
            {
                entity.HasKey(e => e.IdKondisi);

                entity.ToTable("kondisi");

                entity.Property(e => e.IdKondisi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Kondisi");

                entity.Property(e => e.NamaKondisi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Kondisi");

                entity.HasOne(d => d.IdKondisiNavigation)
                    .WithOne(p => p.Kondisi)
                    .HasForeignKey<Kondisi>(d => d.IdKondisi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_kondisi_pengembaliaan");
            });

            modelBuilder.Entity<Pengembaliaan>(entity =>
            {
                entity.HasKey(e => e.IdPengembalian);

                entity.ToTable("pengembaliaan");

                entity.Property(e => e.IdPengembalian)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pengembalian");

                entity.Property(e => e.IdKondisi).HasColumnName("ID_Kondisi");

                entity.Property(e => e.IdPeminjaman).HasColumnName("ID_Peminjaman");

                entity.Property(e => e.TglPengembalian)
                    .HasColumnType("datetime")
                    .HasColumnName("Tgl_Pengembalian");
            });

            modelBuilder.Entity<Pengembalian>(entity =>
            {
                entity.HasKey(e => e.IdPeminjaman);

                entity.ToTable("pengembalian");

                entity.Property(e => e.IdPeminjaman)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Peminjaman");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdJaminan).HasColumnName("ID_Jaminan");

                entity.Property(e => e.IdKendaraan).HasColumnName("ID_Kendaraan");

                entity.Property(e => e.TglPeminjaman)
                    .HasColumnType("datetime")
                    .HasColumnName("Tgl_Peminjaman");

                entity.HasOne(d => d.IdKendaraanNavigation)
                    .WithMany(p => p.Pengembalians)
                    .HasForeignKey(d => d.IdKendaraan)
                    .HasConstraintName("FK_pengembalian_kendaraan");

                entity.HasOne(d => d.IdPeminjamanNavigation)
                    .WithOne(p => p.Pengembalian)
                    .HasForeignKey<Pengembalian>(d => d.IdPeminjaman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pengembalian_Customer");

                entity.HasOne(d => d.IdPeminjaman1)
                    .WithOne(p => p.Pengembalian)
                    .HasForeignKey<Pengembalian>(d => d.IdPeminjaman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pengembalian_pengembaliaan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
