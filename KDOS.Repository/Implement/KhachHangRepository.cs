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
    public class KhachHangRepository : GenericRepository<KhachHang>, IKhachHangRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public KhachHangRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn");
        }

        // Phương thức lấy danh sách KhachHang với phân trang và từ khóa tìm kiếm
        public List<KhachHang> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbKhachHang = _dbContext.KhachHangs
                    .Include(kh => kh.DonHangs)     // Bao gồm các DonHang liên quan
                    .Include(kh => kh.PhanHois)     // Bao gồm các PhanHoi liên quan
                    .AsQueryable();

                // Thực hiện phân trang và lọc theo từ khóa
                var data = dbKhachHang
                    .Where(kh => string.IsNullOrEmpty(keyword)
                        || kh.MaKhach.Contains(keyword) || kh.TenKhach.Contains(keyword))
                    .OrderByDescending(kh => kh.MaKhach)
                    .Skip(offset)
                    .Take(limit)
                    .Select(kh => new KhachHang
                    {
                        MaKhach = kh.MaKhach,
                        TenKhach = kh.TenKhach,
                        GioiTinhKhach = kh.GioiTinhKhach,
                        DiaChiKhach = kh.DiaChiKhach,
                        SoDienThoai = kh.SoDienThoai,
                        Email = kh.Email,
                        NgayTao = kh.NgayTao,
                        NgayChinhSua = kh.NgayChinhSua,
                        DonHangs = kh.DonHangs,      // Bao gồm DonHangs liên quan
                        PhanHois = kh.PhanHois       // Bao gồm PhanHois liên quan
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

        // Phương thức tìm khách hàng theo mã khách
        public KhachHang GetByMaKhach(string maKhach)
        {
            try
            {
                return _dbContext.KhachHangs
                    .Include(kh => kh.DonHangs)
                    .Include(kh => kh.PhanHois)
                    .FirstOrDefault(kh => kh.MaKhach == maKhach);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong GetByMaKhach: {ex.Message}");
                return null;
            }
        }

        // Phương thức thêm mới một khách hàng
        public void Add(KhachHang khachHang)
        {
            try
            {
                _dbContext.KhachHangs.Add(khachHang);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong Add: {ex.Message}");
            }
        }

        // Phương thức cập nhật thông tin khách hàng
        public void Update(KhachHang khachHang)
        {
            try
            {
                _dbContext.KhachHangs.Update(khachHang);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong Update: {ex.Message}");
            }
        }

        // Phương thức xóa khách hàng
        public void Delete(string maKhach)
        {
            try
            {
                var khachHang = _dbContext.KhachHangs.FirstOrDefault(kh => kh.MaKhach == maKhach);
                if (khachHang != null)
                {
                    _dbContext.KhachHangs.Remove(khachHang);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong Delete: {ex.Message}");
            }
        }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
