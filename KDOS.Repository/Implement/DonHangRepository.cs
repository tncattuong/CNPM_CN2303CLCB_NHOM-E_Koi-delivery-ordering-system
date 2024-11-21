using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KDOS.Repository.Base;
using KDOS.Repository.Interface;
using KDOS.Repository.Models;

namespace KDOS.Repository.Implement// //////////////////////////////////////
{
    public class DonHangRepository : GenericRepository<DonHang>, IDonHangRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public DonHangRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn");
        }

        // Phương thức lấy danh sách DonHang với phân trang và từ khóa tìm kiếm
        public List<DonHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbDonHang = _dbContext.DonHangs
                    .Include(dh => dh.ChiTietDonHangs)           // Bao gồm ChiTietDonHang liên quan
                    .Include(dh => dh.MaKhachNavigation)         // Bao gồm thông tin KhachHang liên quan
                    .Include(dh => dh.MaNhanVienNavigation)      // Bao gồm thông tin NhanVien liên quan
                    .Include(dh => dh.MaVanChuyenNavigation)     // Bao gồm thông tin DichVuVanChuyen liên quan
                    .AsQueryable();

                // Thực hiện phân trang và lọc từ khóa
                var data = dbDonHang
                    .Where(dh => string.IsNullOrEmpty(keyword)
                        || dh.MaDonHang.ToString().Contains(keyword))
                    .OrderByDescending(dh => dh.MaDonHang)
                    .Skip(offset)
                    .Take(limit)
                    .Select(dh => new DonHang
                    {
                        MaDonHang = dh.MaDonHang,
                        MaKhach = dh.MaKhach,
                        MaNhanVien = dh.MaNhanVien,
                        MaVanChuyen = dh.MaVanChuyen,
                        NgayDatHang = dh.NgayDatHang,
                        ChiTietDonHangs = dh.ChiTietDonHangs,         // Bao gồm ChiTietDonHang
                        MaKhachNavigation = dh.MaKhachNavigation,     // Bao gồm thông tin KhachHang
                        MaNhanVienNavigation = dh.MaNhanVienNavigation, // Bao gồm thông tin NhanVien
                        MaVanChuyenNavigation = dh.MaVanChuyenNavigation, // Bao gồm thông tin DichVuVanChuyen
                        PhanHois = dh.PhanHois                        // Bao gồm PhanHoi liên quan
                    })
                    .ToList();

                return data;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có
                Console.WriteLine($"Lỗi trong GetListAllPaging: {ex.Message}");
                return null;
            }
        }
        //
        public bool Add(DonHang donHang)
        {
            try
            {
                _dbContext.DonHangs.Add(donHang);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }

        public bool Update(DonHang donHang)
        {
            try
            {
                _dbContext.DonHangs.Update(donHang);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int maDonHang)
        {
            try
            {
                var donHang = _dbContext.DonHangs.FirstOrDefault(d => d.MaDonHang == maDonHang);
                if (donHang != null)
                {
                    _dbContext.DonHangs.Remove(donHang);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete: {ex.Message}");
                return false;
            }
        }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
