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
    public class CaKoiRepository : GenericRepository<CaKoi>, ICaKoiRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public CaKoiRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn"); // Lấy chuỗi kết nối từ cấu hình
        }

        // Phương thức lấy danh sách CaKoi với phân trang và từ khóa tìm kiếm
        public List<CaKoi> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbCaKoi = _dbContext.CaKois
                    .Include(c => c.BangGia)            // Bao gồm các bảng giá liên quan
                    .Include(c => c.ChiTietDonHangs)    // Bao gồm các chi tiết đơn hàng liên quan
                    .AsQueryable();

                // Thực hiện phân trang và lọc theo từ khóa nếu có
                var data = dbCaKoi
                    .Where(c => string.IsNullOrEmpty(keyword)
                        || c.MaCa.Contains(keyword)
                        || (c.LoaiCa != null && c.LoaiCa.Contains(keyword)))
                    .OrderByDescending(c => c.MaCa)
                    .Skip(offset)
                    .Take(limit)
                    .Select(c => new CaKoi
                    {
                        MaCa = c.MaCa,
                        LoaiCa = c.LoaiCa,
                        MauSac = c.MauSac,
                        KichThuoc = c.KichThuoc,
                        Tuoi = c.Tuoi,
                        GiaBan = c.GiaBan,
                        BangGia = c.BangGia,              // Bao gồm các bảng giá liên quan
                        ChiTietDonHangs = c.ChiTietDonHangs // Bao gồm các chi tiết đơn hàng liên quan
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

        public bool Add(CaKoi caKoi)
        {
            try
            {
                _dbContext.CaKois.Add(caKoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }
        //Them
        public bool Update(CaKoi caKoi)
        {
            try
            {
                _dbContext.CaKois.Update(caKoi);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        public bool Delete(string maCa)
        {
            try
            {
                var caKoi = _dbContext.CaKois.FirstOrDefault(c => c.MaCa == maCa);
                if (caKoi != null)
                {
                    _dbContext.CaKois.Remove(caKoi);
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
        //
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
