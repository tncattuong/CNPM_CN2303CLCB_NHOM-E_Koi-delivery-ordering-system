using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KDOS.Repository.Base;
using KDOS.Repository.Interface;
using KDOS.Repository.Models;

namespace KDOS.Repository.Implement
{
    public class PhanHoiRepository : GenericRepository<PhanHoi>, IPhanHoiRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public PhanHoiRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn");
        }

        // Phương thức lấy danh sách phản hồi với phân trang và từ khóa tìm kiếm
        public List<PhanHoi> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbPhanHoi = _dbContext.PhanHois
                    .Include(ph => ph.MaKhachNavigation)  // Include để lấy thông tin KhachHang liên quan
                    .Include(ph => ph.MaDonHangNavigation)  // Include để lấy thông tin DonHang liên quan
                    .AsQueryable();

                // Thực hiện phân trang và sắp xếp theo mã phản hồi giảm dần
                var data = dbPhanHoi
                    .Where(ph => string.IsNullOrEmpty(keyword)
                        || ph.MaPhanHoi.ToString().Contains(keyword)
                        || ph.NoiDung.Contains(keyword))
                    .OrderByDescending(ph => ph.MaPhanHoi)
                    .Skip(offset)
                    .Take(limit)
                    .Select(ph => new PhanHoi
                    {
                        MaPhanHoi = ph.MaPhanHoi,
                        MaKhach = ph.MaKhach,
                        MaDonHang = ph.MaDonHang,
                        NoiDung = ph.NoiDung,
                        NgayPhanHoi = ph.NgayPhanHoi,
                        MaKhachNavigation = ph.MaKhachNavigation,  // Bao gồm thông tin KhachHang liên quan
                        MaDonHangNavigation = ph.MaDonHangNavigation  // Bao gồm thông tin DonHang liên quan
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

        // Phương thức tìm kiếm phản hồi theo mã phản hồi
        public PhanHoi GetByMaPhanHoi(int maPhanHoi)
        {
            try
            {
                return _dbContext.PhanHois
                    .Include(ph => ph.MaKhachNavigation)
                    .Include(ph => ph.MaDonHangNavigation)
                    .FirstOrDefault(ph => ph.MaPhanHoi == maPhanHoi);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByMaPhanHoi: {ex.Message}");
                return null;
            }
        }

        // Phương thức thêm phản hồi mới
        public bool Add(PhanHoi phanHoi)
        {
            try
            {
                _dbContext.PhanHois.Add(phanHoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }

        // Phương thức cập nhật phản hồi
        public bool Update(PhanHoi phanHoi)
        {
            try
            {
                _dbContext.PhanHois.Update(phanHoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        // Phương thức xóa phản hồi
        public bool Delete(int maPhanHoi)
        {
            try
            {
                var phanHoi = _dbContext.PhanHois.FirstOrDefault(ph => ph.MaPhanHoi == maPhanHoi);
                if (phanHoi != null)
                {
                    _dbContext.PhanHois.Remove(phanHoi);
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
