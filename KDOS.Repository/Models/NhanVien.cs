using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? HoTen { get; set; }

    public int? Tuoi { get; set; }

    public bool? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? MatKhau { get; set; }

    public DateTime? ThemVaoNgay { get; set; }

    public DateTime? CapNhatVaoNgay { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
