using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAppAPIKingKoi1.MyModels;

[Table("Dich_Vu_Van_Chuyen")]
public partial class DichVuVanChuyen
{
    [Key]
    [Column("Ma_Van_Chuyen")]
    [StringLength(10)]
    public string MaVanChuyen { get; set; } = null!;

    [Column("Ma_Don_Vi_Van_Chuyen")]
    [StringLength(10)]
    public string? MaDonViVanChuyen { get; set; }

    [Column("Ma_Phuong_Thuc")]
    [StringLength(10)]
    public string? MaPhuongThuc { get; set; }

    [Column("Ten_Don_Vi")]
    [StringLength(255)]
    public string? TenDonVi { get; set; }

    [Column("Ten_Van_Chuyen")]
    [StringLength(255)]
    public string? TenVanChuyen { get; set; }

    [Column("Gia_Cuoc")]
    public int? GiaCuoc { get; set; }

    [Column("Ngay_Tao", TypeName = "datetime")]
    public DateTime? NgayTao { get; set; }

    [Column("Ngay_Chinh_Sua", TypeName = "datetime")]
    public DateTime? NgayChinhSua { get; set; }

    [InverseProperty("MaVanChuyenNavigation")]
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
