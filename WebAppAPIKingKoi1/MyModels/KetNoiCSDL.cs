using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppAPIKingKoi1.MyModels;

public partial class KetNoiCSDL : DbContext
{
    public KetNoiCSDL()
    {
    }

    public KetNoiCSDL(DbContextOptions<KetNoiCSDL> options)
        : base(options)
    {
    }

    public virtual DbSet<DichVuVanChuyen> DichVuVanChuyens { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-EU3JP5FK;database=KingKoi;uid=sa;pwd=123;encrypt=false;");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DichVuVanChuyen>(entity =>
        {
            entity.HasKey(e => e.MaVanChuyen).HasName("PK__Dich_Vu___43BA147F70B58217");

            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__Don_Hang__FD0F413D110D6DF7");

            entity.Property(e => e.NgayDatHang).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MaKhachNavigation).WithMany(p => p.DonHangs)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Don_Hang__Ma_Kha__5812160E");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.DonHangs)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Don_Hang__Ma_Nha__59063A47");

            entity.HasOne(d => d.MaVanChuyenNavigation).WithMany(p => p.DonHangs)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Don_Hang__Ma_Van__59FA5E80");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhach).HasName("PK__Khach_Ha__4AAE7BBC76DA5F6E");

            entity.Property(e => e.NgayChinhSua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__Nhan_Vie__7AB896892F83DAFB");

            entity.Property(e => e.CapNhatVaoNgay).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ThemVaoNgay).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
