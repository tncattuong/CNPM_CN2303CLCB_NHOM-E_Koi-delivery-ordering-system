using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class DichVuVanChuyen
{
    public string MaVanChuyen { get; set; } = null!;

    public string? MaDonViVanChuyen { get; set; }

    public string? MaPhuongThuc { get; set; }

    public string? TenDonVi { get; set; }

    public string? TenVanChuyen { get; set; }

    public int? GiaCuoc { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgayChinhSua { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
