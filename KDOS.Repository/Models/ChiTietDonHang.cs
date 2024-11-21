using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class ChiTietDonHang
{
    public int MaCtDonHang { get; set; }

    public int? MaDonHang { get; set; }

    public string? MaCa { get; set; }

    public int? SoLuong { get; set; }

    public int? MaGia { get; set; }

    public virtual CaKoi? MaCaNavigation { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; }

    public virtual BangGia? MaGiaNavigation { get; set; }
}
