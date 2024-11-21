using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class BangGia
{
    public int MaGia { get; set; }

    public string? MaCa { get; set; }

    public int? GiaVanChuyen { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual CaKoi? MaCaNavigation { get; set; }
}
