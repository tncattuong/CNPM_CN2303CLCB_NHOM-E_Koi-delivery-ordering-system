using KDOS.Repository;
using KDOS.Repository.Interface;
using KDOS.Repository.Models;
using KDOS.Service.Interface;
using System;

namespace KDOS.Service.Implement
{
    public class IplBaseSer : IBaseSer
    {
        private readonly IBase _baseRepository;

        // Constructor injection để cung cấp các repository cho các service
        public IplBaseSer(IBase baseRepository)
        {
            _baseRepository = baseRepository;
        }

        // Cung cấp các dịch vụ (services) thông qua Lazy initialization
        private IBangGiaSer _bangGiaser;
        public IBangGiaSer bangGiaser => _bangGiaser ?? (_bangGiaser = new IplBangGiaSer(_baseRepository));

        private ICaKoiSer _caKoiser;
        public ICaKoiSer caKoiser => _caKoiser ?? (_caKoiser = new IplCaKoiSer(_baseRepository));

        private IChiTietDonHangSer _chiTietdonhangser;
        public IChiTietDonHangSer chiTietdonhangser => _chiTietdonhangser ?? (_chiTietdonhangser = new IplChiTietDonHangSer(_baseRepository));

        private IDichVuVanChuyenSer _dichVuvanchuyenser;
        public IDichVuVanChuyenSer dichVuvanchuyenser => _dichVuvanchuyenser ?? (_dichVuvanchuyenser = new IplDichVuVanChuyenSer(_baseRepository));

        private IDonHangSer _donHangser;
        public IDonHangSer donHangser => _donHangser ?? (_donHangser = new IplDonHangSer(_baseRepository));

        private IKhachHangSer _khachHangser;
        public IKhachHangSer khachHangser => _khachHangser ?? (_khachHangser = new IplKhachHangSer(_baseRepository));

        private INhanVienSer _nhanVienser;
        public INhanVienSer nhanVienser => _nhanVienser ?? (_nhanVienser = new IplNhanVienSer(_baseRepository));

        private IPhanHoiSer _phanHoiser;
        public IPhanHoiSer phanHoiser => _phanHoiser ?? (_phanHoiser = new IplPhanHoiSer(_baseRepository));
    }
}
