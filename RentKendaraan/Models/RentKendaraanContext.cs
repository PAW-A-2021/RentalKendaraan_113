using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentKendaraan.Models
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

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Jaminan> Jaminan { get; set; }
        public virtual DbSet<JenisKendaraan> JenisKendaraan { get; set; }
        public virtual DbSet<Kendaraan> Kendaraan { get; set; }
        public virtual DbSet<KondisiKendaraan> KondisiKendaraan { get; set; }
        public virtual DbSet<Peminjaman> Peminjaman { get; set; }
        public virtual DbSet<Pengembalian> Pengembalian { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer)
                    .HasColumnName("id_customer")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasColumnName("alamat")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdGender).HasColumnName("id_gender");

                entity.Property(e => e.NamaCustomer)
                    .HasColumnName("nama_customer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nik)
                    .HasColumnName("NIK")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.NoHp)
                    .HasColumnName("no_hp")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGenderNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.IdGender)
                    .HasConstraintName("FK_Customer_Gender");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.IdGender);

                entity.Property(e => e.IdGender)
                    .HasColumnName("id_gender")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaGender)
                    .HasColumnName("nama_gender")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jaminan>(entity =>
            {
                entity.HasKey(e => e.IdJaminan);

                entity.Property(e => e.IdJaminan)
                    .HasColumnName("id_jaminan")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaJaminan)
                    .HasColumnName("nama_jaminan")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdJenisKendaraan);

                entity.ToTable("Jenis_kendaraan");

                entity.Property(e => e.IdJenisKendaraan)
                    .HasColumnName("id_jenis_kendaraan")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaJenisKendaraan)
                    .HasColumnName("nama_jenis_kendaraan")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKendaraan);

                entity.Property(e => e.IdKendaraan)
                    .HasColumnName("id_kendaraan")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdJenisKendaraan).HasColumnName("id_jenis_kendaraan");

                entity.Property(e => e.Ketersediaan)
                    .HasColumnName("ketersediaan")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NamaKendaraan)
                    .HasColumnName("nama_kendaraan")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NoPolisi)
                    .HasColumnName("no_polisi")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NoStnk)
                    .HasColumnName("no_stnk")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdJenisKendaraanNavigation)
                    .WithMany(p => p.Kendaraan)
                    .HasForeignKey(d => d.IdJenisKendaraan)
                    .HasConstraintName("FK_Kendaraan_Jenis_kendaraan");
            });

            modelBuilder.Entity<KondisiKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKondisi);

                entity.ToTable("Kondisi_Kendaraan");

                entity.Property(e => e.IdKondisi)
                    .HasColumnName("id_kondisi")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaKondisi)
                    .HasColumnName("nama_kondisi")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Peminjaman>(entity =>
            {
                entity.HasKey(e => e.IdPeminjaman);

                entity.Property(e => e.IdPeminjaman)
                    .HasColumnName("id_peminjaman")
                    .ValueGeneratedNever();

                entity.Property(e => e.Biaya).HasColumnName("biaya");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdJaminan).HasColumnName("id_jaminan");

                entity.Property(e => e.IdKendaraan).HasColumnName("id_kendaraan");

                entity.Property(e => e.TglPeminjaman)
                    .HasColumnName("tgl_peminjaman")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Peminjaman)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Peminjaman_Customer");

                entity.HasOne(d => d.IdJaminanNavigation)
                    .WithMany(p => p.Peminjaman)
                    .HasForeignKey(d => d.IdJaminan)
                    .HasConstraintName("FK_Peminjaman_Jaminan");

                entity.HasOne(d => d.IdKendaraanNavigation)
                    .WithMany(p => p.Peminjaman)
                    .HasForeignKey(d => d.IdKendaraan)
                    .HasConstraintName("FK_Peminjaman_Kendaraan");
            });

            modelBuilder.Entity<Pengembalian>(entity =>
            {
                entity.HasKey(e => e.IdPengembalian);

                entity.Property(e => e.IdPengembalian)
                    .HasColumnName("id_pengembalian")
                    .ValueGeneratedNever();

                entity.Property(e => e.Denda).HasColumnName("denda");

                entity.Property(e => e.IdKondisi).HasColumnName("id_kondisi");

                entity.Property(e => e.IdPeminjaman).HasColumnName("id_peminjaman");

                entity.Property(e => e.TglPengembalian)
                    .HasColumnName("tgl_pengembalian")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdKondisiNavigation)
                    .WithMany(p => p.Pengembalian)
                    .HasForeignKey(d => d.IdKondisi)
                    .HasConstraintName("FK_Pengembalian_Kondisi_Kendaraan");

                entity.HasOne(d => d.IdPeminjamanNavigation)
                    .WithMany(p => p.Pengembalian)
                    .HasForeignKey(d => d.IdPeminjaman)
                    .HasConstraintName("FK_Pengembalian_Peminjaman");
            });
        }
    }
}
