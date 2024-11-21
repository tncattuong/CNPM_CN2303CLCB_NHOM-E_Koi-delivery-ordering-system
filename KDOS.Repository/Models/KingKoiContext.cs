using System;
using System.Collections.Generic;
using KDOS.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace KDOS.Repository.Models;

public partial class KingKoiContext : DbContext
{
    public KingKoiContext()
    {
    }

    public KingKoiContext(DbContextOptions<KingKoiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangGia> BangGias { get; set; }

    public virtual DbSet<CaKoi> CaKois { get; set; }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<DichVuVanChuyen> DichVuVanChuyens { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanHoi> PhanHois { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-EU3JP5FK;Initial Catalog=KingKoi;Integrated Security=True;Trust Server Certificate=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangGia>(entity =>
        {
            entity.HasKey(e => e.MaGia).HasName("PK__Bang_Gia__3D0FC03C65EAEFA0");

            entity.ToTable("Bang_Gia");

            entity.Property(e => e.MaGia).HasColumnName("Ma_Gia");
            entity.Property(e => e.GiaVanChuyen).HasColumnName("Gia_Van_Chuyen");
            entity.Property(e => e.MaCa)
                .HasMaxLength(10)
                .HasColumnName("Ma_Ca");
            entity.Property(e => e.NgayBatDau)
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Bat_Dau");
            entity.Property(e => e.NgayKetThuc)
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Ket_Thuc");

            entity.HasOne(d => d.MaCaNavigation).WithMany(p => p.BangGia)
                .HasForeignKey(d => d.MaCa)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Bang_Gia__Ma_Ca__1332DBDC");
        });

        modelBuilder.Entity<CaKoi>(entity =>
        {
            entity.HasKey(e => e.MaCa).HasName("PK__Ca_Koi__2E677D197D9745D0");

            entity.ToTable("Ca_Koi");

            entity.Property(e => e.MaCa)
                .HasMaxLength(10)
                .HasColumnName("Ma_Ca");
            entity.Property(e => e.GiaBan).HasColumnName("Gia_Ban");
            entity.Property(e => e.KichThuoc)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Kich_Thuoc");
            entity.Property(e => e.LoaiCa)
                .HasMaxLength(50)
                .HasColumnName("Loai_Ca");
            entity.Property(e => e.MauSac)
                .HasMaxLength(50)
                .HasColumnName("Mau_Sac");
        });

        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.MaCtDonHang).HasName("PK__Chi_Tiet__3E5C7E906C114ADF");

            entity.ToTable("Chi_Tiet_Don_Hang");

            entity.Property(e => e.MaCtDonHang).HasColumnName("Ma_Ct_Don_Hang");
            entity.Property(e => e.MaCa)
                .HasMaxLength(10)
                .HasColumnName("Ma_Ca");
            entity.Property(e => e.MaDonHang).HasColumnName("Ma_Don_Hang");
            entity.Property(e => e.MaGia).HasColumnName("Ma_Gia");
            entity.Property(e => e.SoLuong).HasColumnName("So_Luong");

            entity.HasOne(d => d.MaCaNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaCa)
                .HasConstraintName("FK__Chi_Tiet___Ma_Ca__17036CC0");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Chi_Tiet___Ma_Do__160F4887");

            entity.HasOne(d => d.MaGiaNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaGia)
                .HasConstraintName("FK__Chi_Tiet___Ma_Gi__17F790F9");
        });

