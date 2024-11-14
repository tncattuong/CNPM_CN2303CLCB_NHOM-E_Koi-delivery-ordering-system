using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAppAPIKingKoi1.MyModels;

[Table("Nhan_Vien")]
[Index("Email", Name = "UQ__Nhan_Vie__A9D10534AB805786", IsUnique = true)]
public partial class NhanVien
{
    [Key]
    [Column("Ma_Nhan_Vien")]
    [StringLength(10)]
    public string MaNhanVien { get; set; } = null!;

    [Column("Ho_Ten")]
    [StringLength(255)]
    public string? HoTen { get; set; }

    public int? Tuoi { get; set; }

    [Column("Gioi_Tinh")]
    public bool? GioiTinh { get; set; }

    [Column("Dia_Chi")]
    [StringLength(255)]
    public string? DiaChi { get; set; }

    [Column("So_Dien_Thoai")]
    [StringLength(15)]
    [Unicode(false)]
    public string? SoDienThoai { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("Mat_Khau")]
    [StringLength(255)]
    public string? MatKhau { get; set; }

    [Column("Them_Vao_Ngay", TypeName = "datetime")]
    public DateTime? ThemVaoNgay { get; set; }

    [Column("Cap_Nhat_Vao_Ngay", TypeName = "datetime")]
    public DateTime? CapNhatVaoNgay { get; set; }

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
