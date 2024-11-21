using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KDOS.Repository.Base;
using KDOS.Repository.Interface;
using KDOS.Repository.Models;
using Microsoft.Extensions.Configuration;

namespace KDOS.Repository.Implement
{
    public class ChiTietDonHangRepository : GenericRepository<ChiTietDonHang>, IChiTietDonHangRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public ChiTietDonHangRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn"); // Lấy chuỗi kết nối từ cấu hình
        }

        // Phương thức lấy danh sách ChiTietDonHang với phân trang và từ khóa tìm kiếm
        public List<ChiTietDonHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbChiTietDonHang = _dbContext.ChiTietDonHangs
                    .Include(ct => ct.MaCaNavigation)      // Bao gồm thông tin về CaKoi
                    .Include(ct => ct.MaDonHangNavigation) // Bao gồm thông tin về DonHang
                    .Include(ct => ct.MaGiaNavigation)     // Bao gồm thông tin về BangGia
                    .AsQueryable();

                // Thực hiện phân trang và lọc theo từ khóa nếu có
                var data = dbChiTietDonHang
                    .Where(ct => string.IsNullOrEmpty(keyword)
                        || (ct.MaCa != null && ct.MaCa.Contains(keyword))
                        || (ct.MaDonHangNavigation != null && ct.MaDonHangNavigation.MaDonHang.ToString().Contains(keyword)))
                    .OrderByDescending(ct => ct.MaCtDonHang)
                    .Skip(offset)
                    .Take(limit)
                    .Select(ct => new ChiTietDonHang
                    {
                        MaCtDonHang = ct.MaCtDonHang,
                        MaDonHang = ct.MaDonHang,
                        MaCa = ct.MaCa,
                        SoLuong = ct.SoLuong,
                        MaGia = ct.MaGia,
                        MaCaNavigation = ct.MaCaNavigation,            // Thông tin về CaKoi
                        MaDonHangNavigation = ct.MaDonHangNavigation,  // Thông tin về DonHang
                        MaGiaNavigation = ct.MaGiaNavigation           // Thông tin về BangGia
                    })
                    .ToList();

                return data;
            }
            catch (Exception ex)
            {
                // Log lỗi để kiểm tra và khắc phục
                Console.WriteLine($"Error in GetListAllPaging: {ex.Message}");
                return null;
            }
        }

        //
        public bool Add(ChiTietDonHang chiTietDonHang)
        {
            try
            {
                _dbContext.ChiTietDonHangs.Add(chiTietDonHang);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }

        public bool Update(ChiTietDonHang chiTietDonHang)
        {
            try
            {
                _dbContext.ChiTietDonHangs.Update(chiTietDonHang);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int maChiTiet)
        {
            try
            {
                var chiTietDonHang = _dbContext.ChiTietDonHangs.FirstOrDefault(c => c.MaCtDonHang == maChiTiet);
                if (chiTietDonHang != null)
                {
                    _dbContext.ChiTietDonHangs.Remove(chiTietDonHang);
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
