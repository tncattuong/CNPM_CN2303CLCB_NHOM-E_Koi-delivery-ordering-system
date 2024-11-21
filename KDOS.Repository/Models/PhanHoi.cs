using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class PhanHoi
{
    public int MaPhanHoi { get; set; }

    public string? MaKhach { get; set; }

    public int? MaDonHang { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayPhanHoi { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; }

    public virtual KhachHang? MaKhachNavigation { get; set; }
}
