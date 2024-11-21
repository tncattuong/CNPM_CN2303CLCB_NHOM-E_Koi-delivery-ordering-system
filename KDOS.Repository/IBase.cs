using KDOS.Repository.Interface;

namespace KDOS.Repository
{
    public interface IBase
    {
        IBangGiaRepository bangGiarepository { get; }
        ICaKoiRepository caKoirepository { get; }
        IChiTietDonHangRepository chiTietdonhangrepository { get; }
        IDichVuVanChuyenRepository dichVuvanchuyenrepository { get; }
        IDonHangRepository donHangrepository { get; }
        IKhachHangRepository khachHangrepository { get; }
        INhanVienRepository nhanVienrepository { get; }
        IPhanHoiRepository phanHoirepository { get; }
    }
}