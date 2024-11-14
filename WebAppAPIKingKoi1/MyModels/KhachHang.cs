using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAppAPIKingKoi1.MyModels;

[Table("Khach_Hang")]
[Index("Email", Name = "UQ__Khach_Ha__A9D10534A76D2831", IsUnique = true)]
public partial class KhachHang
{
    [Key]
    [Column("Ma_Khach")]
    [StringLength(10)]
    public string MaKhach { get; set; } = null!;

    [Column("Ten_Khach")]
    [StringLength(255)]
    public string? TenKhach { get; set; }

    [Column("Gioi_Tinh_Khach")]
    public bool? GioiTinhKhach { get; set; }

    [Column("Dia_Chi_Khach")]
    [StringLength(255)]
    public string? DiaChiKhach { get; set; }

    [Column("So_Dien_Thoai")]
    [StringLength(15)]
    [Unicode(false)]
    public string? SoDienThoai { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("Ngay_Tao", TypeName = "datetime")]
    public DateTime? NgayTao { get; set; }

    [Column("Ngay_Chinh_Sua", TypeName = "datetime")]
    public DateTime? NgayChinhSua { get; set; }

    [InverseProperty("MaKhachNavigation")]
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
