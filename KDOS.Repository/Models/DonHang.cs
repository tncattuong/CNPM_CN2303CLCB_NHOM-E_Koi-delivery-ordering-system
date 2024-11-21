using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class DonHang
{
    public int MaDonHang { get; set; }

    public string? MaKhach { get; set; }

    public string? MaNhanVien { get; set; }

    public string? MaVanChuyen { get; set; }

    public DateTime? NgayDatHang { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual KhachHang? MaKhachNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual DichVuVanChuyen? MaVanChuyenNavigation { get; set; }

    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();
}
