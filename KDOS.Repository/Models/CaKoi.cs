using System;
using System.Collections.Generic;

namespace KDOS.Repository.Models;

public partial class CaKoi
{
    public string MaCa { get; set; } = null!;

    public string? LoaiCa { get; set; }

    public string? MauSac { get; set; }

    public decimal? KichThuoc { get; set; }

    public int? Tuoi { get; set; }

    public int? GiaBan { get; set; }

    public virtual ICollection<BangGia> BangGia { get; set; } = new List<BangGia>();

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();
}
