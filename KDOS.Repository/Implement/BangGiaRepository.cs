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
    public class BangGiaRepository : GenericRepository<BangGia>, IBangGiaRepository
    {
        public IConfiguration _configuration { get; }
        private readonly string _cnnString;
        private readonly KingKoiContext _dbContext;

        public BangGiaRepository(KingKoiContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("cnn");
        }

        // Phương thức lấy danh sách BangGia với phân trang và từ khóa tìm kiếm
        public List<BangGia> GetListAllPaging(string keyword = null, int offset = 0, int limit = 10)
        {
            try
            {
                var dbBangGia = _dbContext.BangGias
                    .Include(b => b.ChiTietDonHangs)     // Include để lấy các ChiTietDonHang liên quan
                    .Include(b => b.MaCaNavigation)      // Include để lấy thông tin CaKoi liên quan
                    .AsQueryable();

                // Thực hiện phân trang và sắp xếp theo ID giảm dần
                var data = dbBangGia
                    .Where(b => string.IsNullOrEmpty(keyword)
                        || b.MaGia.ToString().Contains(keyword))
                    .OrderByDescending(b => b.MaGia)
                    .Skip(offset)
                    .Take(limit)
                    .Select(b => new BangGia
                    {
                        MaGia = b.MaGia,
                        MaCa = b.MaCa,
                        GiaVanChuyen = b.GiaVanChuyen,
                        NgayBatDau = b.NgayBatDau,
                        NgayKetThuc = b.NgayKetThuc,
                        ChiTietDonHangs = b.ChiTietDonHangs,  // Bao gồm ChiTietDonHang liên quan
                        MaCaNavigation = b.MaCaNavigation     // Bao gồm thông tin CaKoi liên quan
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
        //Phương thức thêm 
        public bool Add(BangGia bangGia)
        {
            try
            {
                _dbContext.BangGias.Add(bangGia);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                return false;
            }
        }

        public bool Update(BangGia bangGia)
        {
            try
            {
                _dbContext.BangGias.Update(bangGia);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int maGia)
        {
            try
            {
                var bangGia = _dbContext.BangGias.FirstOrDefault(b => b.MaGia == maGia);
                if (bangGia != null)
                {
                    _dbContext.BangGias.Remove(bangGia);
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
