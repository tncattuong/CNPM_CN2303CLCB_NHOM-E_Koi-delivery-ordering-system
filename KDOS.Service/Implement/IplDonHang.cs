using System;
using System.Collections.Generic;
using System.Linq;
using KDOS.Service.Interface;
using KDOS.Repository;
using KDOS.Repository.Models;

namespace KDOS.Service.Implement
{
    public class IplDonHangSer : IDonHangSer
    {
        private readonly IBase _baseDAL;

        public IplDonHangSer(IBase baseDAL)
        {
            _baseDAL = baseDAL;
        }

        // Insert new DonHang
        public bool Insert(DonHang donHang)
        {
            try
            {
                _baseDAL.donHangrepository.Insert(donHang);
                _baseDAL.donHangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Update existing DonHang
        public bool Update(DonHang donHang)
        {
            try
            {
                _baseDAL.donHangrepository.Update(donHang);
                _baseDAL.donHangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Delete DonHang by MaDonHang
        public bool Delete(int maDonHang)
        {
            try
            {
                _baseDAL.donHangrepository.Delete(maDonHang);
                _baseDAL.donHangrepository.SaveChanges();  // Save changes to database
                return true;
            }
            catch (Exception)
            {
                return false;  // Return false if error occurs
            }
        }

        // Get DonHang by MaDonHang
        public DonHang GetById(int maDonHang)
        {
            try
            {
                var donHang = _baseDAL.donHangrepository.GetById(maDonHang);  // Get DonHang by MaDonHang
                return donHang;
            }
            catch (Exception)
            {
                return null;  // Return null if error occurs
            }
        }

        // Get all DonHang with optional search filter
        public List<DonHang> GetAll(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return _baseDAL.donHangrepository.Get(x => x.MaKhach.Contains(search) || x.MaNhanVien.Contains(search)).ToList();  // Filter by MaKhach or MaNhanVien
            }
            else
            {
                return _baseDAL.donHangrepository.Get().ToList();  // Return all if no filter is provided
            }
        }

        // Get list of DonHang with paging and optional search keyword
        public List<DonHang> GetListAllPaging(string keywork = null, int offset = 0, int limit = 10)
        {
            try
            {
                return _baseDAL.donHangrepository.GetListAllPaging(keywork, offset, limit);
            }
            catch (Exception)
            {
                return new List<DonHang>();  // Return empty list if error occurs
            }
        }
    }
}
