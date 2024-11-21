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
    public class DichVuVanChuyenRepository : GenericRepository<DichVuVanChuyen>, IDichVuVanChuyenRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public DichVuVanChuyenRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn"); // Lấy chuỗi kết nối từ cấu hình
        }

        // Phương thức lấy danh sách DichVuVanChuyen với phân trang và từ khóa tìm kiếm
        public List<DichVuVanChuyen> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbDichVuVanChuyen = _dbContext.DichVuVanChuyens
                    .Include(dv => dv.DonHangs) // Bao gồm thông tin về DonHang liên quan
                    .AsQueryable();

                // Thực hiện phân trang và lọc theo từ khóa nếu có
                var data = dbDichVuVanChuyen
                    .Where(dv => string.IsNullOrEmpty(keyword)
                        || (dv.MaVanChuyen != null && dv.MaVanChuyen.Contains(keyword))
                        || (dv.TenDonVi != null && dv.TenDonVi.Contains(keyword))
                        || (dv.TenVanChuyen != null && dv.TenVanChuyen.Contains(keyword)))
                    .OrderByDescending(dv => dv.NgayTao)
                    .Skip(offset)
                    .Take(limit)
                    .Select(dv => new DichVuVanChuyen
                    {
                        MaVanChuyen = dv.MaVanChuyen,
                        MaDonViVanChuyen = dv.MaDonViVanChuyen,
                        MaPhuongThuc = dv.MaPhuongThuc,
                        TenDonVi = dv.TenDonVi,
                        TenVanChuyen = dv.TenVanChuyen,
                        GiaCuoc = dv.GiaCuoc,
                        NgayTao = dv.NgayTao,
                        NgayChinhSua = dv.NgayChinhSua,
                        DonHangs = dv.DonHangs // Thông tin về DonHang
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
        public bool Add(DichVuVanChuyen dichVu)
        {
            try
            {
                _dbContext.DichVuVanChuyens.Add(dichVu);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }

        public bool Update(DichVuVanChuyen dichVu)
        {
            try
            {
                _dbContext.DichVuVanChuyens.Update(dichVu);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        public bool Delete(string maVanChuyen)
        {
            try
            {
                // Sửa lại tên tham chiếu từ MaDichVu thành MaVanChuyen
                var dichVu = _dbContext.DichVuVanChuyens.FirstOrDefault(d => d.MaVanChuyen == maVanChuyen);
                if (dichVu != null)
                {
                    _dbContext.DichVuVanChuyens.Remove(dichVu);
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
