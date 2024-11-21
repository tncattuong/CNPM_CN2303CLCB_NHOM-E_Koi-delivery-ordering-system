using System;
using KDOS.Repository.Interface;
using KDOS.Repository.Implement;
using Microsoft.Extensions.Configuration;
using KDOS.Repository.Models;

namespace KDOS.Repository
{
    public class IplBase : IBase
    {
        private readonly KingKoiContext _dbContext;
        private readonly IConfiguration _configuration;

        public IplBase(KingKoiContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        private IBangGiaRepository _bangGiaRepository;
        public IBangGiaRepository bangGiarepository
        {
            get
            {
                return _bangGiaRepository ?? (_bangGiaRepository = new BangGiaRepository(_dbContext, _configuration));
            }
        }

        private ICaKoiRepository _caKoiRepository;
        public ICaKoiRepository caKoirepository
        {
            get
            {
                return _caKoiRepository ?? (_caKoiRepository = new CaKoiRepository(_dbContext, _configuration));
            }
        }

        private IChiTietDonHangRepository _chiTietDonHangRepository;
        public IChiTietDonHangRepository chiTietdonhangrepository
        {
            get
            {
                return _chiTietDonHangRepository ?? (_chiTietDonHangRepository = new ChiTietDonHangRepository(_dbContext, _configuration));
            }
        }

        private IDichVuVanChuyenRepository _dichVuvanchuyenrepository;
        public IDichVuVanChuyenRepository dichVuvanchuyenrepository
        {
            get
            {
                return _dichVuvanchuyenrepository ?? (_dichVuvanchuyenrepository = new DichVuVanChuyenRepository(_dbContext, _configuration));
            }
        }

        private IDonHangRepository _donHangRepository;
        public IDonHangRepository donHangrepository
        {
            get
            {
                return _donHangRepository ?? (_donHangRepository = new DonHangRepository(_dbContext, _configuration));
            }
        }

        private IKhachHangRepository _khachHangRepository;
        public IKhachHangRepository khachHangrepository
        {
            get
            {
                return _khachHangRepository ?? (_khachHangRepository = new KhachHangRepository(_dbContext, _configuration));
            }
        }

        private INhanVienRepository _nhanVienRepository;
        public INhanVienRepository nhanVienrepository
        {
            get
            {
                return _nhanVienRepository ?? (_nhanVienRepository = new NhanVienRepository(_dbContext, _configuration));
            }
        }

        private IPhanHoiRepository _phanHoirepository;
        public IPhanHoiRepository phanHoirepository
        {
            get
            {
                return _phanHoirepository ?? (_phanHoirepository = new PhanHoiRepository(_dbContext, _configuration));
            }
        }
    }
}
