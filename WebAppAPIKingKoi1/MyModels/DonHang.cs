using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAppAPIKingKoi1.MyModels;

[Table("Don_Hang")]
public partial class DonHang
{
    [Key]
    [Column("Ma_Don_Hang")]
    public int MaDonHang { get; set; }

    [Column("Ma_Khach")]
    [StringLength(10)]
    public string? MaKhach { get; set; }

    [Column("Ma_Nhan_Vien")]
    [StringLength(10)]
    public string? MaNhanVien { get; set; }

    [Column("Ma_Van_Chuyen")]
    [StringLength(10)]
    public string? MaVanChuyen { get; set; }

    [Column("Ngay_Dat_Hang", TypeName = "datetime")]
    public DateTime? NgayDatHang { get; set; }

    [ForeignKey("MaKhach")]
    [InverseProperty("DonHangs")]
    public virtual KhachHang? MaKhachNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("DonHangs")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    [ForeignKey("MaVanChuyen")]
    [InverseProperty("DonHangs")]
    public virtual DichVuVanChuyen? MaVanChuyenNavigation { get; set; }
}
