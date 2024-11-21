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
    public class NhanVienRepository : GenericRepository<NhanVien>, INhanVienRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public NhanVienRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn");
        }

        // Phương thức lấy danh sách nhân viên với phân trang và từ khóa tìm kiếm
        public List<NhanVien> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbNhanVien = _dbContext.NhanViens
                    .Include(nv => nv.DonHangs)  // Include để lấy các đơn hàng liên quan
                    .AsQueryable();

                // Thực hiện phân trang và sắp xếp theo mã nhân viên giảm dần
                var data = dbNhanVien
                    .Where(nv => string.IsNullOrEmpty(keyword)
                        || nv.MaNhanVien.Contains(keyword)
                        || nv.HoTen.Contains(keyword))
                    .OrderByDescending(nv => nv.MaNhanVien)
                    .Skip(offset)
                    .Take(limit)
                    .Select(nv => new NhanVien
                    {
                        MaNhanVien = nv.MaNhanVien,
                        HoTen = nv.HoTen,
                        Tuoi = nv.Tuoi,
                        GioiTinh = nv.GioiTinh,
                        DiaChi = nv.DiaChi,
                        SoDienThoai = nv.SoDienThoai,
                        Email = nv.Email,
                        ThemVaoNgay = nv.ThemVaoNgay,
                        CapNhatVaoNgay = nv.CapNhatVaoNgay,
                        DonHangs = nv.DonHangs  // Bao gồm các đơn hàng liên quan
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

        // Phương thức tìm kiếm nhân viên theo mã
        public NhanVien GetByMaNhanVien(string maNhanVien)
        {
            try
            {
                return _dbContext.NhanViens
                    .Include(nv => nv.DonHangs)
                    .FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByMaNhanVien: {ex.Message}");
                return null;
            }
        }

        // Phương thức thêm nhân viên mới
        public bool Add(NhanVien nhanVien)
        {
            try
            {
                _dbContext.NhanViens.Add(nhanVien);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }

        // Phương thức cập nhật thông tin nhân viên
        public bool Update(NhanVien nhanVien)
        {
            try
            {
                _dbContext.NhanViens.Update(nhanVien);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        // Phương thức xóa nhân viên
        public bool Delete(string maNhanVien)
        {
            try
            {
                var nhanVien = _dbContext.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);
                if (nhanVien != null)
                {
                    _dbContext.NhanViens.Remove(nhanVien);
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
