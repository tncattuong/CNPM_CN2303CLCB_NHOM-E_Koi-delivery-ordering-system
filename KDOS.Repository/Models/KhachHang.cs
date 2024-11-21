using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class KhachHang
{
    public string MaKhach { get; set; } = null!;

    public string? TenKhach { get; set; }

    public bool? GioiTinhKhach { get; set; }

    public string? DiaChiKhach { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();
}
