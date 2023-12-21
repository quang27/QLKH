using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GUIs.Models.EF;

public partial class KhoahocContext : DbContext
{
    public KhoahocContext()
    {
    }

    public KhoahocContext(DbContextOptions<KhoahocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiHoc> BaiHocs { get; set; }

    public virtual DbSet<ChuDe> ChuDes { get; set; }

    public virtual DbSet<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }

    public virtual DbSet<GiaoVien> GiaoViens { get; set; }

    public virtual DbSet<HocVien> HocViens { get; set; }

    public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }

    public virtual DbSet<TaiLieu> TaiLieus { get; set; }

    public virtual DbSet<TaiTaiLieu> TaiTaiLieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HMGKD90;Initial Catalog=KHOAHOC;Persist Security Info=True;User ID=sa;Password=1; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiHoc>(entity =>
        {
            entity.ToTable("BAI_HOC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChudeId).HasColumnName("ChudeID");
            entity.Property(e => e.Icon).HasMaxLength(550);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Ngaytao).HasColumnType("datetime");
            entity.Property(e => e.Vip).HasColumnName("VIP");

            entity.HasOne(d => d.Chude).WithMany(p => p.BaiHocs)
                .HasForeignKey(d => d.ChudeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BAI_HOC_CHU_DE");
        });

        modelBuilder.Entity<ChuDe>(entity =>
        {
            entity.ToTable("CHU_DE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Icon).HasMaxLength(550);
            entity.Property(e => e.KhoahocId).HasColumnName("KhoahocID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Ngaytao).HasColumnType("datetime");
            entity.Property(e => e.Vip).HasColumnName("VIP");

            entity.HasOne(d => d.Khoahoc).WithMany(p => p.ChuDes)
                .HasForeignKey(d => d.KhoahocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHU_DE_KHOA_HOC");
        });

        modelBuilder.Entity<DangKyKhoaHoc>(entity =>
        {
            entity.ToTable("DANG_KY_KHOA_HOC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HocvienId).HasColumnName("HocvienID");
            entity.Property(e => e.KhoahocId).HasColumnName("KhoahocID");
            entity.Property(e => e.Ngaydangky).HasColumnType("datetime");

            entity.HasOne(d => d.Hocvien).WithMany(p => p.DangKyKhoaHocs)
                .HasForeignKey(d => d.HocvienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DANG_KY_KHOA_HOC_HOC_VIEN");

            entity.HasOne(d => d.Khoahoc).WithMany(p => p.DangKyKhoaHocs)
                .HasForeignKey(d => d.KhoahocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DANG_KY_KHOA_HOC_KHOA_HOC");
        });

        modelBuilder.Entity<GiaoVien>(entity =>
        {
            entity.ToTable("GIAO_VIEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<HocVien>(entity =>
        {
            entity.ToTable("HOC_VIEN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<KhoaHoc>(entity =>
        {
            entity.ToTable("KHOA_HOC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GiaovienId).HasColumnName("GiaovienID");
            entity.Property(e => e.Icon).HasMaxLength(550);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Ngaybatdau).HasColumnType("datetime");
            entity.Property(e => e.Ngayketthuc).HasColumnType("datetime");
            entity.Property(e => e.Ngaytao).HasColumnType("datetime");
            entity.Property(e => e.Vip).HasColumnName("VIP");

            entity.HasOne(d => d.Giaovien).WithMany(p => p.KhoaHocs)
                .HasForeignKey(d => d.GiaovienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KHOA_HOC_GIAO_VIEN");
        });

        modelBuilder.Entity<TaiLieu>(entity =>
        {
            entity.ToTable("TAI_LIEU");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BaihocId).HasColumnName("BaihocID");
            entity.Property(e => e.Icon).HasMaxLength(250);
            entity.Property(e => e.Link).HasMaxLength(350);
            entity.Property(e => e.Loai).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Ngaytai).HasColumnType("datetime");
            entity.Property(e => e.Vip).HasColumnName("VIP");

            entity.HasOne(d => d.Baihoc).WithMany(p => p.TaiLieus)
                .HasForeignKey(d => d.BaihocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TAI_LIEU_BAI_HOC");
        });

        modelBuilder.Entity<TaiTaiLieu>(entity =>
        {
            entity.ToTable("TAI_TAI_LIEU");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GiaovienId).HasColumnName("GiaovienID");
            entity.Property(e => e.HocvienId).HasColumnName("HocvienID");
            entity.Property(e => e.Ngaytai).HasColumnType("datetime");
            entity.Property(e => e.TailieuId).HasColumnName("TailieuID");

            entity.HasOne(d => d.Giaovien).WithMany(p => p.TaiTaiLieus)
                .HasForeignKey(d => d.GiaovienId)
                .HasConstraintName("FK_TAI_TAI_LIEU_GIAO_VIEN");

            entity.HasOne(d => d.Hocvien).WithMany(p => p.TaiTaiLieus)
                .HasForeignKey(d => d.HocvienId)
                .HasConstraintName("FK_TAI_TAI_LIEU_HOC_VIEN");

            entity.HasOne(d => d.Tailieu).WithMany(p => p.TaiTaiLieus)
                .HasForeignKey(d => d.TailieuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TAI_TAI_LIEU_TAI_LIEU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
