using System.Text;
using System.Threading.Tasks;
//using KDOS.Repositories.Interface;
using KDOS.Service.Interface;

namespace KDOS.Service
{
    public interface IBaseSer 
    {
        IBangGiaSer bangGiaser { get; }
        ICaKoiSer caKoiser { get; }
        IChiTietDonHangSer chiTietdonhangser { get; }
        IDichVuVanChuyenSer dichVuvanchuyenser { get; }
        IDonHangSer donHangser { get; }
        IKhachHangSer khachHangser { get; }
        INhanVienSer nhanVienser { get; }
        IPhanHoiSer phanHoiser { get; }
    }
}