        modelBuilder.Entity<DichVuVanChuyen>(entity =>
        {
            entity.HasKey(e => e.MaVanChuyen).HasName("PK__Dich_Vu___43BA147F70B58217");

            entity.ToTable("Dich_Vu_Van_Chuyen");

            entity.Property(e => e.MaVanChuyen)
                .HasMaxLength(10)
                .HasColumnName("Ma_Van_Chuyen");
            entity.Property(e => e.GiaCuoc).HasColumnName("Gia_Cuoc");
            entity.Property(e => e.MaDonViVanChuyen)
                .HasMaxLength(10)
                .HasColumnName("Ma_Don_Vi_Van_Chuyen");
            entity.Property(e => e.MaPhuongThuc)
                .HasMaxLength(10)
                .HasColumnName("Ma_Phuong_Thuc");
            entity.Property(e => e.NgayChinhSua)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Chinh_Sua");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Tao");
            entity.Property(e => e.TenDonVi)
                .HasMaxLength(255)
                .HasColumnName("Ten_Don_Vi");
            entity.Property(e => e.TenVanChuyen)
                .HasMaxLength(255)
                .HasColumnName("Ten_Van_Chuyen");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__Don_Hang__FD0F413D110D6DF7");

            entity.ToTable("Don_Hang");

            entity.Property(e => e.MaDonHang).HasColumnName("Ma_Don_Hang");
            entity.Property(e => e.MaKhach)
                .HasMaxLength(10)
                .HasColumnName("Ma_Khach");
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .HasColumnName("Ma_Nhan_Vien");
            entity.Property(e => e.MaVanChuyen)
                .HasMaxLength(10)
                .HasColumnName("Ma_Van_Chuyen");
            entity.Property(e => e.NgayDatHang)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Dat_Hang");

            entity.HasOne(d => d.MaKhachNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKhach)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Don_Hang__Ma_Kha__5812160E");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Don_Hang__Ma_Nha__59063A47");

            entity.HasOne(d => d.MaVanChuyenNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaVanChuyen)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Don_Hang__Ma_Van__59FA5E80");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhach).HasName("PK__Khach_Ha__4AAE7BBC76DA5F6E");

            entity.ToTable("Khach_Hang");

            entity.HasIndex(e => e.Email, "UQ__Khach_Ha__A9D10534A76D2831").IsUnique();

            entity.Property(e => e.MaKhach)
                .HasMaxLength(10)
                .HasColumnName("Ma_Khach");
            entity.Property(e => e.DiaChiKhach)
                .HasMaxLength(255)
                .HasColumnName("Dia_Chi_Khach");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinhKhach).HasColumnName("Gioi_Tinh_Khach");
            entity.Property(e => e.NgayChinhSua)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Chinh_Sua");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Tao");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("So_Dien_Thoai");
            entity.Property(e => e.TenKhach)
                .HasMaxLength(255)
                .HasColumnName("Ten_Khach");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__Nhan_Vie__7AB896892F83DAFB");

            entity.ToTable("Nhan_Vien");

            entity.HasIndex(e => e.Email, "UQ__Nhan_Vie__A9D10534AB805786").IsUnique();

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .HasColumnName("Ma_Nhan_Vien");
            entity.Property(e => e.CapNhatVaoNgay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Cap_Nhat_Vao_Ngay");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("Dia_Chi");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasColumnName("Gioi_Tinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("Ho_Ten");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("Mat_Khau");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("So_Dien_Thoai");
            entity.Property(e => e.ThemVaoNgay)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Them_Vao_Ngay");
        });

        modelBuilder.Entity<PhanHoi>(entity =>
        {
            entity.HasKey(e => e.MaPhanHoi).HasName("PK__Phan_Hoi__9A6946A5F7FE4B69");

            entity.ToTable("Phan_Hoi");

            entity.Property(e => e.MaPhanHoi).HasColumnName("Ma_Phan_Hoi");
            entity.Property(e => e.MaDonHang).HasColumnName("Ma_Don_Hang");
            entity.Property(e => e.MaKhach)
                .HasMaxLength(10)
                .HasColumnName("Ma_Khach");
            entity.Property(e => e.NgayPhanHoi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Ngay_Phan_Hoi");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(1000)
                .HasColumnName("Noi_Dung");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaDonHang)
                .HasConstraintName("FK__Phan_Hoi__Ma_Don__08B54D69");

            entity.HasOne(d => d.MaKhachNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaKhach)
                .HasConstraintName("FK__Phan_Hoi__Ma_Kha__07C12930");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
